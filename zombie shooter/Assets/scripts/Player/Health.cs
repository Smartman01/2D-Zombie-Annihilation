using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Health : MonoBehaviour {

    //The box's current health point total
    public const int maxHealth = 100;
    public int currentHealth = maxHealth;
    public Text health;

	//DeathMenu
    public GameObject cam;
    //public GameObject Spawnmanager;
    public GameObject deathMenu;

	//PauseMenu
    public GameObject pauseMenu;
    bool pause = false;

    //public string level;

    public AudioSource healthAudioSource;
    public AudioClip heartBeat;
    public AudioClip[] h_clips;
    bool h_clipsBool = false;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        health.text = "Health: " + currentHealth;

        if(Input.GetKey(KeyCode.Tab) || Input.GetButton("PauseBtn") && pause == false)
        {
            Time.timeScale = 0;
            pause = true;
            pauseMenu.SetActive(true);
        }
        else if (pause == true && Input.GetKey(KeyCode.Escape) || Input.GetButton("backBtn"))
        {
            pause = false;
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }

        if(currentHealth < 100 && h_clipsBool == true)
        {
            int audioClipIndex = Random.Range(0, h_clips.Length);
            healthAudioSource.clip = h_clips[audioClipIndex];
            healthAudioSource.Play();
            h_clipsBool = false;
        }
    }

    public void Damage(int damageAmount)
    {
        //subtract damage amount when Damage function is called
        currentHealth -= damageAmount;

        h_clipsBool = true;

        if(currentHealth <= 30)
        {
            //h_clipsBool = false;
            healthAudioSource.clip = heartBeat;
            healthAudioSource.loop = true;
            healthAudioSource.Play();
        }

        healthAudioSource.loop = false;

        //ShootingScript1 shooting = transform.GetComponent<ShootingScript1>();
        //Check if health has fallen below zero
        if (currentHealth <= 0)
        {
            //shooting.kills += 1;
            //Destroy(gameObject);
            //if health has fallen below zero, deactivate it 
            cam.SetActive(true);
			GameManager.isSpawning = false;
		    GameManager.deaths++;
            deathMenu.SetActive(true);
            //Time.timeScale = 0;
            Destroy(this.gameObject);
            
            //SceneManager.LoadScene(level);
        }
    }
}
