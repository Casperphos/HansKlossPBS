using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float speed = 2f;
    public bool isHorizontal;
    public bool hitTrigger;
    public bool isMovingUp;

    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    // wertykalnie
    void FixedUpdate()
    {
        if (isHorizontal)
        {
            //W górê
            if (isMovingUp && !hitTrigger)
            {
                rb.velocity = Vector2.up * speed;
            }

            //w dó³
            if (!isMovingUp && !hitTrigger)
            {
                rb.velocity = Vector2.down * speed;
            }
            
                
        }

    }
    void Turn()
    {
        isMovingUp = !isMovingUp;
        hitTrigger = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        hitTrigger = true;
        rb.velocity = Vector2.zero;
        Invoke("Turn", 5);
    }
}
