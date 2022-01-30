// Ref: https://www.youtube.com/watch?v=kplusZYqBok

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetaRotateBlock : MonoBehaviour
{

    Vector3 mPrevPos = Vector3.zero;
    Vector3 mPosDelta = Vector3.zero;

    public Transform target;

    void Update()
    {
        if (BuilderManager.I.mode == Mode.Moving && Input.GetMouseButton(0))
        {
            mPosDelta = Input.mousePosition - mPrevPos;

            if(Vector3.Dot(target.transform.up, Vector3.up) >= 0)
            {
                target.Rotate(target.transform.up, -Vector3.Dot(mPosDelta, Camera.main.transform.right), Space.World);
            }
            else
            {
                target.Rotate(target.transform.up, Vector3.Dot(mPosDelta, Camera.main.transform.right), Space.World);
            }

            target.Rotate(Camera.main.transform.right, Vector3.Dot(mPosDelta, Camera.main.transform.up), Space.World);
        }

        mPrevPos = Input.mousePosition;
    }

    public void ResetRotation()
    {
        Debug.Log("ResetRotation");

        target.localRotation = Quaternion.Euler(Vector3.zero);
    }
}
