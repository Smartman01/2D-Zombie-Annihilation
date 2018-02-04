
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HomingMissile : MonoBehaviour
{

    //public Transform target;

    private PlayerController control;

    public float speed = 5f;
    public float rotateSpeed = 200f;

    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (control.facingRight)
        {
            Vector2 direction = new Vector2(speed, 0) - rb.position;

            direction.Normalize();

            float rotateAmount = Vector3.Cross(direction, transform.up).z;

            rb.angularVelocity = -rotateAmount * rotateSpeed;

            rb.velocity = transform.up * speed;
        }
        else
        {
            Vector2 direction = new Vector2(-speed, 0) - rb.position;

            direction.Normalize();

            float rotateAmount = Vector3.Cross(direction, transform.up).z;

            rb.angularVelocity = -rotateAmount * rotateSpeed;

            rb.velocity = transform.up * speed;
        }


    }

    void OnTriggerEnter2D()
    {
        // Put a particle effect here
        Destroy(gameObject);
    }
}