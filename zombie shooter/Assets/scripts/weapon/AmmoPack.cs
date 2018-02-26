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
        var ammo = hit.GetComponent<Shooting>();
        var grenade = hit.GetComponent<GrenadeThrower>();
        if (hitplayer != null && hit.transform.tag == "Player" && (Input.GetKeyUp("e") || Input.GetButtonUp("BButton")) 
            && GameManager.money >= ammoPrice && (ammo.reserve < 200 || grenade.grenadeClip < 3))
        {
            GameManager.money -= ammoPrice;
            ammo.reserve = 200;
            grenade.grenadeClip = 3;
            Debug.Log("Ammo");
            Debug.Log("Grenade");
            //Destroy(gameObject);
        }
    }
}

