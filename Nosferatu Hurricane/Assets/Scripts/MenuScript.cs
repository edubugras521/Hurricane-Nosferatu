using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject CreditsImage;
    public GameObject BackButton;
    public GameObject InstructionsImage;

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
}
