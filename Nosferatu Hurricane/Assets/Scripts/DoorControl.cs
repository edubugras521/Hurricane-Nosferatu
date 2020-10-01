using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    public Transform doorPivot;
    public Quaternion openAngle;
    public GameObject rangidoEffects;

    private bool isOpen = false;
    private bool doorSlammed = true;

    //public AudioSource Doorknob;
    //public AudioSource DoorOpening;
    //public AudioSource DoorClosing;

    private Quaternion currentRotation;
    private float speed = 50;
    private Quaternion closed;

    void Start()
    {
        closed = doorPivot.localRotation;
    }

    void Update()
    {
        currentRotation = doorPivot.localRotation;

        if (isOpen)
        {
            if(doorSlammed) doorSlammed = false;
            currentRotation = Quaternion.RotateTowards(currentRotation, openAngle, speed * Time.fixedDeltaTime);
        }

        else
        {
            currentRotation = Quaternion.RotateTowards(currentRotation, closed, speed * Time.fixedDeltaTime);

            if(currentRotation == closed && !doorSlammed)
            {
                //DoorClosing.Play();
                doorSlammed = true;
            }
        }

        if(LevelManager.resetLevel)
        {
            isOpen = false;
            currentRotation = closed;
        }

        doorPivot.localRotation = currentRotation;
    }

    public void ToggleDoor()
    {
        isOpen = !isOpen;
        Instantiate(rangidoEffects, transform.position, Quaternion.identity);
        //Doorknob.Play();
        //DoorOpening.Play();
    }

    public void ToggleLockedDoor()
    {
        //if (!Doorknob.isPlaying)
        //{
            //Doorknob.Play();
        //}
    }
}
