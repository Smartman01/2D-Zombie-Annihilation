﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour {

    public GameObject achievement_1;
    public GameObject achievement_2;
    public GameObject achievement_3;
    public GameObject achievement_4;
    public GameObject achievement_5;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Reset_Stats()
    {
        PlayerPrefs.DeleteAll();
        //GameManager.killText.text = "0";
        GameManager.kills = 0;
        //GameManager.highScoreText.text = "0";

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

        Debug.Log("worked");
    }
}
