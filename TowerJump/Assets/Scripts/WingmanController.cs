using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingmanController : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.0f;

    [SerializeField]
    private float height = 0.0f;
    private Vector2 position;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var newY = Mathf.Sin(Time.time * speed) * height + position.y;
        transform.position = new Vector2(transform.position.x, newY);
    }
}
