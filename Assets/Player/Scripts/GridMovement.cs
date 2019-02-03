using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{

    public float unitsPerKeypress = 2f;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move() {
        if (Input.GetKeyDown("w")) {
            // See if there is anything blocking total movement requested.
            RaycastHit2D hit = Physics2D.Raycast(rb.position, Vector2.up, unitsPerKeypress);

            // Move only if there is nothing in the way. Same for other if statements.
            if (hit.collider == null) {
                rb.MovePosition(rb.position + Vector2.up * unitsPerKeypress);
            }
        }

        if (Input.GetKeyDown("a")) {
            // See if there is anything blocking total movement requested.
            RaycastHit2D hit = Physics2D.Raycast(rb.position, Vector2.left, unitsPerKeypress);
            
            // Move only if there is nothing in the way. Same for other if statements.
            if (hit.collider == null) {
                rb.MovePosition(rb.position + Vector2.left * unitsPerKeypress);
            }
        }

        if (Input.GetKeyDown("s")) {
            // See if there is anything blocking total movement requested.
            RaycastHit2D hit = Physics2D.Raycast(rb.position, Vector2.down, unitsPerKeypress);

            // Move only if there is nothing in the way. Same for other if statements.
            if (hit.collider == null) {
                rb.MovePosition(rb.position + Vector2.down * unitsPerKeypress);
            }
        }

        if (Input.GetKeyDown("d")) {
            // See if there is anything blocking total movement requested.
            RaycastHit2D hit = Physics2D.Raycast(rb.position, Vector2.right, unitsPerKeypress);

            // Move only if there is nothing in the way. Same for other if statements.
            if (hit.collider == null) {
                rb.MovePosition(rb.position + Vector2.right * unitsPerKeypress);
            }
        }
    }
}
