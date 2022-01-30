using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastPaintBlock : MonoBehaviour
{
    public Camera mainCamera;

    // Update is called once per frame
    void Update()
    {
        if (BuilderManager.I.mode == Mode.Paiting && Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null && hit.collider.CompareTag("Block"))
                {
                    hit.collider.GetComponent<BetaBlock>().PaintBlock();
                }
            }
        }
    }
}
