using System;
using System.Collections.Generic;
using UnityEngine;

public class BuilderManager : MonoBehaviour
{

    public static BuilderManager I;





    public Mode mode = Mode.None;



    public Material applyMaterial;
    public Material baseMaterial;

    public Action OnModeChange;

    void Awake()
    {
        I = this;
    }


    public void SelectChizel()
    {
        mode = Mode.Breaking;
        OnModeChange?.Invoke();
    }

    public void SelectBrush()
    {
        mode = Mode.Paiting;
        OnModeChange?.Invoke();
    }

    public void SelectMove()
    {
        mode = Mode.Moving;
        OnModeChange?.Invoke();
    }

    public void SelectNone()
    {
        mode = Mode.None;
        OnModeChange?.Invoke();
    }

    public void SetMaterialBrush(Material mat)
    {
        applyMaterial = mat;

        Debug.Log("Color set  done " + applyMaterial.name);
    }

}

public enum Mode
{
    None = 0,
    Moving = 1,
    Breaking = 2,
    Paiting = 3
}
