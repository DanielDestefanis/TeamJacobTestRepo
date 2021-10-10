using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{

    public float speed = 10.0f;
    public float jumpForce = 300.0f;
    public bool allowDoubleJump = false;
    private int amountOfJumps = 0;
    private float translation;
    private float straife;
    public float maxGroundDistance = 1.5f;
    private bool isGrounded;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void LateUpdate()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, maxGroundDistance);
        if (isGrounded == true)
        {
            amountOfJumps = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Input.GetAxis() is used to get the user's input
        // You can furthor set it on Unity. (Edit, Project Settings, Input)
        translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        straife = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(straife, 0, translation);

        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Vertical") != 0)
        {
            if (isGrounded)
            {
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            }
        }

        if (Input.GetKeyDown("escape"))
        {
            // turn on the cursor
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKeyDown("space"))
        {
            if (isGrounded)
            {
                GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, jumpForce, 0.0f));
                amountOfJumps = 1;
            }
            else if(amountOfJumps < 2 && allowDoubleJump)
            {
                GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, jumpForce, 0.0f));
                amountOfJumps = 2;
            }
        }

    }
}
