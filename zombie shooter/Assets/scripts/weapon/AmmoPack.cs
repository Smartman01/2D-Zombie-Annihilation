using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPack : MonoBehaviour {

    public int ammoPrice;

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
        if (hitplayer != null && hit.transform.tag == "Player" && Input.GetKeyUp("e") && GameManager.money >= ammoPrice)
        {
            GameManager.money -= ammoPrice;
            var ammo = hit.GetComponent<Shooting>();
            var grenade = hit.GetComponent<GrenadeThrower>();
            Debug.Log("Ammo");
            Debug.Log("Grenade");
            ammo.reserve = 200;
            grenade.grenadeClip = 3;
            //Destroy(gameObject);
        }
    }
}

