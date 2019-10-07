using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    private Vector2 movement;
    public Vector3 lookVector;
    private float moveSpeed = 0.1f;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GetMovementInput();
        ManageInput();
        CharacterRotation();
        CharacterPosition();
    }

    void GetMovementInput()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        Debug.Log(movement);
    }

    void ManageInput()
    {
        //'d' movement
        if (movement.x == 1.0f)
        {
            lookVector.z = 90f;
            animator.SetBool("MoveRight", true);
        }
        else if(movement.x < 1.0f){
            lookVector.z = 0f;
            animator.SetBool("MoveRight", false);
        }

        //'a' movement
        if(movement.x == -1.0f)
        {
            lookVector.z = -90f;
        }

        //'w' movement
        if(movement.y == 1.0f)
        {
            lookVector.z = -180f;
        }
    }

    void CharacterRotation()
    {
        Vector2 zero = new Vector2(0,0);
        if(movement != zero)
        {
            transform.rotation = Quaternion.LookRotation(lookVector);

            //gameObject.transform.rotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0,0,90f));

            //gameObject.transform.parent.eulerAngles = new Vector3(0, 0, 90);
        }
    }

    void CharacterPosition()
    {
        gameObject.transform.Translate(movement * moveSpeed, Space.World);
    }
}
