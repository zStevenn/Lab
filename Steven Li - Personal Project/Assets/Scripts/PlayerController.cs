using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Public floats
    public float horizontalInput;
    public float speed = 20.0f;
    public float xRange = 14.0f;
    private Rigidbody playerRb;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            RestrictMovement();
            MovePlayer();
        }

    }

    void RestrictMovement()
    {
        // Makes player not being able to walk off the screen left or right.
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
    }

    void MovePlayer()
    {
        // Makes player able to move left or right using a+d or left and right arrow key
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(speed * horizontalInput * Time.deltaTime * Vector3.right);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Junkfood"))
        {
            gameManager.GameOver();
        }
    }
}
