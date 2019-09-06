using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public Transform playerRespawnPoint;
    public float noiseDelay;
    //public GameObject player;


    private void Start()
    {
        float delay = Random.Range(0f, noiseDelay);
        GetComponent<AudioSource>().PlayDelayed(delay);
    }


    public Monster(Transform resapwnPoint)
    {
        playerRespawnPoint = resapwnPoint;
    }

    private void OnTriggerEnter(Collider other)
    {
        //player.transform.position = teleportTarget.transform.position;
        GameObject.Find("Player").transform.position = playerRespawnPoint.transform.position;
    }
}
