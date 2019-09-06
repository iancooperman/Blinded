using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Vector2 velocity = Vector2.zero;

    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Run every physics iteration
    void FixedUpdate()
    {
        PerformMovement();
    }

    // Gets a movement vector
    public void Move(Vector2 _velocity) {
        velocity = _velocity;
        
    }

    void PerformMovement() {
        if (velocity != Vector2.zero) {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }
}
