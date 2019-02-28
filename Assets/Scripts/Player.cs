using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    float moveHorizontallyX = 0f;
    float moveHorizontallyZ = 0f;
    float moveVertically = 0f;
    float horizontalSpeed = 2f;
    private float verticalSpeed = 500;
    private bool isJumping = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ProcessImput();

        Move();
    }

    void ProcessImput()
    {
        moveHorizontallyX = 0f;
        moveHorizontallyZ = 0f;
        moveVertically = 0f;

        if (Input.GetKey(KeyCode.Z))
        {
            moveHorizontallyZ += 1f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveHorizontallyZ -= 1f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveHorizontallyX += 1f;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            moveHorizontallyX -= 1f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * Time.deltaTime * verticalSpeed, ForceMode.Impulse);     // ya un ptit souss quand il saute parfois il saute plus haut bizous ♥
        }

    }

    void Move()
    {
        Vector3 newPosition = Vector3.zero;
        newPosition.x = transform.position.x + moveHorizontallyX * horizontalSpeed * Time.deltaTime;
        newPosition.y = transform.position.y + moveVertically * verticalSpeed * Time.deltaTime;
        newPosition.z = transform.position.z + moveHorizontallyZ * horizontalSpeed * Time.deltaTime;
        transform.position = newPosition;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }
}
