using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed;
    public float jumpforce;

    private bool isGrounded;
    private Vector3 jump;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0, 2f, 0);
    }

    private void OnCollisionStay()
    {
        isGrounded = true;
    }



    void Update()
    {
        float moveHorizontal = Input.GetAxis("Vertical");
        float moveVertical = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(-moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump * jumpforce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
}