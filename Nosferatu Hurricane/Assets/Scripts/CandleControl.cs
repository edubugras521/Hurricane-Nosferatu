using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleControl : MonoBehaviour
{

    public GameObject candleLight;

    private bool isLit = true;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnOff()
    {
        isLit = false;
        candleLight.GetComponent<Light>().enabled = false;
    }

    public bool IsLit()
    {
        return isLit;
    }
}
