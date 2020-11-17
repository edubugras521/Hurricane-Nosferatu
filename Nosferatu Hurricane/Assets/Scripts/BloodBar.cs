using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodBar : MonoBehaviour
{
    public Slider BloodSlider;

    public float BloodLeft;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (BloodLeft >= 100) BloodLeft = 100;
        else if (BloodLeft <= 0) BloodLeft = 0;
        else BloodSlider.value = BloodLeft;
    }
}
