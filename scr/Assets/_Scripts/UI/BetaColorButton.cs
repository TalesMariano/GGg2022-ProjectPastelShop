using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BetaColorButton : MonoBehaviour
{
    public Material material;

    Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void Start()
    {
        var img = GetComponent<Image>();

        img.color = material.color;
    }
}
