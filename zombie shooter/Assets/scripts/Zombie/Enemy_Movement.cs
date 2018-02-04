using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour {

    [Header("Components")]

    [Space]

    public SpriteRenderer sr;

    public Rigidbody2D rb;

    public GameObject Player;


    [Header("Movement Values")]

    [Space]

    public float EnemySpeed;

    public float EnemyJumpHeight;


    public float AttackDistance;

    public bool canAttack;

    public int attackCooldownTime;

    public bool canJump;

    public int jumpCooldownTime;

    // Use this for initialization
    void Awake () {

        Player = GameObject.Find("Player");
		
	}
	
	// Update is called once per frame
	void Update () {

        //Attack
        if (Vector2.Distance(gameObject.transform.position, Player.transform.position) < AttackDistance) {
            
            if(canAttack == true) {

                Debug.Log("Attack");

                Player.GetComponent<Health>().currentHealth = Player.GetComponent<Health>().currentHealth - 1;

                StartCoroutine("AttackCooldown");

                canAttack = false;

            }

        }

        else {

            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, EnemySpeed * Time.deltaTime);

            if(Player.transform.position.x - transform.position.x >= 0) {

                sr.flipX = false;

            }

            else {

                sr.flipX = true;

            }


        }

    }


    public IEnumerator AttackCooldown () {

        yield return new WaitForSeconds(attackCooldownTime);

        canAttack = true;


    }



    //Detects collision of an obstacle, then jumps (BoxCollider2D Trigger on Enemy)
    public void OnTriggerEnter2D(Collider2D collision) {

        if (canJump == true && collision.gameObject.tag == "Obstacle") {

            canJump = false;

            rb.AddForce(Vector2.up * EnemyJumpHeight * 100, ForceMode2D.Force);

            StartCoroutine(JumpCooldown());

        }

    }

    public IEnumerator JumpCooldown() {

        yield return new WaitForSeconds(jumpCooldownTime);

        canJump = true;


    }
}
