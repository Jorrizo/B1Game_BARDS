using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour {

    float moveHorizontallyX = 0f;
    float moveHorizontallyZ = 0f;
    float moveVertically = 0f;
    public float horizontalSpeed = 2f;
    public float verticalSpeed = 500;
    private bool isJumping = false;
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetTrigger("player");
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
            anim.SetTrigger("mouvement");
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
            GetComponent<Rigidbody>().AddForce(Vector3.up * Time.deltaTime * verticalSpeed, ForceMode.Impulse);     
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
