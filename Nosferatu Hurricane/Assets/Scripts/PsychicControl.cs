using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PsychicControl : MonoBehaviour
{
    private GameObject psychic;
    public bool activateTimer;
    public float timer;
    public Animator animator;
    public AudioSource sfxSource;

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

        if (Input.GetKeyDown(KeyCode.L) && timer < 1 && !activateTimer)
        {
            if (bloodBar.BloodLeft >= 20)
            {
                psychic.SetActive(true);
                activateTimer = true;
                animator.SetBool("Aterrorizando", true);
                StartCoroutine("PsychicBloodDrain");
                sfxSource.Play();
            }
        }
        else if(timer >= 1)
        {
            psychic.SetActive(false);
            activateTimer = false;
            timer = 0;
            animator.SetBool("Aterrorizando", false);
            StopCoroutine("PsychicBloodDrain");
        }
    }

    public IEnumerator PsychicBloodDrain()
    {
        while (true)
        {
            bloodBar.BloodLeft -= 0.25f;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
