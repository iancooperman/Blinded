using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player position is: " + GameObject.Find("Player").transform.position);
        //player.transform.position = respawnPoint.transform.position;
        GameObject.Find("Player").transform.position = respawnPoint.transform.position;
    }
}
