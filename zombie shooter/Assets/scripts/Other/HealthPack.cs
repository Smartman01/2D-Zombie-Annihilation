using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour {

    public int healthPrice;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay2D(Collider2D coll)
    {
        var hit = coll.gameObject;
        var hitplayer = hit.GetComponent<PlayerController>();
        if (hitplayer != null && hit.transform.tag == "Player" && Input.GetKeyUp("e") && GameManager.money >= healthPrice)
        {
            GameManager.money -= healthPrice;
            var health = hit.GetComponent<Health>();
            Debug.Log("Health");
            health.currentHealth = 100;
            //Destroy(gameObject);
        }
        //Destroy(gameObject);
    }
}
