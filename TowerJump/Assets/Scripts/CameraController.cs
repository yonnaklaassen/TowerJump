using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.0f;

    [SerializeField]
    private float cameraRiseTimer = 0.0f;

    private GameObject player;
    private float quitGameTimer = 10.0f;
    private bool gameOver = false;
    private bool soundPlayed = false;

    [SerializeField]
    private TextMeshProUGUI gameOverText;

    [SerializeField]
    private AudioSource gameOverSound;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameOverText.enabled = false;
    }

    void FixedUpdate()
    {
        if ((gameObject.transform.position.y - player.transform.position.y) > 5)
        {
            GameOver();
        }else
        {
            MoveCamera();
        }

    }

    private void GameOver()
    {
        gameOverText.enabled = true;
        gameOver = true;
        quitGameTimer -= Time.deltaTime;

        if(!soundPlayed)
        {
            gameOverSound.Play();
            soundPlayed = true;
        }

        if (quitGameTimer <= 0.0f && gameOver)
        {
            Debug.Log("QUIT");
            Application.Quit();
        }
    }

    private void MoveCamera()
    {
        cameraRiseTimer -= Time.deltaTime;
        if (cameraRiseTimer <= 0.0f && !gameOver)
        {
            Vector3 desiredPosition = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, 0.125f);
            transform.position = smoothedPosition;
            speed += 0.00016f;

            cameraRiseTimer = 0.01f;
        }
    }

}
