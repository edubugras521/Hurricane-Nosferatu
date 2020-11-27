﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public GameObject OptionsCanvas;
    public GameObject MenuCanvas;
    public GameObject CreditsCanvas;
    public GameObject LevelSelectCanvas;
    public GameObject TutorialCanvas;
    public GameObject SoundCanvas;
    public GameObject ControlsCanvas;
    public GameObject ResetProgressCanvas;

    public Sprite SourceSprite;

    public GameObject[] Buttons;
    public GameObject[] Levels;

    public Slider musicSlider;


    void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 100);

        if (PlayerPrefs.GetInt("UnlockLevel") >= 0)
        {
            Levels[0].GetComponent<Image>().color = Color.white;
        }

        if (PlayerPrefs.GetInt("UnlockLevel") >= 1)
        {
            Levels[1].GetComponent<Image>().color = Color.white;
        }

        if (PlayerPrefs.GetInt("UnlockLevel") >= 2)
        {
            Levels[2].GetComponent<Image>().color = Color.white;
        }

        if (PlayerPrefs.GetInt("UnlockLevel") >= 3)
        {
            Levels[3].GetComponent<Image>().color = Color.white;
        }

        if (PlayerPrefs.GetInt("UnlockLevel") >= 4)
        {
            Levels[4].GetComponent<Image>().color = Color.white;
        }
    }

    void Update()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
        AudioListener.volume = PlayerPrefs.GetFloat("MusicVolume") / 100;
    }

    public void StartGame()
    {
        //SceneManager.LoadScene("LevelTutorial");
        Buttons[0].GetComponent<Image>().sprite = null;
        Buttons[0].GetComponent<Image>().color = Color.clear;
        MenuCanvas.SetActive(false);
        LevelSelectCanvas.SetActive(true);
    }

    public void OptionsScreen()
    {
        Buttons[2].GetComponent<Image>().sprite = null;
        Buttons[2].GetComponent<Image>().color = Color.clear;
        OptionsCanvas.SetActive(true);
        MenuCanvas.SetActive(false);
    }

    public void CreditsScreen()
    {
        Buttons[1].GetComponent<Image>().sprite = null;
        Buttons[1].GetComponent<Image>().color = Color.clear;
        CreditsCanvas.SetActive(true);
        MenuCanvas.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        OptionsCanvas.SetActive(false);
        CreditsCanvas.SetActive(false);
        LevelSelectCanvas.SetActive(false);
        TutorialCanvas.SetActive(false);
        MenuCanvas.SetActive(true);
        Buttons[7].GetComponent<Image>().sprite = null;
        Buttons[7].GetComponent<Image>().color = Color.clear;
    }

    public void BackToOptionsMenu()
    {
        OptionsCanvas.SetActive(true);
        TutorialCanvas.SetActive(false);
        SoundCanvas.SetActive(false);
        ControlsCanvas.SetActive(false);
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        Buttons[4].GetComponent<Image>().sprite = null;
        Buttons[4].GetComponent<Image>().color = Color.clear;
        Buttons[5].GetComponent<Image>().sprite = null;
        Buttons[5].GetComponent<Image>().color = Color.clear;
        Buttons[6].GetComponent<Image>().sprite = null;
        Buttons[6].GetComponent<Image>().color = Color.clear;
    }

    public void ControlsScreen()
    {
        ControlsCanvas.SetActive(true);
        OptionsCanvas.SetActive(false);
    }

    public void TutorialScreen()
    {
        TutorialCanvas.SetActive(true);
        OptionsCanvas.SetActive(false);
    }

    public void SoundScreen()
    {
        SoundCanvas.SetActive(true);
        OptionsCanvas.SetActive(false);
    }

    public void ResetProgress()
    {
        ResetProgressCanvas.SetActive(true);
        OptionsCanvas.SetActive(false);
    }

    public void ConfirmReset()
    {
        PlayerPrefs.DeleteAll();
        ResetProgressCanvas.SetActive(false);
        OptionsCanvas.SetActive(true);
    }

    public void DenyReset()
    {
        ResetProgressCanvas.SetActive(false);
        OptionsCanvas.SetActive(true);
    }

    public void Level1()
    {
        if (PlayerPrefs.GetInt("UnlockLevel") >= 0)
        {
            PlayerPrefs.SetInt("CurrentLevel", 0);
            SceneManager.LoadSceneAsync(1);
        }
    }
    public void Level2()
    {
        if (PlayerPrefs.GetInt("UnlockLevel") >= 1)
        {
            PlayerPrefs.SetInt("CurrentLevel", 1);
            SceneManager.LoadSceneAsync(1);
        }
    }
    public void Level3()
    {
        if (PlayerPrefs.GetInt("UnlockLevel") >= 2)
        {
            PlayerPrefs.SetInt("CurrentLevel", 2);
            SceneManager.LoadSceneAsync(1);
        }
    }
    public void Level4()
    {
        if (PlayerPrefs.GetInt("UnlockLevel") >= 3)
        {
            PlayerPrefs.SetInt("CurrentLevel", 3);
            SceneManager.LoadSceneAsync(1);
        }
    }

    public void Level5()
    {
        if (PlayerPrefs.GetInt("UnlockLevel") >= 4)
        {
            PlayerPrefs.SetInt("CurrentLevel", 4);
            SceneManager.LoadSceneAsync(1);
        }
    }

    public void CursorOverStart()
    {
        Buttons[0].GetComponent<Image>().sprite = SourceSprite;
        Buttons[0].GetComponent<Image>().color = Color.white;
    }
    public void CursorOverCredits()
    {
        Buttons[1].GetComponent<Image>().sprite = SourceSprite;
        Buttons[1].GetComponent<Image>().color = Color.white;
    }
    public void CursorOverInstructions()
    {
        Buttons[2].GetComponent<Image>().sprite = SourceSprite;
        Buttons[2].GetComponent<Image>().color = Color.white;
    }
    public void CursorOverExit()
    {
        Buttons[3].GetComponent<Image>().sprite = SourceSprite;
        Buttons[3].GetComponent<Image>().color = Color.white;
    }

    public void CursorExitStart()
    {
        Buttons[0].GetComponent<Image>().sprite = null;
        Buttons[0].GetComponent<Image>().color = Color.clear;
    }
    public void CursorExitCredits()
    {
        Buttons[1].GetComponent<Image>().sprite = null;
        Buttons[1].GetComponent<Image>().color = Color.clear;
    }
    public void CursorExitInstructions()
    {
        Buttons[2].GetComponent<Image>().sprite = null;
        Buttons[2].GetComponent<Image>().color = Color.clear;
    }
    public void CursorExitExit()
    {
        Buttons[3].GetComponent<Image>().sprite = null;
        Buttons[3].GetComponent<Image>().color = Color.clear;
    }


    public void CursorOverControls()
    {
        Buttons[4].GetComponent<Image>().sprite = SourceSprite;
        Buttons[4].GetComponent<Image>().color = Color.white;
    }
    public void CursorOverTutorial()
    {
        Buttons[5].GetComponent<Image>().sprite = SourceSprite;
        Buttons[5].GetComponent<Image>().color = Color.white;
    }
    public void CursorOverSound()
    {
        Buttons[6].GetComponent<Image>().sprite = SourceSprite;
        Buttons[6].GetComponent<Image>().color = Color.white;
    }
    public void CursorOverBack()
    {
        Buttons[7].GetComponent<Image>().sprite = SourceSprite;
        Buttons[7].GetComponent<Image>().color = Color.white;
    }

    public void CursorExitControls()
    {
        Buttons[4].GetComponent<Image>().sprite = null;
        Buttons[4].GetComponent<Image>().color = Color.clear;
    }
    public void CursorExitTutorial()
    {
        Buttons[5].GetComponent<Image>().sprite = null;
        Buttons[5].GetComponent<Image>().color = Color.clear;
    }
    public void CursorExitSound()
    {
        Buttons[6].GetComponent<Image>().sprite = null;
        Buttons[6].GetComponent<Image>().color = Color.clear;
    }
    public void CursorExitBack()
    {
        Buttons[7].GetComponent<Image>().sprite = null;
        Buttons[7].GetComponent<Image>().color = Color.clear;
    }
}
