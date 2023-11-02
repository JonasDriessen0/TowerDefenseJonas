using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MetalHandler : MonoBehaviour
{
    public TMP_Text metalDisplay;
    public int metal;
    void Start()
    {
        metal = 400;
    }
    private void Update()
    {
        metalDisplay.text = "" + metal;
    }
}
