using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderManager : MonoBehaviour
{

    public static BuilderManager I;





    public Mode mode = Mode.None;


    public Material applyMaterial;

    void Awake()
    {
        I = this;
    }



}

public enum Mode
{
    None = 0,
    Moving = 1,
    Breaking = 2,
    Paiting = 3
}
