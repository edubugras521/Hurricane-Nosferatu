using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject player;
    public CanvasGroup killScreen;
    public CanvasGroup failScreen;
    public CanvasGroup finalScreen;
    public GameObject alvo0;
    public GameObject alvo1;
    public GameObject alvo2;
    public GameObject alvo3;
    public GameObject guard0;
    public GameObject guard1;
    public GameObject guard2;
    public GameObject guard3;

    public static bool levelComplete = false;
    public static bool levelFailed = false;
    public static bool resetLevel = false;
    public static bool gameOver = false;
    public int currentLevel;
    public int unlockNextLevel;

    private RatControl ratControl;

    // Update is called once per frame

    void Start()
    {
        unlockNextLevel = PlayerPrefs.GetInt("UnlockLevel");
        currentLevel = PlayerPrefs.GetInt("CurrentLevel");
        ratControl = FindObjectOfType<RatControl>();
        LevelSelect();
    }
    void Update()
    {
        if (levelComplete && !levelFailed && !gameOver)
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

        if (!levelComplete && levelFailed && !gameOver)
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

        if (levelComplete && !levelFailed && gameOver)
        {
            Cursor.lockState = CursorLockMode.Confined;
            if (finalScreen.alpha < 1)
            {
                finalScreen.alpha += (1f * Time.deltaTime);
            }
        }

    }

    public void KilledTarget()
    {

        if (currentLevel == 3)
        {
            levelComplete = true;
            gameOver = true;
            finalScreen.gameObject.SetActive(true);
            return;
        }

        levelComplete = true;
        killScreen.gameObject.SetActive(true);
    }

    public void PlayerDetected()
    {
        if (!levelComplete)
        {
            levelFailed = true;
            failScreen.gameObject.SetActive(true);
        }
    }

    public void RetryLevel()
    {
        ratControl.ratAi = PlayerPrefs.GetFloat("RatAi");
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
        if (currentLevel == unlockNextLevel)
        {
            unlockNextLevel++;
        }

        if (currentLevel >= 0 && currentLevel < 3)
        {
            currentLevel++;
        }

        PlayerPrefs.SetInt("UnlockLevel", unlockNextLevel);
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);
        PlayerPrefs.SetFloat("RatAi", ratControl.ratAi);
        Debug.Log(currentLevel);
        levelComplete = false;
        levelFailed = false;
        resetLevel = false;
        killScreen.alpha = 0;
        killScreen.gameObject.SetActive(false);
        failScreen.alpha = 0;
        failScreen.gameObject.SetActive(false);
        TargetCheck();
        GuardasCheck();
        player.GetComponent<RespawnManager>().Respawn();
    }

    public void LevelSelect()
    {
        levelComplete = false;
        levelFailed = false;
        resetLevel = false;
        killScreen.alpha = 0;
        killScreen.gameObject.SetActive(false);
        failScreen.alpha = 0;
        failScreen.gameObject.SetActive(false);
        TargetCheck();
        GuardasCheck();
        player.GetComponent<RespawnManager>().Respawn();
    }

    public void TargetCheck()
    {
        alvo0.SetActive(true);
        alvo1.SetActive(true);
        alvo2.SetActive(true);
        alvo3.SetActive(true);
    }

    public void GuardasCheck()
    {
        guard0.SetActive(true);
        guard1.SetActive(true);
        guard2.SetActive(true);
        guard3.SetActive(true);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
