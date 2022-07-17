using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{   
    Rigidbody2D rb;
    float speed;
    float jump;
    bool CanJump = false;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        speed = 10f;
        jump = 8f;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Ground")
        { 
            CanJump = true;
            animator.SetBool("Jump",false);

        }

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 temp = rb.velocity;
        if (CanJump && Input.GetKeyDown(KeyCode.Space))
        {
                temp.y = jump;
                CanJump = false;  //jump once code  
                animator.SetBool("Jump", true);
                
        }

        temp.x = Input.GetAxis("Horizontal") * speed;
        rb.velocity= temp;
        //rb.velocity = new Vector2(Input.GetAxis("Horizontal" * speed, 0f));
    }

    
}
