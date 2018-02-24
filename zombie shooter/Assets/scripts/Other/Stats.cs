using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Stats : MonoBehaviour {

    public Text killStTxt;
    public Text deathStTxt;
    public Text highWaveTxt;
    public Text hiscoretxt;

	// Use this for initialization
	void Start () {
        GameManager.kills = PlayerPrefs.GetInt("Kills", 0);
        GameManager.total_WavNum = PlayerPrefs.GetInt("T_WN", 0);
        GameManager.deaths = PlayerPrefs.GetInt("Death", 0);
        GameManager.hiScore = PlayerPrefs.GetInt("HighScore", 0);
    }
	
	// Update is called once per frame
	void Update () {
        killStTxt.text = "Kills: " + GameManager.kills;
        deathStTxt.text = "Deaths: " + GameManager.deaths;
        highWaveTxt.text = "Highest Wave: " + GameManager.total_WavNum;
        hiscoretxt.text = "High Score: " + GameManager.hiScore;
    }
}
