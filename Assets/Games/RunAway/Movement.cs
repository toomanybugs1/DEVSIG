using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 10;
    public float rotateSpeed = 4;

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-Vector3.up * rotateSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * rotateSpeed);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Enemy>() != null)
            GameManager.LoseLevel();
    }
}
