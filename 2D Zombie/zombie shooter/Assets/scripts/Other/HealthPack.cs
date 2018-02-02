using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        var hit = coll.gameObject;
        var hitplayer = hit.GetComponent<PlayerController>();
        if (hitplayer != null && hit.transform.tag == "Player")
        {
            var health = hit.GetComponent<Health>();
            Debug.Log("Health");
            health.currentHealth = 100;
            //Destroy(gameObject);
        }
        //Destroy(gameObject);
    }
}
