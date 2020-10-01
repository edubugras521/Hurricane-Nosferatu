using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorFX : MonoBehaviour
{
    public CanvasGroup doorFxCanvas;

    private float speed = 0.5f;
    private float xOffset = 0.05f;

    void Update()
    {
        if(doorFxCanvas.alpha > 0)
        {
            transform.position = new Vector3(transform.position.x + xOffset, transform.position.y + Time.deltaTime, transform.position.z);
            xOffset = -xOffset;
            doorFxCanvas.alpha -= speed * Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
