using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
   
    public List<string> inventory = new List<string>();

    public CharacterController controller;

    public GameObject inventoryUI;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public Image crosshair;

    Vector3 velocity;

    bool isGrounded;

    // Update is called once per frame
    void Update()
    {

        Inputs();

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }


        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);



    }
    public void Inputs()
    {
        if (Input.GetKey(KeyCode.I))
        {
            inventoryUI.SetActive(true);
            crosshair.gameObject.SetActive(false);
        }
        else
        {
            inventoryUI.SetActive(false);
            crosshair.gameObject.SetActive(true);
        }
    }
}
