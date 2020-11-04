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
    public bool activeLevel5 = true;
    public bool activeLevel6 = true;
    public bool activeLevel7 = true;

    private bool isActive = false;
    private int currentLevel = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LevelCheck();
    }

    public void LevelCheck()
    {
        currentLevel = LevelManager.currentLevel;

        if (currentLevel == 0 && (isActive != activeLevel0))
        {
            isActive = activeLevel0;
        }

        if (currentLevel == 1 && (isActive != activeLevel1))
        {
            isActive = activeLevel1;
        }

        if (currentLevel == 2 && (isActive != activeLevel2))
        {
            isActive = activeLevel2;
        }

        if (currentLevel == 3 && (isActive != activeLevel3))
        {
            isActive = activeLevel3;
        }

        if (currentLevel == 4 && (isActive != activeLevel4))
        {
            isActive = activeLevel4;
        }

        if (currentLevel == 5 && (isActive != activeLevel5))
        {
            isActive = activeLevel5;
        }

        if (currentLevel == 6 && (isActive != activeLevel6))
        {
            isActive = activeLevel6;
        }

        if (currentLevel == 7 && (isActive != activeLevel7))
        {
            isActive = activeLevel7;
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
