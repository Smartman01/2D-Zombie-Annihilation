using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Stats : MonoBehaviour {

    public Text killStTxt;
    public Text deathStTxt;
    public Text highWaveTxt;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        killStTxt.text = "Kills: " + GameManager.kills;
        deathStTxt.text = "Deaths: " + GameManager.deaths;
        highWaveTxt.text = "Highest Wave: " + GameManager.total_WavNum;
    }
}
