using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [HideInInspector]
    public bool facingRight = true;
    [HideInInspector]
    public bool jump = false;
    public float moveForce = 365f;
    public float Speed = 5f;
    public float maxSpeed;
    public float jumpForce = 1000f;
    public Transform groundCheck;


    private bool grounded = false;
    private Animator anim;
    private Rigidbody2D rb2d;

    //public int score;


    // Use this for initialization
    void Awake()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if ((Input.GetButtonDown("Jump") || Input.GetButtonDown("AButton")) && grounded)
        {
            jump = true;
            //anim.SetFloat("Jump", jumpForce);
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed_run", rb2d.velocity.x);
        

        if (h * rb2d.velocity.x < Speed)
            rb2d.AddForce(Vector2.right * h * moveForce);

        if (Mathf.Abs(rb2d.velocity.x) > Speed)
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * Speed, rb2d.velocity.y);

        if (h > 0 && !facingRight)
        {
            Flip();
        }
        else if (h < 0 && facingRight)
            Flip();

        if(!facingRight)
            anim.SetFloat("Speed_run", -rb2d.velocity.x);

        if (jump == true)
        {
            //anim.SetFloat("Jump", rb2d.velocity.y);
            //grounded = false;
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;
            //anim.SetBool("Jump", grounded);
        }

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetButton("LSBtn"))
        {
            Speed = maxSpeed;
        }
        else
        {
            Speed = 5;
        }
    }


    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
