using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PsychicControl : MonoBehaviour
{
    private GameObject psychic;
    public bool activateTimer;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        psychic = GameObject.Find("Psychic");
        psychic.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (activateTimer)
        {
            timer += Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && timer < 2)
        {
            psychic.SetActive(true);
            activateTimer = true;
        }
        else if(timer >= 2)
        {
            psychic.SetActive(false);
            activateTimer = false;
            timer = 0;
        }
    }
}
