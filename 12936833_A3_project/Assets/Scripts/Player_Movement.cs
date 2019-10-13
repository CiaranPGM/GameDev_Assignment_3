using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player_Movement : MonoBehaviour
{
    private Vector2 movement;
    private float moveSpeed = 10f;

    Animator animator;

    public Transform portalDestinationBR, portalDestinationBL, portalDestinationTR, portalDestinationTL;

    public bool isStopped;

    private enum Direction { Right, Left, Up, Down, Stop}
    private Direction currentDirection;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        currentDirection = Direction.Stop;
    }

    void FixedUpdate()
    {
        //RaycastHit2D hit = Physics2D.Raycast(transform.localPosition, Vector3.right);
        //if(hit.collider.tag == "Wall")
        //{
        //    Debug.Log("here");
        //}
    }

    void Update()
    {
        ManageInput();
        Move();
        Rotate();
    }

    void ManageInput()
    {
        //Adds the inputs to a vector variable
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        //Turns on the animation when the player is moving
        if(movement != Vector2.zero)
        {
            animator.SetBool("isMoving", true);
        }
        else { animator.SetBool("isMoving", false); }

        //Checks which direction player is moving
        if (movement.x == 1.0f )
        {
            currentDirection = Direction.Right;
        }
        if (movement.y == 1.0f)
        {
            currentDirection = Direction.Up;
        }
        else if (movement.x == -1.0f)
        {
            currentDirection = Direction.Left;
        }
        else if (movement.y == -1.0f)
        {
            currentDirection = Direction.Down;
        }else if(movement == Vector2.zero)
        {
            currentDirection = Direction.Stop;
        }
    }

    void Move()
    {
        //Moves the players local position based on their input
        if (currentDirection == Direction.Right && !isStopped)
        {
            movement.y = 0.0f;
            transform.localPosition += (Vector3)(movement * moveSpeed) * Time.deltaTime;
        }
        else if (currentDirection == Direction.Up && isStopped == false)
        {
            movement.x = 0.0f;
            transform.localPosition += (Vector3)(movement * moveSpeed) * Time.deltaTime;
        }
        else if (currentDirection == Direction.Left && isStopped == false)
        {
            movement.y = 0.0f;
            transform.localPosition += (Vector3)(movement * moveSpeed) * Time.deltaTime;
        }
        else if (currentDirection == Direction.Down && isStopped == false)
        {
            movement.x = 0.0f;
            transform.localPosition += (Vector3)(movement * moveSpeed) * Time.deltaTime;
        }else if(currentDirection == Direction.Stop)
        {
            
        }
        
    }

    void Rotate()
    {
        //Rotates the player based on their input
        if (movement == Vector2.left)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            transform.localRotation = Quaternion.Euler(0, 0, 0);

        }
        else if(movement == Vector2.right)
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (movement == Vector2.up)
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.localRotation = Quaternion.Euler(0, 0, 90);
        }
        else if (movement == Vector2.down)
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.localRotation = Quaternion.Euler(0, 0, 270);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //Checks for map collision
        if (other.collider.tag == "Map")
        {
            transform.localPosition -= (Vector3)(movement / 2f);
            isStopped = true;
        }
        else { isStopped = false; }
        isStopped = false;

        //Checks portal collision for teleportation
        if (other.collider.gameObject.name == "Portal_Bottom_Right")
        {
            transform.position = portalDestinationBL.position + new Vector3(1.5f,0);
        }else if (other.collider.gameObject.name == "Portal_Bottom_Left")
        {
            transform.position = portalDestinationBR.position - new Vector3(1.5f, 0);
        }
        else if (other.collider.gameObject.name == "Portal_Top_Right")
        {
            transform.position = portalDestinationTL.position + new Vector3(1.5f, 0);
        }
        else if (other.collider.gameObject.name == "Portal_Top_Left")
        {
            transform.position = portalDestinationTR.position - new Vector3(1.5f, 0);
        }

    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Map")
        {
            isStopped = false;
        }
    }
}
