using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepFX : MonoBehaviour
{
    public CanvasGroup footstepCanvas;

    private float speed = 1f;

    void Update()
    {
        if(footstepCanvas.alpha > 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + (speed * Time.deltaTime), transform.position.z);
            footstepCanvas.alpha -= speed * Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
