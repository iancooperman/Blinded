using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class BallScript : MonoBehaviour
{

    public float speed;
    public AudioClip winSound;
    public GameObject particle;

    private Rigidbody rb;
    private AudioSource _audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.transform.Translate(new Vector3(0f, 0f, 1 * speed * Time.deltaTime));
    }

    void OnTriggerEnter(Collider col)
    {

        if (col.tag == "Point")
        {
            Destroy(col.gameObject);
            Instantiate(particle, col.transform.position, col.transform.rotation);
            _audioSource.clip = winSound;
            _audioSource.Play();

        }
    }
}