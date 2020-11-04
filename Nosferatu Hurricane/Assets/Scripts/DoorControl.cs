﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    public Transform doorPivot;
    public Quaternion openAngle;
    public GameObject rangidoEffects;

    public bool lockedLevel0 = true;
    public bool lockedLevel1 = true;
    public bool lockedLevel2 = true;
    public bool lockedLevel3 = true;
    public bool lockedLevel4 = true;
    public bool lockedLevel5 = true;
    public bool lockedLevel6 = true;
    public bool lockedLevel7 = true;

    private bool isOpen = false;
    private bool isLocked = true;
    private bool doorSlammed = true;
    private int currentLevel = 0;

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

        LevelCheck();

        if (isLocked)
        {
            gameObject.tag = "DoorLocked";
            isOpen = false;
            currentRotation = closed;
        }
        else if(!isLocked)
        {
            gameObject.tag = "Door";
        }

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

    private void LevelCheck()
    {
        currentLevel = LevelManager.currentLevel;

        if(currentLevel == 0 && (isLocked != lockedLevel0))
        {
            isLocked = lockedLevel0;
        }
        if (currentLevel == 1 && (isLocked != lockedLevel1))
        {
            isLocked = lockedLevel1;
        }
        if (currentLevel == 2 && (isLocked != lockedLevel2))
        {
            isLocked = lockedLevel2;
        }
        if (currentLevel == 3 && (isLocked != lockedLevel3))
        {
            isLocked = lockedLevel3;
        }
        if (currentLevel == 4 && (isLocked != lockedLevel4))
        {
            isLocked = lockedLevel4;
        }
        if (currentLevel == 5 && (isLocked != lockedLevel5))
        {
            isLocked = lockedLevel5;
        }
        if (currentLevel == 6 && (isLocked != lockedLevel6))
        {
            isLocked = lockedLevel6;
        }
        if (currentLevel == 7 && (isLocked != lockedLevel7))
        {
            isLocked = lockedLevel7;
        }
    }
}
