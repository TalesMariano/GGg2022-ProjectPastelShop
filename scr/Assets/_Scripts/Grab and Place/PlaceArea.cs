using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceArea : MonoBehaviour
{
    public GameObject placeHightlight;
    //public Collider collider;

    public void PlaceObject(Transform objToPlace)
    {
        objToPlace.parent = transform;

        objToPlace.localPosition = Vector3.zero;
        objToPlace.localRotation = Quaternion.identity;

        //GetComponent<Collider>().enabled = false;

        HideHighlight();
    }

    void ShowHighlight()
    {
        placeHightlight.SetActive(true);
    }

    void HideHighlight()
    {
        placeHightlight.SetActive(false);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position + Vector3.up / 2, new Vector3(1, 1, 1));
        Gizmos.DrawLine(transform.position + Vector3.up / 2, transform.position+transform.forward + Vector3.up / 2);
    }

}
