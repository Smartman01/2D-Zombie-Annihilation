using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDamage : MonoBehaviour {

    public int damage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        var hit = coll.gameObject;
        var hitplayer = hit.GetComponent<PlayerController>();
        if (hitplayer != null)
        {
            var health = hit.GetComponent<Health>();
            Debug.Log("ZombieHit");
            health.Damage(damage);
            //Destroy(gameObject);
        }
    }
}
