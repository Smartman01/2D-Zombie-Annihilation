using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Grenade : MonoBehaviour {

    public float delay = 3f;
    public float blastRaduis = 5f;
    float countdown;

    bool hasExploded = false;

    public GameObject explosionEffect;

    public float force = 700f;

    public int damage;


    // Use this for initialization
    void Start () {
        countdown = delay;
	}
	
	// Update is called once per frame
	void Update () {
        countdown -= Time.deltaTime;
        if(countdown <= 0f && !hasExploded)
        {
            Explode();
            CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1f);
            hasExploded = true;
        }
	}

    void Explode()
    {
        //Effect
        Instantiate(explosionEffect, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));

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

    void OnCollisionEnter2D(Collision2D coll)
    {
        var hit = coll.gameObject;
        var hitplayer = hit.tag == "Enemy";
        
        if (hitplayer)
        {
            var Zomhealth = hit.GetComponent<ZombieHealth>();
            Rigidbody2D rb2d = hit.GetComponent<Rigidbody2D>();
            if (rb2d != null)
            {
                rb2d.AddForce(transform.position, ForceMode2D.Impulse);
                rb2d.AddTorque(force);
            }
            Debug.Log("hit by grenade");
            Zomhealth.ZomDamage(damage);
            Instantiate(explosionEffect, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1f);
            Destroy(gameObject);
        }

        /*if (coll.gameObject.tag == "Player" || coll.gameObject.tag == "Ground")
        {
            Physics2D.IgnoreCollision(coll.collider, coll.collider);
        }*/
    }
}

