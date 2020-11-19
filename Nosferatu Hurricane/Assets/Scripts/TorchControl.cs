using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchControl : MonoBehaviour
{
    public GameObject torchLight;
    public GameObject torchFuse;

    public Material torchDark;
    public Material torchLit;

    private bool isLit = true;

    public void TurnOff()
    {
        isLit = false;
        torchLight.GetComponent<Light>().enabled = false;
        torchFuse.GetComponent<SphereCollider>().enabled = false;
        torchFuse.GetComponent<Renderer>().material = torchDark;
    }

    public void TurnOn()
    {
        isLit = true;
        torchLight.GetComponent<Light>().enabled = true;
        torchFuse.GetComponent<SphereCollider>().enabled = true;
        torchFuse.GetComponent<Renderer>().material = torchLit;
    }

    public bool IsLit()
    {
        return isLit;
    }
}