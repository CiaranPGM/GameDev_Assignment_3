using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    private Vector2 movement;
    public Vector2 direction = Vector2.zero;
    private float moveSpeed = 10f;
    Animator animator;
    public Transform portalDestinationBR, portalDestinationBL, portalDestinationTR, portalDestinationTL;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        ManageInput();
        Move();
        Rotate();
    }

    void ManageInput()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        if(movement != Vector2.zero)
        {
            animator.SetBool("isMoving", true);
        }
        else { animator.SetBool("isMoving", false); }
    }

    void Move()
    {
        if (movement.x == 1.0f)
        {
            movement.y = 0.0f;
            transform.localPosition += (Vector3)(movement * moveSpeed) * Time.deltaTime;
        }else if(movement.y == 1.0f)
        {
            movement.x = 0.0f;
            transform.localPosition += (Vector3)(movement * moveSpeed) * Time.deltaTime;
        }else if(movement.x == -1.0f)
        {
            movement.y = 0.0f;
            transform.localPosition += (Vector3)(movement * moveSpeed) * Time.deltaTime;
        }else if(movement.y == -1.0f)
        {
            movement.x = 0.0f;
            transform.localPosition += (Vector3)(movement * moveSpeed) * Time.deltaTime;
        }
    }

    void Rotate()
    {
        if(movement == Vector2.left)
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
        if(other.collider.gameObject.name == "Portal_Bottom_Right")
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
        Debug.Log(other.gameObject.name);
    }
}
