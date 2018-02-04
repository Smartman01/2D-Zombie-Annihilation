﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieHealth : MonoBehaviour {
	
	//The box's current health point total
	const int maxHealth = 100;
	public int currentHealth = maxHealth;

	public int scoreValue = 10;
	
	public GameObject money;
	public Transform moneySpawn;

    //public GameManager gameManager;

    //public bool hellHound;

    //public Health health;

    public GameObject Player;

    void Start()
	{
        Player = GameObject.Find("Player");
        currentHealth = maxHealth;
	}
	
	void Update()
	{
		//if (GameManager.zombieCounter == 0) 
		//{
			//currentHealth = (int)(currentHealth + 10);
		//}

        /*if(Player.GetComponent<Health>().currentHealth <= 0)
        {
            Destroy(gameObject);
            GameManager.zombieCounter--;
        }*/
	}
	
	public void ZomDamage(int ZomdamageAmount)
	{
		//subtract damage amount when Damage function is called
		currentHealth -= ZomdamageAmount;

		//Check if health has fallen below zero
		if (currentHealth <= 0)
		{
			currentHealth = 0;
			//shooting.kills += 1;
			//Destroy(gameObject);
			//if health has fallen below zero, deactivate it 
            //if(hellHound == false)
            Instantiate(money, moneySpawn.position, transform.rotation);

			GameManager.score += scoreValue;
			GameManager.kills++;
			GameManager.zombieCounter--;
			Destroy(this.gameObject);
			currentHealth = maxHealth;
		}
	}
}