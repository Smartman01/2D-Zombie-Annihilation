using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierZomDestroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        var hit = coll.gameObject;
        var hitplayer = hit.tag == "Enemy";

        if (hitplayer)
        {
            var Zomhealth = hit.GetComponent<ZombieHealth>();
            Debug.Log("hit by under barrier");
            Zomhealth.ZomDamage(1000);
        }
    }
}
