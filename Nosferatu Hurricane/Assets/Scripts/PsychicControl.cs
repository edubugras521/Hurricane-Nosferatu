using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PsychicControl : MonoBehaviour
{
    private GameObject psychic;
    public bool activateTimer;
    public float timer;

    private BloodBar bloodBar;

    // Start is called before the first frame update
    void Start()
    {
        psychic = GameObject.Find("Psychic");
        psychic.SetActive(false);
        bloodBar = FindObjectOfType<BloodBar>();
    }

    // Update is called once per frame
    void Update()
    {
        if (activateTimer)
        {
            timer += Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && timer < 1)
        {
            if (bloodBar.BloodLeft >= 20)
            {
                psychic.SetActive(true);
                activateTimer = true;
                StartCoroutine("PsychicBloodDrain");
            }
        }
        else if(timer >= 1)
        {
            psychic.SetActive(false);
            activateTimer = false;
            timer = 0;
            StopCoroutine("PsychicBloodDrain");
        }
    }

    public IEnumerator PsychicBloodDrain()
    {
        while (true)
        {
            bloodBar.BloodLeft -= 0.33f;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
