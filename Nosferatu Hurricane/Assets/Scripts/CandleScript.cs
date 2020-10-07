using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleScript : MonoBehaviour
{
    public GameObject[] candles;
    public int candlesAi; // prototipo, mudar depois

    public List<int> RandomNotRepeat;

    public int randomNumber;

    // Start is called before the first frame update
    void Start()
    {
        if (candlesAi >= candles.Length)
        {
            candlesAi = candles.Length;
        }

        PlayerPrefs.SetInt("RatAiLevel", candlesAi); // prototipo, mudar depois

        for (int i = 0; i < PlayerPrefs.GetInt("RatAiLevel"); i++)
        {
            randomNumber = UnityEngine.Random.Range(0, candles.Length);

            while (RandomNotRepeat.Contains(randomNumber))
            {
                randomNumber = UnityEngine.Random.Range(0, candles.Length);
            }

            RandomNotRepeat.Add(randomNumber);
            candles[randomNumber].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
