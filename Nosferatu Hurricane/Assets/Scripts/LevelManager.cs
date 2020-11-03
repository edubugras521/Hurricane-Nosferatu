using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject player;
    public CanvasGroup killScreen;
    public CanvasGroup failScreen;

    public static bool levelComplete = false;
    public static bool levelFailed = false;
    public static bool resetLevel = false;
    public static int currentLevel = 0;

    // Update is called once per frame
    void Update()
    {
        if (levelComplete && !levelFailed)
        {
            Cursor.lockState = CursorLockMode.Confined;
            if (killScreen.alpha < 1)
            {
                killScreen.alpha += (1f * Time.deltaTime);
            }
            else
            {
                resetLevel = true;
            }
        }

        if (!levelComplete && levelFailed)
        {
            Cursor.lockState = CursorLockMode.Confined;
            if (failScreen.alpha < 1)
            {
                failScreen.alpha += (1f * Time.deltaTime);
            }
            else
            {
                resetLevel = true;
            }
        }

    }

    public void KilledTarget()
    {
        levelComplete = true;
        killScreen.gameObject.SetActive(true);
    }

    public void PlayerDetected()
    {
        levelFailed = true;
        failScreen.gameObject.SetActive(true);
    }

    public void RetryLevel()
    {
        levelComplete = false;
        levelFailed = false;
        resetLevel = false;
        killScreen.alpha = 0;
        killScreen.gameObject.SetActive(false);
        failScreen.alpha = 0;
        failScreen.gameObject.SetActive(false);
        player.GetComponent<RespawnManager>().Respawn();
    }

    public void NextLevel()
    {
        if(currentLevel >= 0 && currentLevel < 8)
        {
            currentLevel++;
            Debug.Log(currentLevel);
        }

        levelComplete = false;
        levelFailed = false;
        resetLevel = false;
        killScreen.alpha = 0;
        killScreen.gameObject.SetActive(false);
        failScreen.alpha = 0;
        failScreen.gameObject.SetActive(false);
        player.GetComponent<RespawnManager>().Respawn();
    }
}
