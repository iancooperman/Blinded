using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleportTarget;
    //public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        //player.transform.position = teleportTarget.transform.position;
        GameObject.Find("Player").transform.position = teleportTarget.transform.position;
    }
}
