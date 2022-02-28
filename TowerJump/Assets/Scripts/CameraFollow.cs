using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.0f;

    [SerializeField]
    private float cameraRiseTimer = 0.0f;

    private void Awake()
    {
       
    }

    void FixedUpdate()
    {
        cameraRiseTimer -= Time.deltaTime;
        if(cameraRiseTimer <= 0.0f)
        {
            Vector3 desiredPosition = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, 0.125f);
            transform.position = smoothedPosition;
            speed += 0.0002f;

            cameraRiseTimer = 0.01f;
        }

        Debug.Log("Speed: " + speed);
        Debug.Log("Timer: " + cameraRiseTimer);

    }

}
