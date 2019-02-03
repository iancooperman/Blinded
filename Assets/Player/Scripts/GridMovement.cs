using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{

    public float unitsPerKeypress = 1f;

    private Rigidbody2D rb;
    private CircleCollider2D c;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        c = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move() {
        if (Input.GetKeyDown("w")) {
            DetectObstacleAndMove(Vector2.up);
        }

        if (Input.GetKeyDown("a")) {
            DetectObstacleAndMove(Vector2.left);
        }

        if (Input.GetKeyDown("s")) {
            DetectObstacleAndMove(Vector2.down);
        }

        if (Input.GetKeyDown("d")) {
            DetectObstacleAndMove(Vector2.right);
        }
    }

    void DetectObstacleAndMove(Vector2 direction) {
        // // See if there is anything blocking total movement requested.
        // RaycastHit2D hit = Physics2D.Raycast(rb.position, direction);

        // // Calculate the diameter of the player
        // float diameter = 2 * c.radius * transform.lossyScale.x;
        // float radius = c.radius * transform.lossyScale.x;

        // Debug.Log(Mathf.Abs(hit.distance - radius));
        // Debug.Log(unitsPerKeypress);

        

        // // Move only if there is nothing in the way (the player would logically fit where it's trying to move). Same for other if statements.
        // if (hit.collider != null) {
        //     if (Mathf.Abs(hit.distance - radius) > unitsPerKeypress) {
        //         rb.MovePosition(rb.position + direction * unitsPerKeypress);
        //     }
        // }

        // else {
        //     // What if there's an obstacle that isn't directly in front of the center of the player?
        //     Collider2D colliderCircle = Physics2D.OverlapCircle(rb.position + direction * unitsPerKeypress, radius);

        //     if (colliderCircle == null) {
        //         rb.MovePosition(rb.position + direction * unitsPerKeypress);
        //     }

        // }

        float radius = c.radius * transform.lossyScale.x;

        Vector2 pointA = rb.position + (direction * radius) + (Vector2.Perpendicular(direction) * radius);
        Vector2 pointB = rb.position + (direction * (unitsPerKeypress + radius)) + (-Vector2.Perpendicular(direction) * radius);

        // Designers must make sure walls and other obstacles are given the layer of obstacle.
        int ObstacleLayer = LayerMask.GetMask("Obstacle");

        Collider2D overlap = Physics2D.OverlapArea(pointA, pointB, ObstacleLayer);

        Debug.Log(overlap);

        if (overlap == null) {
            rb.MovePosition(rb.position + direction * unitsPerKeypress);
        }

        
    }
}
