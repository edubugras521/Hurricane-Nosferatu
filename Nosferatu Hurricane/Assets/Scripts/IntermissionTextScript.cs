using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntermissionTextScript : MonoBehaviour
{

    public GameObject textoTutorial;
    public GameObject textoLevel1;
    public GameObject textoLevel2;
    public GameObject textoLevel3;
    public GameObject textoLevel4;
    public CanvasGroup canvas;

    void Start()
    {
        LevelCheck();
    }

    // Update is called once per frame
    void Update()
    {
        LevelCheck();

        if(gameObject.activeSelf && canvas.alpha < 1)
        {
            canvas.alpha += Time.deltaTime;
            Mathf.Clamp(canvas.alpha, 0, 1);
        }
    }

    private void LevelCheck()
    {

        if (PlayerPrefs.GetInt("CurrentLevel") == 0)
        {
            textoTutorial.SetActive(true);
            textoLevel1.SetActive(false);
            textoLevel2.SetActive(false);
            textoLevel3.SetActive(false);
            textoLevel4.SetActive(false);
        }
        if (PlayerPrefs.GetInt("CurrentLevel") == 1)
        {
            textoTutorial.SetActive(false);
            textoLevel1.SetActive(true);
            textoLevel2.SetActive(false);
            textoLevel3.SetActive(false);
            textoLevel4.SetActive(false);
        }
        if (PlayerPrefs.GetInt("CurrentLevel") == 2)
        {
            textoTutorial.SetActive(false);
            textoLevel1.SetActive(false);
            textoLevel2.SetActive(true);
            textoLevel3.SetActive(false);
            textoLevel4.SetActive(false);
        }
        if (PlayerPrefs.GetInt("CurrentLevel") == 3)
        {
            textoTutorial.SetActive(false);
            textoLevel1.SetActive(false);
            textoLevel2.SetActive(false);
            textoLevel3.SetActive(true);
            textoLevel4.SetActive(false);
        }
        if (PlayerPrefs.GetInt("CurrentLevel") == 4)
        {
            textoTutorial.SetActive(false);
            textoLevel1.SetActive(false);
            textoLevel2.SetActive(false);
            textoLevel3.SetActive(false);
            textoLevel4.SetActive(true);
        }
    }
}
