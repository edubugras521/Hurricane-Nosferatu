using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleControl : MonoBehaviour
{

    public GameObject candleLight;
    public GameObject candleRangeLight;
    public GameObject candleFuse;

    public Material fuseDark;
    public Material fuseLit;

    private bool isLit = true;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnOff()
    {
        isLit = false;
        candleRangeLight.GetComponent<Light>().enabled = false;
        candleLight.GetComponent<Light>().enabled = false;
        candleFuse.GetComponent<SphereCollider>().enabled = false;
        candleFuse.GetComponent<Renderer>().material = fuseDark;
    }

    public void TurnOn()
    {
        isLit = true;
        candleRangeLight.GetComponent<Light>().enabled = true;
        candleLight.GetComponent<Light>().enabled = true;
        candleFuse.GetComponent<SphereCollider>().enabled = true;
        candleFuse.GetComponent<Renderer>().material = fuseLit;
    }

    public bool IsLit()
    {
        return isLit;
    }
}
