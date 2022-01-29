using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBuilder : MonoBehaviour
{
    public Vector3Int blockDimention = Vector3Int.one * 10;

    public GameObject parentBlock;

    public GameObject prefabBaseBlock;

    void Start()
    {

    }

    void Update()
    {

    }

    [ContextMenu("Create Block")]
    void CreateBlock()
    {
        for (int x = 0; x < blockDimention.x; x++)
        {
            for (int y = 0; y < blockDimention.y; y++)
            {
                



                for (int z = 0; z < blockDimention.z; z++)
                {
                    GameObject go = Instantiate(prefabBaseBlock, parentBlock.transform) as GameObject;

                    go.transform.localScale = Vector3.one * 0.1f;

                    go.transform.localPosition = new Vector3(x, y, z) * 0.1f;
                }
            }
        }
    }

    [ContextMenu("UpdatePos")]
    void UpdatePos()
    {

    }



}
