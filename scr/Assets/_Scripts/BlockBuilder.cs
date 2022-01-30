using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlockBuilder : MonoBehaviour
{
    public Vector3Int blockDimention = Vector3Int.one * 10;



    public GameObject parentBlock;
    public GameObject placeBlock;

    public GameObject prefabBaseBlock;

    private GameObject pivotObject;

    private void Start()
    {
        ClearAllBlocks();
        //ClearChild();
    }

    [ContextMenu("Create Block")]
    void CreateBlock()
    {
        CreateBlock(blockDimention.x, blockDimention.y, blockDimention.z);
    }

    void CreateBlock(int _x, int _y, int _z)
    {
        pivotObject = Instantiate(parentBlock, parentBlock.transform) as GameObject;

        for (int x = 0; x < _x; x++)
        {
            for (int y = 0; y < _y; y++)
            {

                for (int z = 0; z < _z; z++)
                {
                    GameObject go = Instantiate(prefabBaseBlock, pivotObject.transform) as GameObject;

                    go.transform.localScale = Vector3.one * 0.1f;

                    go.transform.localPosition = (new Vector3(x, y, z) - new Vector3(_x, _y, _z)/2) * 0.1f;
                }
            }
        }
    }

    [ContextMenu("Clear All Blocks")]
    public void ClearAllBlocks()
    {
        int i = 0;

        //Array to hold all child obj
        GameObject[] allChildren = new GameObject[parentBlock.transform.childCount];

        //Find all child obj and store to that array
        foreach (Transform child in parentBlock.transform)
        {
            allChildren[i] = child.gameObject;
            i += 1;
        }

        //Now destroy them
        foreach (GameObject child in allChildren)
        {
            DestroyImmediate(child.gameObject);
        }

    }


    public void ClearChild()
    {
        int i = 0;

        //Array to hold all child obj
        GameObject[] allChildren = new GameObject[placeBlock.transform.childCount];

        //Find all child obj and store to that array
        foreach (Transform child in placeBlock.transform)
        {
            allChildren[i] = child.gameObject;
            i += 1;
        }

        //Now destroy them
        foreach (GameObject child in allChildren)
        {
            DestroyImmediate(child.gameObject);
        }

    }

    public void MakePainelBlock()
    {
        ClearAllBlocks();
        CreateBlock(10, 10, 1);
    }

    public void MakeBigBlock()
    {
        ClearAllBlocks();
        CreateBlock(10, 10, 10);
    }

    public void SendToRoom()
    {
        DontDestroyOnLoad(placeBlock);
        placeBlock.transform.rotation = new Quaternion();
        pivotObject.transform.position += Vector3.up * 0.1f * 5.0f;
        pivotObject.transform.position += Vector3.left * 100;
        MySceneManager.I.LoadSceneNAme("Room");

        
    }


}
