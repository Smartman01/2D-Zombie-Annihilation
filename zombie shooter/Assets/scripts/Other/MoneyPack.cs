using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPack : MonoBehaviour {

	public int minMoneyValue;
	public int maxMoneyValue;

	// Use this for initialization
	void Start () {
		maxMoneyValue = 1000;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D coll)
	{
		var hit = coll.gameObject;
		var hitplayer = hit.GetComponent<PlayerController>();
		if (hitplayer != null && hit.transform.tag == "Player" && Input.GetKey("e") )
		{
			Debug.Log("money");
			GameManager.money += Random.Range(minMoneyValue, maxMoneyValue);
			Destroy(gameObject);
		}
		//Destroy(gameObject);
	}
}
