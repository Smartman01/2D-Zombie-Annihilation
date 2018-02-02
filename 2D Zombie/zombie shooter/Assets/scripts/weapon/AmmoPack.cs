using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPack : MonoBehaviour {

    //public int ammoPrice;

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
            var ammo = hit.GetComponent<Shooting>();
            Debug.Log("Ammo");
            ammo.reserve = 200;
            //Destroy(gameObject);
        }
    }
}

