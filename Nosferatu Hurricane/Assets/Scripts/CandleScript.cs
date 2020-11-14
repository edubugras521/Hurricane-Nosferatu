using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleScript : MonoBehaviour
{
    public GameObject[] candles;
    public int candlesAi;

    public List<int> RandomNotRepeat;

    public int randomNumber;

    public ShadowControl shadowControl;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < PlayerPrefs.GetInt("CandleAiLevel"); i++)
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
        if (candlesAi >= candles.Length)
        {
            candlesAi = candles.Length;
        }
        if (candlesAi < 0)
        {
            candlesAi = 0;
        }

        candlesAi = Mathf.RoundToInt(shadowControl.shadowAi / 10 - 0.5f);
    }
}
