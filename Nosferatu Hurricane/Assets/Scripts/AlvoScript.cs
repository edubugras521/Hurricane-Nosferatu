using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlvoScript : MonoBehaviour
{
    public bool activeLevel0 = true;
    public bool activeLevel1 = true;
    public bool activeLevel2 = true;
    public bool activeLevel3 = true;
    public bool activeLevel4 = true;

    public GameObject sleepEffect;

    private bool isActive = false;
    private float effectTimer = 0;
    private float effectInterval = 0.75f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        LevelCheck();

        if (effectTimer <= 0)
        {
            Instantiate(sleepEffect, new Vector3(transform.position.x, (transform.position.y + 2f), transform.position.z), Quaternion.identity);
            effectTimer = effectInterval;
        }
        else
        {
            effectTimer -= Time.deltaTime;
        }

    }

    public void LevelCheck()
    {

        if (PlayerPrefs.GetInt("CurrentLevel") == 0 && (isActive != activeLevel0))
        {
            isActive = activeLevel0;
        }

        if (PlayerPrefs.GetInt("CurrentLevel") == 1 && (isActive != activeLevel1))
        {
            isActive = activeLevel1;
        }

        if (PlayerPrefs.GetInt("CurrentLevel") == 2 && (isActive != activeLevel2))
        {
            isActive = activeLevel2;
        }

        if (PlayerPrefs.GetInt("CurrentLevel") == 3 && (isActive != activeLevel3))
        {
            isActive = activeLevel3;
        }

        if (PlayerPrefs.GetInt("CurrentLevel") == 4 && (isActive != activeLevel4))
        {
            isActive = activeLevel4;
        }

        if (isActive)
        {
            gameObject.SetActive(true);
        }

        else
        {
            gameObject.SetActive(false);
        }
    }
}
