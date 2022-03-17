using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private AudioSource jumpSound;

    [SerializeField]
    private TextMeshProUGUI coinText;

    [SerializeField]
    private Camera mainCamera;

    private int coinCount;
    private bool collectedCoin = false;

    private float speed = 8.0f;

    private float jumpTimer = 1.7f;

    private bool playerIsGrounded = true;
    private bool playerFacesRight = true;

    private Rigidbody2D rb;

    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coinCount = 0;
        setCoinText();

    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        RunningAnimation();

        //Left and Right movement
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);

        JumpAnimation();

    }

    private void JumpAnimation()
    {
        jumpTimer -= Time.deltaTime;
        if (jumpTimer <= 0.0f)
        {
            if (playerIsGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, speed);
                jumpTimer = 1.7f;
                playerIsGrounded = false;
                PlayJumpSound();
                animator.SetBool("IsJumping", true);
            }
        }
    }

    private void RunningAnimation()
    {
        var horizontalMove = Input.GetAxisRaw("Horizontal") * speed;

        if ((horizontalMove > 0 && !playerFacesRight) || (horizontalMove < 0 && playerFacesRight))
        {
            playerFacesRight = !playerFacesRight;
            transform.Rotate(new Vector3(0, 180, 0));
        }

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Platform") || collision.CompareTag("Ground") || collision.CompareTag("BrokenPlatform"))
        {
            playerIsGrounded = true;
            animator.SetBool("IsJumping", false);
        }

        if(collision.CompareTag("PickUp") && !collectedCoin)
        {
            coinCount++;
            collectedCoin = true;
            setCoinText();
        }
        else
        {
            collectedCoin = false;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Platform") || collision.CompareTag("Ground") || collision.CompareTag("BrokenPlatform"))
        {
            playerIsGrounded = false;
        }

    }

    private void PlayJumpSound()
    {
        jumpSound.Play();
    }

    private void setCoinText()
    {
        coinText.text = "x " + coinCount.ToString();
    }
}
