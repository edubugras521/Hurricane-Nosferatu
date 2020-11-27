﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject player;
    public CanvasGroup intermissionScreen;
    public CanvasGroup killScreen;
    public CanvasGroup failScreen;
    public CanvasGroup finalScreen;
    public Animator assassinationAnimator;
    public AudioSource sfxWin;
    public AudioSource sfxLose;
    public AudioSource sfxFinal;
    public GameObject alvo0;
    public GameObject alvo1;
    public GameObject alvo2;
    public GameObject alvo3;
    public GameObject alvo4;
    public GameObject guard0;
    public GameObject guard1;
    public GameObject guard2;
    public GameObject guard3;
    public GameObject guard4;

    public static bool levelComplete = false;
    public static bool levelFailed = false;
    public static bool resetLevel = false;
    public static bool gameOver = false;
    public int currentLevel;
    public int unlockNextLevel;

    private RatControl ratControl;
    private ShadowControl shadowControl;

    private CandleScript candleScript;
    private RatTrapScript ratTrapScript;

    // Update is called once per frame

    void Start()
    {
        unlockNextLevel = PlayerPrefs.GetInt("UnlockLevel");
        currentLevel = PlayerPrefs.GetInt("CurrentLevel");
        ratControl = FindObjectOfType<RatControl>();
        shadowControl = FindObjectOfType<ShadowControl>();
        candleScript = FindObjectOfType<CandleScript>();
        ratTrapScript = FindObjectOfType<RatTrapScript>();
        LevelSelect();
    }
    void Update()
    {
        if (levelComplete && !levelFailed && !gameOver)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            if (killScreen.alpha < 1)
            {
                killScreen.alpha += Time.deltaTime;
            }
            else
            {
                assassinationAnimator.SetBool("playAnimation", true);
                resetLevel = true;
            }
        }

        if (!levelComplete && levelFailed && !gameOver)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            if (failScreen.alpha < 1)
            {
                failScreen.alpha += Time.deltaTime;
            }
            else
            {
                resetLevel = true;
            }
        }

        if (levelComplete && !levelFailed && gameOver)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            if (finalScreen.alpha < 1)
            {
                finalScreen.alpha += Time.deltaTime;
            }
            else
            {
                assassinationAnimator.SetBool("playAnimation", true);
            }
        }

    }

    public void KilledTarget()
    {

        if (currentLevel == 4)
        {
            levelComplete = true;
            gameOver = true;
            finalScreen.gameObject.SetActive(true);
            if (!sfxFinal.isPlaying) sfxFinal.Play();
            return;
        }

        levelComplete = true;
        killScreen.gameObject.SetActive(true);
        if (!sfxWin.isPlaying) sfxWin.Play();
    }

    public void PlayerDetected()
    {
        if (!levelComplete)
        {
            levelFailed = true;
            failScreen.gameObject.SetActive(true);
            if(!sfxLose.isPlaying) sfxLose.Play();
        }
    }

    public void RetryLevel()
    {
        shadowControl.shadowAi = PlayerPrefs.GetFloat("ShadowAi");
        ratControl.ratAi = PlayerPrefs.GetFloat("RatAi");
        levelComplete = false;
        levelFailed = false;
        resetLevel = false;
        killScreen.alpha = 0;
        killScreen.gameObject.SetActive(false);
        failScreen.alpha = 0;
        failScreen.gameObject.SetActive(false);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        if (sfxLose.isPlaying) sfxLose.Stop();
        if (sfxWin.isPlaying) sfxWin.Stop();
        Cursor.visible = false;
    }

    public void NextLevel()
    {
        if (currentLevel == unlockNextLevel)
        {
            unlockNextLevel++;
        }

        if (currentLevel >= 0 && currentLevel < 4)
        {
            currentLevel++;
        }

        PlayerPrefs.SetInt("UnlockLevel", unlockNextLevel);
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);
        PlayerPrefs.SetFloat("RatAi", ratControl.ratAi);
        PlayerPrefs.SetFloat("ShadowAi", shadowControl.shadowAi);
        PlayerPrefs.SetInt("CandleAiLevel", candleScript.candlesAi);
        PlayerPrefs.SetInt("RatAiLevel", ratTrapScript.ratTrapAi);
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
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        assassinationAnimator.SetBool("playAnimation", false);
        sfxLose.Stop();
        sfxWin.Stop();
        Cursor.visible = false;
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
        Cursor.visible = false;
        //player.GetComponent<RespawnManager>().Respawn();
    }

    public void TargetCheck()
    {
        alvo0.SetActive(true);
        alvo1.SetActive(true);
        alvo2.SetActive(true);
        alvo3.SetActive(true);
        alvo4.SetActive(true);
    }

    public void GuardasCheck()
    {
        guard0.SetActive(true);
        guard1.SetActive(true);
        guard2.SetActive(true);
        guard3.SetActive(true);
        guard4.SetActive(true);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
