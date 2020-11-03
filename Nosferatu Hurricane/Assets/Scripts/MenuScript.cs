using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public GameObject CreditsImage;
    public GameObject BackButton;
    public GameObject InstructionsImage;

    public Sprite SourceSprite;

    public GameObject[] Buttons;

    public void StartGame()
    {
        SceneManager.LoadScene("LevelTutorial");
    }

    public void CreditsScreen()
    {
        CreditsImage.SetActive(true);
        BackButton.SetActive(true);
    }

    public void InstructionsScreen()
    {
        InstructionsImage.SetActive(true);
        BackButton.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        CreditsImage.SetActive(false);
        InstructionsImage.SetActive(false);
        BackButton.SetActive(false);
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
