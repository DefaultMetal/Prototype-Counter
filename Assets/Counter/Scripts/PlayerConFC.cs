using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConFC : MonoBehaviour
{
    public float horizontalInput;
    public float playerSpeed = 15;
    public float xRange = 10.5f;

    public GameObject juciePrefab;
    private GameManager gameManager;


    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (gameManager.isGameActive)
        {
            //lock the player within bounds
            if (transform.position.x < -xRange)
            {
                transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
            }

            if (transform.position.x > xRange)
            {
                transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
            }
            //move player horizontally
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * playerSpeed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fruit"))
        {
            Instantiate(juciePrefab, transform.position, transform.rotation);
        }
    }
}


