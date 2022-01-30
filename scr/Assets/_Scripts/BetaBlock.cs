using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetaBlock : MonoBehaviour
{
    bool showDebug = true;

    bool painted = false;

    [SerializeField]
    private Renderer rend;

    [SerializeField]
    private Collider collider;

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
        if (painted)
        {
            painted = false;
            rend.material = BuilderManager.I.baseMaterial;
        }
        else
        {
            Destroy(go);
            collider.enabled = false;
        }
    }

    public void PaintBlock()
    {
        //Debug.Log("PaintBlock", gameObject);
        rend.material = BuilderManager.I.applyMaterial;

        painted = true;
    }
}
