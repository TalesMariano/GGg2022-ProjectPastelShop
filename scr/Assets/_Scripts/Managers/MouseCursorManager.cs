using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursorManager : MonoBehaviour
{
    public Texture2D[] mouseCursors;
    public Vector2[] hotspots;
    public CursorMode cursorMode = CursorMode.Auto;

    private void OnEnable()
    {
        BuilderManager.I.OnModeChange += ChangeMouseMode;
    }

    private void OnDisable()
    {
        BuilderManager.I.OnModeChange -= ChangeMouseMode;
    }

    void ChangeMouseMode()
    {
        Debug.Log("ChangeMode");

        switch (BuilderManager.I.mode)
        {
            case Mode.None:
                SetMouseCursor(0);
                break;
            case Mode.Moving:
                SetMouseCursor(1);
                break;
            case Mode.Breaking:
                SetMouseCursor(2);
                break;
            case Mode.Paiting:
                SetMouseCursor(3);
                break;
            default:
                SetMouseCursor(0);
                break;
        }
    }

    void SetMouseCursor(int i)
    {
        Cursor.SetCursor(mouseCursors[i], hotspots[i], cursorMode);
    }
}
