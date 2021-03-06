﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowControl : MonoBehaviour
{
    public bool ControlShadow;
    private CharacterController shadowController;
    private GameObject Player;
    private CapsuleCollider shadowCollider;
    private InteracaoShadow interacaoShadow;

    Vector3 directionShadow = Vector3.zero;

    public float shadowVelocity;
    public float shadowVelRotacao;

    // Start is called before the first frame update
    void Start()
    {
        shadowController = GetComponent<CharacterController>();
        shadowCollider = GetComponent<CapsuleCollider>();
        interacaoShadow = GetComponent<InteracaoShadow>();
        Player = GameObject.Find("Player");

        interacaoShadow.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.forward = Vector3.RotateTowards(transform.forward, directionShadow, shadowVelRotacao * Time.deltaTime, 0.0f);

        if (Input.GetKeyDown(KeyCode.LeftShift) && !ControlShadow)
        {
            ControlShadow = true;
            shadowCollider.enabled = true;
            Player.GetComponent<Interacao>().enabled = false;
            interacaoShadow.enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift) && ControlShadow)
        {
            ControlShadow = false;
            shadowCollider.enabled = false;
            Player.GetComponent<Interacao>().enabled = true;
            interacaoShadow.enabled = false;
        }

        if (ControlShadow)
        {
            directionShadow = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            directionShadow = Vector3.ClampMagnitude(directionShadow, 1);
            directionShadow *= shadowVelocity;

            shadowController.Move(directionShadow * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector3(Player.transform.position.x, transform.position.y, Player.transform.position.z);
            transform.rotation = Player.transform.rotation;
        }
    }
}
