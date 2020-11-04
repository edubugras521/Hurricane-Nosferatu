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

    public Sprite SourceSprite;

    public GameObject[] Buttons;

    public void StartGame()
    {
        SceneManager.LoadScene("LevelTutorial");
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
        CreditsCanvas.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        OptionsCanvas.SetActive(false);
        CreditsCanvas.SetActive(false);
        MenuCanvas.SetActive(true);
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
}
