using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
	public Bullet bullet;

    public Health health;

	//Score
	public static int score;
	// The player's score.
	public Text scoreText;
    public Text highScoreText;
    public int hiScore;
    //string highScoreKey = "HighScore";
	// Reference to the Text component.
	public static int kills;
	public Text killText;
	
	//Money
	public static int money;
	public Text moneyText;
	public MoneyPack moneyPack;
	
	//ScoreStreaks
	public Image Shield;
	public Text shieldText;
	public GameObject shieldPrefab;
	public Image extraDamage;
	public Text extraDamageText;
	public GameObject extraDamagePrefab;
	public Image atomicBomb;
	public Text atomicBombText;
	public GameObject atomicBombPrefab;
    public Transform atomBombSpawn;

    //Rounds
    public Transform[] spawnPoints;
	public GameObject[] zombies;
    //public GameObject hellHound;
	//public GameObject bossZombie;
	public float spawnDelay;
	public static int zombieCounter;
	public int defaultSpawnNum;
	public int waveNum;
	public Text waveText;
	public static bool isSpawning = false;
	//public ZombieHealth[] zombieHealth;

	//Timer
	public float timer = 60.00f;
	public Text timerText;

    //Achievements
    public GameObject achievement_1;
    public GameObject achievement_2;
    public GameObject achievement_3;
    public GameObject achievement_4;
    public GameObject achievement_5;


    //PauseMenu

    //DeathMenu


    public float restartDelay = 5f;
    float restartTimer;

    void Awake ()
	{
        // Set up the reference.
        //text = GetComponent<Text>();
        Time.timeScale = 1;
        // Reset the score.
        score = 0;
        highScoreText.text = "High Score - " + PlayerPrefs.GetInt("HighScore", 0);
		money = 0;
		kills = PlayerPrefs.GetInt("Kills", 0);
		waveNum = 0;
		//timer = 60.0f;
		moneyPack.maxMoneyValue = 1000;
    }
	
	void Start ()
	{
        zombieCounter = 0;
        StartCoroutine (SpawnZombies (waveNum));
	}
	
	void Update ()
	{
		// Set the displayed text to be the word "Score" followed by the score value.
		scoreText.text = "Score - " + score;
        if(score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            hiScore = score;
            highScoreText.text = "High Score - " + hiScore;
        }
		moneyText.text = "- " + money;
        killText.text = "Kills - " + kills;
        PlayerPrefs.SetInt("Kills", kills);
		timerText.text = timer + "s";
		waveText.text = "Wave - " + waveNum;
		shieldText.text = "Z - " + money + "/10450$";
		extraDamageText.text = "X - " + money + "/15000$";
		atomicBombText.text = "C - " + money + "/1234567$";
		ScoreStreaks ();
        Achievements();
		if (zombieCounter >= 1)
		{
			timerText.text = "";
		}
		if (zombieCounter == 0 && !isSpawning) 
		{
			timer -= Time.deltaTime;
			if(timer <= 0)
			{
				UpdateWave ();
				defaultSpawnNum = (int)(defaultSpawnNum * 1.5);
				moneyPack.maxMoneyValue = (int)(moneyPack.maxMoneyValue * 1.5);
			}
			//int zombiesIndex = zombieHealth.Length;
			//zombieHealth[zombiesIndex].currentHealth = (int)(zombieHealth[zombiesIndex].currentHealth + 10);
			/*for (var i = 0; i < zombiesIndex; i++) 
			{
				//Debug.Log("add Health");
				zombies[zombiesIndex].GetComponent<ZombieHealth>().currentHealth += 10;
			}
			for (int i = 0, zombiesLength = zombies.Length; i < zombiesLength; i++) 
			{
				zombies[i].GetComponent<ZombieHealth>().currentHealth += 10;
			}*/
		}

        /*if(health.currentHealth <= 0)
        {
            // .. increment a timer to count up to restarting.
                restartTimer += Time.deltaTime;

                // .. if it reaches the restart delay...
                if (restartTimer >= restartDelay)
                {
                // .. then reload the currently loaded level.
                    SceneManager.LoadScene(1);
                }
            StopAllCoroutines();
        }*/

        if (Input.GetKey("l"))
        {
            PlayerPrefs.DeleteAll();
            killText.text = "0";
            kills = 0;
            highScoreText.text = "0";

            achievement_1.transform.Find("Lock").gameObject.SetActive(true);
            achievement_1.transform.Find("Checkmark").gameObject.SetActive(false);
            achievement_2.transform.Find("Lock (1)").gameObject.SetActive(true);
            achievement_2.transform.Find("Checkmark (1)").gameObject.SetActive(false);
            achievement_3.transform.Find("Lock (2)").gameObject.SetActive(true);
            achievement_3.transform.Find("Checkmark (2)").gameObject.SetActive(false);
            achievement_4.transform.Find("Lock (3)").gameObject.SetActive(true);
            achievement_4.transform.Find("Checkmark (3)").gameObject.SetActive(false);
            achievement_5.transform.Find("Lock (4)").gameObject.SetActive(true);
            achievement_5.transform.Find("Checkmark (4)").gameObject.SetActive(false);
        }
    }
	
	void ScoreStreaks ()
	{
		//Money for scorestreaks
		/*if (money >= 10450) 
		{
			shieldText.text = "Z - 10450/10450$";
			Shield.color = new Color32 (255, 255, 255, 255);
		}
        else
        {
            Shield.color = new Color32(255, 255, 255, 130);
        }*/
		if (money >= 15000) 
		{
			extraDamageText.text = "X - 15000/15000$";
			extraDamage.color = new Color32(255, 0, 0, 255);
		}
        else
        {
            extraDamage.color = new Color32(255, 0, 0, 130);
        }
        if (money >= 1234567) 
		{
			atomicBombText.text = "C - 1234567/1234567$";
			atomicBomb.color = new Color32 (255, 0, 0, 255);
		}
        else
        {
             atomicBomb.color = new Color32(255, 0, 0, 130);
        }

        //Activating && subtracting money
        //Shield
        /*if (Input.GetKeyDown (KeyCode.Z) && money >= 10450) 
		{
			money = (int)(money - 10450);
			StartCoroutine(ShieldSS());
		}*/
		//ExtraDamage
		if (Input.GetKeyDown (KeyCode.X) && money >= 258500) 
		{
			money = (int)(money - 258500);
			StartCoroutine(ExtraDam());
		}
		//AtomicBomb
		if(Input.GetKeyDown(KeyCode.C) && money >= 1234567) 
		{
			money = (int)(money - 1234567);
            Instantiate(atomicBombPrefab, atomBombSpawn.position, transform.rotation);
		}
	}
	
	public IEnumerator SpawnZombies (int wave)
	{
		int spawnNum = (defaultSpawnNum + 5 * (wave - 1));
		isSpawning = true;
		for (int i = 0; i < spawnNum; i++) {
			yield return new WaitForSeconds (spawnDelay);
			int spawnPointsIndex = Random.Range (0, spawnPoints.Length);
			int zombiesIndex = Random.Range (0, zombies.Length);
			Instantiate (zombies [zombiesIndex], spawnPoints [spawnPointsIndex].position, spawnPoints [spawnPointsIndex].rotation);
			/*if(waveNum % 10 == 0)
			{
				Instantiate (bossZombie, spawnPoints [spawnPointsIndex].position, spawnPoints [spawnPointsIndex].rotation);
                waveNum += 1;
			}
            if(waveNum % 5 == 0)
            {
                Instantiate(zombies[2], spawnPoints[spawnPointsIndex].position, spawnPoints[spawnPointsIndex].rotation);
            }*/
			zombieCounter++;
		}
		isSpawning = false;
	}
	
	public void UpdateWave ()
	{
		timer = 60f;
		waveNum++;
		StartCoroutine (SpawnZombies (waveNum));
	}

	/*IEnumerator ShieldSS () 
	{
		shieldPrefab.SetActive (true);
		yield return new WaitForSeconds (60);
		shieldPrefab.SetActive (false);
		StopCoroutine (ShieldSS ());
	}*/

	IEnumerator ExtraDam () 
	{
		bullet.damage = 1000;
		yield return new WaitForSeconds (60);
		bullet.damage = 10;
		StopCoroutine (ExtraDam ());
	}

    void Achievements()
    {
        PlayerPrefs.Save();
        if(kills == 1)
        {
            achievement_1.transform.Find("Lock").gameObject.SetActive(false);
            achievement_1.transform.Find("Checkmark").gameObject.SetActive(true);
        }
        if (kills == 50)
        {
            achievement_2.transform.Find("Lock (1)").gameObject.SetActive(false);
            achievement_2.transform.Find("Checkmark (1)").gameObject.SetActive(true);
        }
        if (kills == 1000)
        {
            achievement_3.transform.Find("Lock (2)").gameObject.SetActive(false);
            achievement_3.transform.Find("Checkmark (2)").gameObject.SetActive(true);
        }
        if (waveNum == 10)
        {
            achievement_4.transform.Find("Lock (3)").gameObject.SetActive(false);
            achievement_4.transform.Find("Checkmark (3)").gameObject.SetActive(true);
        }
        if (waveNum == 50)
        {
            achievement_5.transform.Find("Lock (4)").gameObject.SetActive(false);
            achievement_5.transform.Find("Checkmark (4)").gameObject.SetActive(true);
        }
    }
}
