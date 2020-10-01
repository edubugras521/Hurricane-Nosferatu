using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraIso : MonoBehaviour
{
    public Transform player;
    private GameObject rat;
    private GameObject shadow;
    public RatControl ratControl;
    public ShadowControl shadowControl;

    void Start()
    {
        ratControl = FindObjectOfType<RatControl>();
        shadowControl = FindObjectOfType<ShadowControl>();
        rat = GameObject.Find("Rat");
        shadow = GameObject.Find("Shadow");
    }

    // Update is called once per frame
    void Update()
    {
        if (ratControl.ControlRat)
        {
            transform.position = rat.transform.position;
        }
        else if (shadowControl.ControlShadow)
        {
            transform.position = shadow.transform.position;
        }
        else
        {
            transform.position = player.position;
        }
    }
}
