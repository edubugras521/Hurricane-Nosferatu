using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public GameObject pauseScreen;
    private LevelManager levelManager;
    public GameObject winScreen;
    public GameObject loseScreen;


    // Start is called before the first frame update
    void Start()
    {
        pauseScreen.SetActive(false);
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pauseScreen.activeSelf && !winScreen.activeSelf && !loseScreen.activeSelf)
        {
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pauseScreen.activeSelf)
        {
            pauseScreen.SetActive(false);
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
}
