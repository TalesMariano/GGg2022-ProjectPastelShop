using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetaBlock : MonoBehaviour
{
    bool showDebug = true;

    [SerializeField]
    private Renderer rend;

    [SerializeField]
    private GameObject go;

    void OnMouseDown()
    {
       // Debug.Log("Block Clicked", gameObject);


        if (Input.GetKey("mouse 0"))
        {

            OnClick();
        }
    }


    void OnClick()
    {
        if(BuilderManager.I.mode == Mode.Breaking)
        {
            BreakBlock();
        }
        else if (BuilderManager.I.mode == Mode.Paiting)
        {
            PaintBlock();
        }
    }

    void BreakBlock()
    {
        //Debug.Log("BreakBlock", gameObject);
        Destroy(go);
    }

    void PaintBlock()
    {
        //Debug.Log("PaintBlock", gameObject);
        rend.material = BuilderManager.I.applyMaterial;
    }
}
