using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    private Transform player;

    public Transform respawnLocation;

    private void Start()
    {
        player = GetComponent<Transform>();
    }
    public void Respawn()
    {
        player.position = respawnLocation.position;
        player.rotation = respawnLocation.rotation;
    }
}
