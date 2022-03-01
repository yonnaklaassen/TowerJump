using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenPlatformController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Invoke("DropPlatform", 8.0f);
            Destroy(gameObject, 4.0f);
        }

    }

    private void DropPlatform()
    {
        rb.isKinematic = false;
    }
}
