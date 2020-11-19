using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject backgroundCanvas;
    public GameObject optionsScreen;
    public GameObject tutorialScreen;
    public GameObject soundScreen;
    public GameObject controlsScreen;

    private LevelManager levelManager;
    public GameObject winScreen;
    public GameObject loseScreen;

    public GameObject[] Buttons;

    public Sprite SourceSprite;

    public Slider musicSlider;

    // Start is called before the first frame update
    void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 100);

        pauseScreen.SetActive(false);
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);

        if (Input.GetKeyDown(KeyCode.Escape) && !pauseScreen.activeSelf && !winScreen.activeSelf && !loseScreen.activeSelf)
        {
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pauseScreen.activeSelf)
        {
            pauseScreen.SetActive(false);
            backgroundCanvas.SetActive(false);
            optionsScreen.SetActive(false);
            controlsScreen.SetActive(false);
            tutorialScreen.SetActive(false);
            soundScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void ReturnToGame()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
    }

    public void Options()
    {
        optionsScreen.SetActive(true);
        backgroundCanvas.SetActive(true);
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        levelManager.RetryLevel();
        pauseScreen.SetActive(false);
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(0);
    }

    public void ControlsScreen()
    {
        controlsScreen.SetActive(true);
        optionsScreen.SetActive(false);
    }

    public void TutorialScreen()
    {
        tutorialScreen.SetActive(true);
        optionsScreen.SetActive(false);
    }

    public void SoundScreen()
    {
        soundScreen.SetActive(true);
        optionsScreen.SetActive(false);
    }

    public void BackToOptionsMenu()
    {
        optionsScreen.SetActive(true);
        tutorialScreen.SetActive(false);
        soundScreen.SetActive(false);
        controlsScreen.SetActive(false);
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        Buttons[0].GetComponent<Image>().sprite = null;
        Buttons[0].GetComponent<Image>().color = Color.clear;
        Buttons[1].GetComponent<Image>().sprite = null;
        Buttons[1].GetComponent<Image>().color = Color.clear;
        Buttons[2].GetComponent<Image>().sprite = null;
        Buttons[2].GetComponent<Image>().color = Color.clear;
        Buttons[3].GetComponent<Image>().sprite = null;
        Buttons[3].GetComponent<Image>().color = Color.clear;
    }

    public void BackToMenu()
    {
        optionsScreen.SetActive(false);
        backgroundCanvas.SetActive(false);
        Buttons[3].GetComponent<Image>().color = Color.clear;
        Buttons[3].GetComponent<Image>().color = Color.clear;
    }

    public void CursorOverControls()
    {
        Buttons[0].GetComponent<Image>().sprite = SourceSprite;
        Buttons[0].GetComponent<Image>().color = Color.white;
    }
    public void CursorOverTutorial()
    {
        Buttons[1].GetComponent<Image>().sprite = SourceSprite;
        Buttons[1].GetComponent<Image>().color = Color.white;
    }
    public void CursorOverSound()
    {
        Buttons[2].GetComponent<Image>().sprite = SourceSprite;
        Buttons[2].GetComponent<Image>().color = Color.white;
    }
    public void CursorOverBack()
    {
        Buttons[3].GetComponent<Image>().sprite = SourceSprite;
        Buttons[3].GetComponent<Image>().color = Color.white;
    }

    public void CursorExitControls()
    {
        Buttons[0].GetComponent<Image>().sprite = null;
        Buttons[0].GetComponent<Image>().color = Color.clear;
    }
    public void CursorExitTutorial()
    {
        Buttons[1].GetComponent<Image>().sprite = null;
        Buttons[1].GetComponent<Image>().color = Color.clear;
    }
    public void CursorExitSound()
    {
        Buttons[2].GetComponent<Image>().sprite = null;
        Buttons[2].GetComponent<Image>().color = Color.clear;
    }
    public void CursorExitBack()
    {
        Buttons[3].GetComponent<Image>().sprite = null;
        Buttons[3].GetComponent<Image>().color = Color.clear;
    }
}
