using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetaTeleporterScene : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MySceneManager.I.LoadSceneNAme("BlockBuilder");
        }
    }
}
