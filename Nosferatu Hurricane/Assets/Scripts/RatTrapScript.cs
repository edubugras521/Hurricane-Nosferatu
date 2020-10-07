using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatTrapScript : MonoBehaviour
{
    public GameObject[] ratTraps;
    public int ratTrapAi; // prototipo, mudar depois

    public List<int> RandomNotRepeat;

    public int randomNumber;

    // Start is called before the first frame update
    void Start()
    {
        if (ratTrapAi >= ratTraps.Length)
        {
            ratTrapAi = ratTraps.Length;
        }

        PlayerPrefs.SetInt("RatAiLevel", ratTrapAi); // prototipo, mudar depois

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

    }
}
