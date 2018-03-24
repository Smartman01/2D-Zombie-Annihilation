using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieHealth : MonoBehaviour {
	
	//The box's current health point total
	//static int addHealth = 0;
	static int maxHealth = 100;
	public int currentHealth = maxHealth /*+ addHealth*/;

	public int scoreValue = 10;
	
	public GameObject money;
	public Transform moneySpawn;

    bool healthBool = true;

    private Animator anim;

    //public GameManager gameManager;

    //public bool hellHound;

    //public Health health;

    public GameObject Player;

    void Start()
    {
        anim = GetComponent<Animator>();

        //maxHealth = 100;

        Player = GameObject.Find("Player");

        currentHealth = maxHealth /*+ addHealth*/;

        if (maxHealth == 200)
        {
            healthBool = false;
        }

        if (GameManager.waveNum > 1 && healthBool == true)
        {
            for(var i = 0; i <  GameManager.waveNum; i++)
            {
                maxHealth = 100 + GameManager.waveNum * 5;
                Debug.Log(" adding health is working");
            }
        }
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

            anim.SetTrigger("Dead");

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
