using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{

    public float unitsPerKeypress = 1f;
    public List<AudioClip> stepSounds;
    public List<AudioClip> WoodStepSounds;
    public List<AudioClip> SnowStepSounds;
    public List<AudioClip> MetalStepSounds;
    public List<AudioClip> GrassStepSounds;
    public List<AudioClip> WaterStepSounds;
    public List<AudioClip> DirtStepSounds;
    public List<AudioClip> MudStepSounds;
    public AudioClip wallHitSound;

    private Rigidbody rb;
    private SphereCollider c;
    private AudioSource audioSource;

    public GameObject snow;
    public GameObject wood;
    public GameObject stone;
    public GameObject metal;
    public GameObject grass;
    public GameObject water;
    public GameObject dirt;
    public GameObject mud;

    public enum StepSound { Stone, Snow, Wood, Metal, Grass, Water, Dirt, Mud };

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

            case StepSound.Metal:
             {
                 int index = Random.Range(0, MetalStepSounds.Count - 1);
                 audioSource.clip = MetalStepSounds[index];
                 audioSource.Play();
                 //Debug.Log("This is METAL");
                 break;
             }

             case StepSound.Grass:
             {
                 int index = Random.Range(0, GrassStepSounds.Count - 1);
                 audioSource.clip = GrassStepSounds[index];
                 audioSource.Play();
                 //Debug.Log("This is GRASS");
                 break;
             }

            case StepSound.Water:
            {
                int index = Random.Range(0, WaterStepSounds.Count - 1);
                audioSource.clip = WaterStepSounds[index];
                audioSource.Play();
                //Debug.Log("This is WATER");
                break;
            }

            case StepSound.Dirt:
            {
                int index = Random.Range(0, DirtStepSounds.Count - 1);
                audioSource.clip = DirtStepSounds[index];
                audioSource.Play();
                //Debug.Log("This is DIRT");
                break;
            }

            case StepSound.Mud:
            {
                int index = Random.Range(0, MudStepSounds.Count - 1);
                audioSource.clip = MudStepSounds[index];
                audioSource.Play();
                //Debug.Log("This is MUD");
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
