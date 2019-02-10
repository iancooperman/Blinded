using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{

    public float unitsPerKeypress = 1f;

    private Rigidbody rb;
    private SphereCollider c;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        c = GetComponent<SphereCollider>();
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

    void DetectObstacleAndMove(Vector3 direction) {

        float radius = c.radius * transform.lossyScale.x;


        // Designers must make sure walls and other obstacles are given the layer of obstacle.
        int ObstacleLayer = LayerMask.GetMask("Obstacle");

        RaycastHit hit = new RaycastHit();

        bool overlap = Physics.BoxCast(rb.position, Vector3.one * radius, direction, out hit, Quaternion.identity, unitsPerKeypress);

        // Debug.Log(overlap);

        if (!overlap) {
            rb.MovePosition(rb.position + direction * unitsPerKeypress);
        }

        
    }
}
