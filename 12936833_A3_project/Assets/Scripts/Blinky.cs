using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinky : MonoBehaviour
{
    private float moveSpeed = 3.5f;

    private GameObject msPacMan;

    public Transform[] waypoints;
    int current = 0;
    Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetFloat("DirX", 0);
        anim.SetFloat("DirY", 0);
    }

    //void FixedUpdate()
    //{
    //    if(transform.position != waypoints[current].position)
    //    {
    //        Vector2 p = Vector2.MoveTowards(transform.position, waypoints[current].position, moveSpeed);
    //        GetComponent<Rigidbody2D>().MovePosition(p);
    //    }
    //    else { current = (current + 1) % waypoints.Length; }
    //}

    void Update()
    {
        
    }
}
