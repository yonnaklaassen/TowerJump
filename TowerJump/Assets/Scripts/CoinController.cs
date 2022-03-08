using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinController : MonoBehaviour
{

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private float jumpHeight = 0.0f;

    [SerializeField]
    private AudioSource coinSound;

    private new Collider2D collider;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();

    }

    private void OnTriggerEnter2D(Collider2D collsion)
    {
        if (collsion.gameObject.CompareTag("Player"))
        {
            CoinJump(collsion);
            Destroy(gameObject, 5.0f);
        }
    }

    private void CoinJump(Collider2D collision)
    {
        coinSound.Play();
        rb.isKinematic = false;
        rb.AddForce(Vector3.up * jumpHeight, ForceMode2D.Impulse);

        Physics2D.IgnoreCollision(collision, collider);

    }
}
