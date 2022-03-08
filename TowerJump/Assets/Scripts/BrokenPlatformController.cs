using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenPlatformController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private AudioSource breakSound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            breakSound.Play();
            Invoke("DropPlatform", 4.0f);
            Destroy(gameObject, 8.0f);
        }

    }

    private void DropPlatform()
    {
        rb.isKinematic = false;
    }
}
