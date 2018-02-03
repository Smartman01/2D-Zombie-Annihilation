using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrenadeThrower : MonoBehaviour {

    public GameObject grenadePrefab;

    public float throwForce;

    public int grenadeClip;

    public Text grenadeAmmo;

    public Transform bommSpawn;

    PlayerController control;

    // Use this for initialization
    void Start () {
        control = transform.root.GetComponent<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
        grenadeAmmo.text = grenadeClip.ToString();
        if (Input.GetKeyDown("f") && grenadeClip > 0)
        {
            grenadeClip -= 1;
            ThrowGrenade();
        }
	}

    void ThrowGrenade()
    {
        if (control.facingRight)
        {
            GameObject grenade = Instantiate(grenadePrefab, bommSpawn.position, transform.rotation);
            Rigidbody2D rb2d = grenade.GetComponent<Rigidbody2D>();
            rb2d.AddForce(transform.right * throwForce);
        }
        else
        {
            GameObject grenade = Instantiate(grenadePrefab, bommSpawn.position, transform.rotation);
            Rigidbody2D rb2d = grenade.GetComponent<Rigidbody2D>();
            rb2d.AddForce(-transform.right * throwForce);
        }

        
    }
}