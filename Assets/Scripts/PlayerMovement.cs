using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerMovement : MonoBehaviour
{
	public CharacterController cc;
	public Transform groundCheck;
	public float groundDistance;
	public LayerMask groundMask;

	public float speed = 12f;
	public float gravity = -9.81f;
	public float jumpHeight = 3f;

	private Vector3 velocity;
	private bool isGrounded;
	
    void Update()
    {
	    isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

	    if (isGrounded && velocity.y < 0)
	    {
		    velocity.y = -2f;
	    }
	    
	    float x = Input.GetAxis("Horizontal");
	    float z = Input.GetAxis("Vertical");

	    Vector3 move = transform.right * x + transform.forward * z;

	    cc.Move(move * (speed * Time.deltaTime));

	    if (Input.GetButtonDown("Jump") && isGrounded)
	    {
		    Debug.Log("Jump");
		    velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
	    }

	    velocity.y += gravity * Time.deltaTime;
	    cc.Move(velocity * Time.deltaTime);
    }
}
