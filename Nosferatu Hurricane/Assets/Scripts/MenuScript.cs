using System.Collections;
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

    public Sprite SourceSprite;

    public GameObject[] Buttons;

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
        MenuCanvas.SetActive(true);
        Buttons[7].GetComponent<Image>().sprite = null;
        Buttons[7].GetComponent<Image>().color = Color.clear;
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
