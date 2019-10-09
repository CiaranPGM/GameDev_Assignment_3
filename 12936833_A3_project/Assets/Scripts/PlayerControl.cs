using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator anim;
    public float MoveSpeed;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * MoveSpeed);
        if(movement.x == 1.0f)
        {
            anim.SetBool("MoveRight", true);
        }
        if(movement.x == -1.0f)
        {
            transform.rotation.Set(0,-180,0,0);
        }
        Debug.Log(movement);
    }

    void Update()
    {
        
    }
}
