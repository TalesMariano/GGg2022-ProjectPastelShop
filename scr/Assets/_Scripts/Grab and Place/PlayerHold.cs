using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHold : MonoBehaviour
{
    [SerializeField] Transform holdArea;

    bool holding = false;

    [SerializeField] PlaceArea lastPlaceArea;
    [SerializeField] Transform lastHoldObject;

    [SerializeField] Transform objHolding;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!holding)
            {
                if (lastHoldObject) GrabObj(lastHoldObject);
            }
            else
            {
                if (lastPlaceArea) PlaceObj();
            } 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlaceArea"))
        {
            lastPlaceArea = other.GetComponent<PlaceArea>();
        }
        else if (!holding && other.CompareTag("HoldObj"))
        {
            lastHoldObject = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlaceArea"))
        {
            lastPlaceArea = null;
        }
        else if (!holding && other.CompareTag("HoldObj"))
        {
            lastHoldObject = null;
        }
    }

    void GrabObj(Transform obj)
    {
        objHolding = obj;
        holding = true;

        obj.parent = holdArea;

        obj.localPosition = Vector3.zero;
        obj.localRotation = Quaternion.identity;
    }

    void PlaceObj()
    {
        lastPlaceArea.PlaceObject(objHolding);
        objHolding = null;
        holding = false;
    }
}
