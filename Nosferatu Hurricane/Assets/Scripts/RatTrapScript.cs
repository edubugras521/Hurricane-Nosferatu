using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatTrapScript : MonoBehaviour
{
    public GameObject[] ratTraps;
    public int ratTrapAi;

    public List<int> RandomNotRepeat;

    public int randomNumber;

    public RatControl ratControl;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < PlayerPrefs.GetInt("RatAiLevel"); i++)
        {
            randomNumber = UnityEngine.Random.Range(0, ratTraps.Length);

            while (RandomNotRepeat.Contains(randomNumber))
            {
                randomNumber = UnityEngine.Random.Range(0, ratTraps.Length);
            }

            RandomNotRepeat.Add(randomNumber);
            ratTraps[randomNumber].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ratTrapAi >= ratTraps.Length)
        {
            ratTrapAi = ratTraps.Length;
        }
        if (ratTrapAi < 0)
        {
            ratTrapAi = 0;
        }

        ratTrapAi = Mathf.RoundToInt(ratControl.ratAi/10 - 0.5f);
        PlayerPrefs.SetInt("RatAiLevel", ratTrapAi);
    }
}
