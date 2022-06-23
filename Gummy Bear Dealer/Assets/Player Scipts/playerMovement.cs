using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 5f;
    public float sprint = 10f;
    private float realSpeed;
    Vector3 velocity;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    public GameObject enduranceBar;

    public float jumpHeight = 3f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded&&velocity.y<0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if(Input.GetKey(KeyCode.LeftShift))
        {
            realSpeed = sprint;
            Invoke("RemoveEndurance", 1);
        }
        else
        {
            realSpeed = speed;
            Invoke("AddEndurance", 2);
        }
     
        controller.Move(move*realSpeed*Time.deltaTime);

        if(Input.GetButtonDown("Jump")&&isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity*Time.deltaTime);
    }
    private void FixedUpdate()
    {
        transform.Translate(realSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, realSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
    }
    private void  RemoveEndurance()
    {
        enduranceBar.GetComponent<Slider>().value -= 1;
        if (enduranceBar.GetComponent<Slider>().value == 0)
        {
            realSpeed = speed;
        }
    }
    private void AddEndurance()
    {
        enduranceBar.GetComponent<Slider>().value += 1;
    }
  
}
