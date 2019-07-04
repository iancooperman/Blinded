using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public Transform playerRespawnPoint;
    //public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        //player.transform.position = teleportTarget.transform.position;
        GameObject.Find("Player").transform.position = playerRespawnPoint.transform.position;
    }
}
