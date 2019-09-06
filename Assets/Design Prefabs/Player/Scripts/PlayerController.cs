using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 5f;

    private PlayerMovement movement;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate movement velocity as a 2D vector
        float _xMovement = Input.GetAxisRaw("Horizontal");
        float _yMovement = Input.GetAxisRaw("Vertical");

        Vector2 _moveHorizontal = Vector2.right * _xMovement;
        Vector2 _moveVertical = Vector2.up * _yMovement;

        // Final movement vector
        Vector2 _velocity = (_moveHorizontal + _moveVertical).normalized * speed;
        movement.Move(_velocity);

    }
}
