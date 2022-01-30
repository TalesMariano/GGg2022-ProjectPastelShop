using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BetaCreateButtons : MonoBehaviour
{
    public GameObject buttonPrefab;

    public Transform target;

    public MaterialList materialList;

    private void Start()
    {
        CreateButtons();
    }

    [ContextMenu("Create Buttons")]
    void CreateButtons()
    {
        for (int i = 0; i < materialList.materials.Length; i++)
        {
            GameObject go = Instantiate(buttonPrefab, target);

            go.SetActive(true);

            var btn = go.GetComponent<Button>();

            btn.GetComponent<Image>().color = materialList.materials[i].color;

            var mat = materialList.materials[i];

            btn.onClick.AddListener(delegate { SetMat(mat); } );
        }
    }

    void SetMat(Material mat)
    {
        Debug.Log("Start color set " + mat.name);

        BuilderManager.I.SelectBrush();
        BuilderManager.I.SetMaterialBrush(mat);
    }
}
