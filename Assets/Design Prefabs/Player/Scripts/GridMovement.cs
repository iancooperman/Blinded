using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{

    public float unitsPerKeypress = 1f;
    public List<AudioClip> stepSounds;
    public AudioClip wallHitSound;

    private Rigidbody rb;
    private SphereCollider c;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        c = GetComponent<SphereCollider>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move() {
        if (Input.GetKeyDown("w")) {
            DetectObstacleAndMove(Vector3.forward);
        }

        if (Input.GetKeyDown("a")) {
            DetectObstacleAndMove(Vector3.left);
        }

        if (Input.GetKeyDown("s")) {
            DetectObstacleAndMove(Vector3.back);
        }

        if (Input.GetKeyDown("d")) {
            DetectObstacleAndMove(Vector3.right);
        }
    }

    void PlayStepSound() {
        if (stepSounds.Count > 0) {
            int index = Random.Range(0, stepSounds.Count - 1);
            audioSource.clip = stepSounds[index];
            audioSource.Play();
        }
    }

    void PlayWallHitSound() {
        audioSource.clip = wallHitSound;
        audioSource.Play();
    }

    void DetectObstacleAndMove(Vector3 direction) {

        float radius = c.radius * transform.lossyScale.x;


        // Designers must make sure walls and other obstacles are given the layer of obstacle.
        int ObstacleLayer = LayerMask.GetMask("Obstacle");

        RaycastHit hit = new RaycastHit();

        bool overlap = Physics.BoxCast(rb.position, Vector3.one * radius, direction, out hit, Quaternion.identity, unitsPerKeypress);

        

        if (!overlap) {
            Debug.Log("There is no wall.");
            rb.MovePosition(rb.position + direction * unitsPerKeypress);
            PlayStepSound();
        }
        else {
            Debug.Log("There's a wall here, dumbass.");
            PlayWallHitSound();
        }

        
    }
}
