using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepingFX : MonoBehaviour
{
    public CanvasGroup footstepCanvas;

    private float speed = 0.5f;
    private float scaleFactor = 1.5f;

    void Update()
    {
        if(footstepCanvas.alpha > 0)
        {
            transform.position = new Vector3(transform.position.x + ((speed / 2) * Time.deltaTime), transform.position.y + (speed * Time.deltaTime), transform.position.z);

            if(scaleFactor != 0)
            {
                scaleFactor -= speed * Time.deltaTime;
                Mathf.Clamp(scaleFactor, 0, 1.5f);
            }
            transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);

            footstepCanvas.alpha -= speed * Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
