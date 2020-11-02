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

    public void CursorOver()
    {
        Buttons[0].GetComponent<Image>().sprite = SourceSprite;
    }
}
