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
    public  Text highScoreText;
    public static int hiScore;
    //string highScoreKey = "HighScore";
	// Reference to the Text component.
	public static int kills;
	public Text killText;
	//PlayerDeath
	public static int deaths;
	
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
    public GameObject shieldEffect;
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
	public static int total_WavNum;
	public Text waveText;
	public static bool isSpawning = false;
    //public ZombieHealth[] zombieHealth;
    //GameObject[] zombiesAddHealth;
    bool zomNumBool = true;

    //Timer
    public float timer = 60.00f;
	public Text timerText;

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
        total_WavNum = PlayerPrefs.GetInt("T_WN", 0);
		deaths = PlayerPrefs.GetInt("Death", 0);
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
	    if(waveNum > PlayerPrefs.GetInt("T_WN", 0)) 
	    {
		    PlayerPrefs.SetInt("T_WN", waveNum);
            total_WavNum = waveNum;
	    }
		moneyText.text = "- " + money;
        killText.text = "Kills - " + kills;
        PlayerPrefs.SetInt("Kills", kills);
	    PlayerPrefs.SetInt("Death", deaths);
		timerText.text = Mathf.Round(timer) + "s";
		extraDamageTimer.text = Mathf.Round(eDTimer) + "s";
		shieldTimer.text = Mathf.Round(sDTimer) + "s";
        waveText.text = "Wave - " + waveNum;
		shieldText.text = "Z - " + money + "/10450$";
		extraDamageText.text = "X - " + money + "/15000$";
		atomicBombText.text = "C - " + money + "/123456$";
		ScoreStreaks ();
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

        //timer for scorestreaks
        if(shieldBool == true)
        {
            sDTimer -= Time.deltaTime;
        }
        else if(sDTimer <= 0)
        {
            sDTimer = 60;
        }

        if (eDBool == true)
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
			atomicBombText.text = "C - 123456/123456$";
			atomicBomb.color = new Color32 (255, 0, 0, 255);
		}
        else
        {
             atomicBomb.color = new Color32(255, 0, 0, 130);
        }

        //Activating && subtracting money
        //Shield
        if ((Input.GetKeyUp (KeyCode.Z) || Input.GetAxis("DpadH") < 0) && money >= 10450) 
		{
			money = (int)(money - 10450);
			StartCoroutine("ShieldSS", 60);
            //StartCoroutine("ShieldPulseEffect", 60);
        }
        //ExtraDamage
        if ((Input.GetKeyUp (KeyCode.X) || Input.GetAxis("DpadV") > 0) && money >= 15000) 
		{
			money = (int)(money - 15000);
            StartCoroutine("ExtraDam", 60);
        }
        //AtomicBomb
        if ((Input.GetKeyUp(KeyCode.C) || Input.GetAxis("DpadH") > 0) && money >= 123456) 
		{
			money = (int)(money - 123456);
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

        shieldEffect.SetActive(true);

        if (zombie_1 == null)
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

        shieldEffect.SetActive(false);

        StopCoroutine ("ShieldSS");
        //sDTimer = 60f;
	}

    /*IEnumerator ShieldPulseEffect(float waitTime)
    {
        while(true)
        {
            yield return new WaitForSeconds(waitTime);
            shieldEffect.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, Random.Range(75, 255));
        }
    }*/

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
}
