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
    bool moneyNumBool = true;
	
	//ScoreStreaks
	public Image Shield;
	public Text shieldText;
	public Text shieldTimer;
    public float sDTimer = 60.00f;
    bool shieldBool = false;
	public Image extraDamage;
	public Text extraDamageText;
	public Text extraDamageTimer;
    public float eDTimer = 60.00f;
    public static bool eDBool = false;
	public Image atomicBomb;
	public Text atomicBombText;
	public GameObject atomicBombPrefab;
    public Transform atomBombSpawn;
    GameObject[] zombie_1;

    //Rounds
    public Transform[] spawnPoints;
	public GameObject[] zombies;
    //public GameObject hellHound;
	//public GameObject bossZombie;
	public float spawnDelay;
	public static int zombieCounter;
	public int defaultSpawnNum;
	public static int waveNum;
	public Text waveText;
	public static bool isSpawning = false;
    //public ZombieHealth[] zombieHealth;
    //GameObject[] zombiesAddHealth;
    bool zomNumBool = true;

    //Timer
    public float timer = 60.00f;
	public Text timerText;

    //Achievements
    public GameObject achievement_1;
    public GameObject achievement_2;
    public GameObject achievement_3;
    public GameObject achievement_4;
    public GameObject achievement_5;


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
		timerText.text = Mathf.Round(timer) + "s";
		extraDamageTimer.text = Mathf.Round(eDTimer) + "s";
		shieldTimer.text = Mathf.Round(sDTimer) + "s";
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

        if(defaultSpawnNum == 200)
        {
            zomNumBool = false;
        }

        if(moneyPack.maxMoneyValue == 5000) 
        {
            moneyNumBool = false;
        }

		if (zombieCounter == 0 && !isSpawning) 
		{
			timer -= Time.deltaTime;
			if(timer <= 0)
			{
				UpdateWave ();
                if(zomNumBool)
                {
                    defaultSpawnNum = (int)(defaultSpawnNum * 1.5);
                    Debug.Log("zomNum is inc");
                }
                if(moneyNumBool)
                {
                    moneyPack.maxMoneyValue = (int)(moneyPack.maxMoneyValue * 1.5);
                    Debug.Log("money is inc");
                }
			}
		}

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

        //timer for scorestreaks
        if(shieldBool)
        {
            sDTimer -= Time.deltaTime;
        }
        else if(sDTimer <= 0)
        {
            sDTimer = 60;
        }

        if (eDBool)
        {
            eDTimer -= Time.deltaTime;
        }
        else if (eDTimer <= 0)
        {
            eDTimer = 60;
        }
    }
	
	void ScoreStreaks ()
	{
		//Money for scorestreaks
		if (money >= 10450) 
		{
			shieldText.text = "Z - 10450/10450$";
			Shield.color = new Color32 (255, 0, 0, 255);
		}
        else
        {
            Shield.color = new Color32(255, 0, 0, 130);
        }
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
        if (Input.GetKeyDown (KeyCode.Z) && money >= 10450) 
		{
			money = (int)(money - 10450);
			StartCoroutine("ShieldSS", 60);
            //sDTimer -= Time.deltaTime;
        }
        //ExtraDamage
        if (Input.GetKeyDown (KeyCode.X) && money >= 258500) 
		{
			money = (int)(money - 258500);
            StartCoroutine("ExtraDam", 60);
            //eDTimer -= Time.deltaTime;
        }
        //AtomicBomb
        if (Input.GetKeyDown(KeyCode.C) && money >= 1234567) 
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

	IEnumerator ShieldSS (float waitTime) 
	{
        shieldBool = true;

	    if(zombie_1 == null)
        {
            zombie_1 = GameObject.FindGameObjectsWithTag("Enemy");
        }
        for (var i = 0; i < zombie_1.Length; i++)
        {
            zombie_1[i].GetComponent<ZombieDamage>().damage = 0;
            Debug.Log("zomDamage is 0");
        }
        //shieldPrefab.SetActive (true);	
        yield return new WaitForSeconds (waitTime);
        //shieldTimer.text = sDTimer.ToString();
        //shieldPrefab.SetActive (false);
        for (var i = 0; i < zombie_1.Length; i++)
        {
            zombie_1[i].GetComponent<ZombieDamage>().damage = 10;
            Debug.Log("zomDamage is 10");
        }
        shieldBool = false;
        StopCoroutine ("ShieldSS");
        //sDTimer = 60f;
	}

    IEnumerator ExtraDam(float waitTime) 
	{
        eDBool = true;
        bullet.damage = 1000;
        Debug.Log("bullet dam is 1000");
		yield return new WaitForSeconds (waitTime);
        Debug.Log("bullet dam is normal");
        //extraDamageTimer.text = waitTime.ToString();
        //bullet.damage = 30;
        eDBool = false;
		StopCoroutine ("ExtraDam");
        //eDTimer = 60f;
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
