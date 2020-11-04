using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchControl : MonoBehaviour
{
    public GameObject torchLight;
    public GameObject torchEmbers;
    public Material litMaterial;
    public Material dimMaterial;

    private bool isLit = true;

    // Update is called once per frame
    void Update()
    {

    }

    public void TurnOff()
    {
        isLit = false;
        torchEmbers.GetComponent<Renderer>().material = dimMaterial;
        torchLight.GetComponent<Light>().enabled = false;
    }
    public bool IsLit()
    {
        return isLit;
    }
}
