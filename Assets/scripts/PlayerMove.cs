using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    private CharacterController controller;
    private Vector3 moveVector;
    private float verticalVelocity;
    private float gravity = 12.0f;
    private float animationDuration = 2.0f;
    private bool isDead = false;
    private float startTime;
    public float speed = 5.0f;


	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (isDead)
            return;
        if(Time.time-startTime < animationDuration)
        {
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }
        moveVector = Vector3.zero;

        if (controller.isGrounded)
        {
            verticalVelocity = -0.5f;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
        moveVector.y = verticalVelocity;
        moveVector.z = speed;
        controller.Move(moveVector * Time.deltaTime );
	}

    public void SetSpeed(float s)
    {
        speed =speed + s;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.point.z >transform.position.z +controller.radius/2 && hit.gameObject.tag =="Block" )
        {
            Death();
        }
        if (hit.gameObject.tag.Equals("Finish"))
        {
            Death();
        }
    }
    private void Death()
    {
        isDead = true;
        GetComponent<Score>().onDeath();
        
    }
}
