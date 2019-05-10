using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{

    public float unitsPerKeypress = 1f;
    public List<AudioClip> stepSounds;
    public List<AudioClip> WoodStepSounds;//ADDED
    public List<AudioClip> SnowStepSounds;//ADDED
    public AudioClip wallHitSound;

    private Rigidbody rb;
    private SphereCollider c;
    private AudioSource audioSource;

    public GameObject snow;
    public GameObject wood;
    public GameObject stone;
    //public <List>

    public enum StepSound { Stone, Snow, Wood };

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
        Pause();
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

    void Pause()
    {
        if (Input.GetKeyDown("escape"))
        {
            //SceneManager.LoadScene('Stage Pause - Armando');
        }
    }
    public void PlayStepSound(StepSound sound) {
        switch (sound)
        {
            case StepSound.Snow:
            {
                int index = Random.Range(0, SnowStepSounds.Count - 1);
                audioSource.clip = SnowStepSounds[index];
                audioSource.Play();
                //Debug.Log("This is SNOW");
                break;
            }

            case StepSound.Wood:
            {
                int index = Random.Range(0, WoodStepSounds.Count - 1);
                audioSource.clip = WoodStepSounds[index];
                audioSource.Play();
                //Debug.Log("This is WOOD");
                break;
            }

            default:
            {
                int index = Random.Range(0, stepSounds.Count - 1);
                audioSource.clip = stepSounds[index];
                audioSource.Play();
                break;
            }
                
        }

        /*if (stepSounds.Count > 0) {
            int index = Random.Range(0, stepSounds.Count - 1);
            audioSource.clip = stepSounds[index];
            audioSource.Play();
        }*/

        //if (stepSounds.Count > 0)
       // {
            /*if (false/*rb.position.y == stone)//STONE
            {
                //GameObject originalGameObject = GameObject.Find("MainObj");
                //GameObject child = originalGameObject.transform.GetChild(0).gameObject;
                int index = Random.Range(0, stepSounds.Count - 1);
                audioSource.clip = stepSounds[index];
                audioSource.Play();
            }
            else if (rb.position.y == snow.transform.position.y)//SNOW
            {
                int index = Random.Range(0, SnowStepSounds.Count - 1);
                audioSource.clip = SnowStepSounds[index];
                audioSource.Play();
            }
             else//WOOD - default
            {
                int index = Random.Range(0, WoodStepSounds.Count - 1);
                audioSource.clip = WoodStepSounds[index];
                audioSource.Play();
            }*/

           // if ()
        //}
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
            PlayStepSound(StepSound.Stone);
        }
        else {
            Debug.Log("There's a wall here, dumbass.");
            PlayWallHitSound();
        }
    }
}
