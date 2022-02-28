using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private float speed = 8.0f;

    private float jumpTimer = 1.7f;

    private bool playerIsGrounded = true;

    private Rigidbody2D rb;

    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);

        jumpTimer -= Time.deltaTime;
        if (jumpTimer <= 0.0f)
        {
            if (playerIsGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, speed);
                jumpTimer = 1.7f;
                playerIsGrounded = false;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Platform") || collision.CompareTag("Ground") || collision.CompareTag("BrokenPlatform"))
        {
            playerIsGrounded = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Platform") || collision.CompareTag("Ground") || collision.CompareTag("BrokenPlatform"))
        {
            playerIsGrounded = false;
        }

    }
}
