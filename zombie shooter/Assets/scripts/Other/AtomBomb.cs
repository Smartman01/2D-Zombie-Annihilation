using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomBomb : MonoBehaviour {

    public float delay = 3f;
    public float blastRaduis = 5f;
    float countdown;

    bool hasExploded = false;

    public GameObject explosionEffect;

    public float force = 700f;

    public int damage;

    GameObject[] zombies1;

    // Use this for initialization
    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

    void Explode()
    {
        //Effect
        Instantiate(explosionEffect, transform.position, transform.rotation);

        //Force & Damage
        /*Collider[] colliders = Physics.OverlapSphere(transform.position, blastRaduis);
        foreach(Collider nearbyObject in colliders)
        {
            Rigidbody2D rb2d = nearbyObject.GetComponent<Rigidbody2D>();
            if(rb2d != null)
            {
                rb2d.AddForce(transform.position, ForceMode2D.Impulse);
                rb2d.AddTorque(force);
            }

            ZombieHealth Zomhealth = nearbyObject.GetComponent<ZombieHealth>();
            if(Zomhealth != null)
            {
                Debug.Log("hit by grenade");
                Zomhealth.ZomDamage(damage);
            }

        }*/

        //Remove grenade
        Destroy(gameObject);
    }

    /*void OnTriggerEnter2D(Collider2D coll)
    {
        var hit = coll.gameObject;
        var hitplayer = hit.tag = "Enemy";

        if (hitplayer != null)
        {
            var Zomhealth = hit.GetComponent<ZombieHealth>();
            Rigidbody2D rb2d = hit.GetComponent<Rigidbody2D>();
            if (rb2d != null && hitplayer != null)
            {
                rb2d.AddForce(transform.position, ForceMode2D.Impulse);
                rb2d.AddTorque(force);
            }
            Debug.Log("hit by atom");
            Zomhealth.ZomDamage(damage);
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }*/

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(countdown <= 0.5f)
        {
            var hit = coll.gameObject;
            var hitplayer = hit.tag = "atomGround";

            if (hitplayer != null)
            {
            
                Rigidbody2D rb2d = hit.GetComponent<Rigidbody2D>();
                if (rb2d != null && hitplayer != null)
                {
                    rb2d.AddForce(transform.position, ForceMode2D.Impulse);
                    rb2d.AddTorque(force);
                }

                if(zombies1 == null)
                {
                    zombies1 = GameObject.FindGameObjectsWithTag("Enemy");
                }
                for(var i = 0; i < zombies1.Length; i++)
                {
                    zombies1[i].GetComponent<ZombieHealth>().ZomDamage(damage);
                    Debug.Log("hit by atom");
                }
            
                Instantiate(explosionEffect, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}
