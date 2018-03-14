using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementScript : MonoBehaviour {

    public GameObject achievement_1;
    public GameObject achievement_2;
    public GameObject achievement_3;
    public GameObject achievement_4;
    public GameObject achievement_5;

    //static bool created = false;

    /*bool ach_1 = false;
    bool ach_2 = false;
    bool ach_3 = false;
    bool ach_4 = false;
    bool ach_5 = false;*/

    //public GameManager gm;

    // Use this for initialization
    void Start () {
        /*if (!created)
        {
            // this is the first instance - make it persist
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
        else
        {
            // this must be a duplicate from a scene reload - DESTROY!
            Destroy(this.gameObject);
        }*/

        GameManager.kills = PlayerPrefs.GetInt("Kills", 0);
        GameManager.total_WavNum = PlayerPrefs.GetInt("T_WN", 0);
    }
	
	// Update is called once per frame
	void Update () {
        if (GameManager.kills >= 1)
        {
            achievement_1.transform.Find("Lock").gameObject.SetActive(false);
            achievement_1.transform.Find("Checkmark").gameObject.SetActive(true);
            //Debug.Log("working");
        }
        if (GameManager.kills >= 50)
        {
            achievement_2.transform.Find("Lock (1)").gameObject.SetActive(false);
            achievement_2.transform.Find("Checkmark (1)").gameObject.SetActive(true);
        }
        if (GameManager.kills >= 1000)
        {
            achievement_3.transform.Find("Lock (2)").gameObject.SetActive(false);
            achievement_3.transform.Find("Checkmark (2)").gameObject.SetActive(true);
        }
        if (GameManager.total_WavNum >= 10)
        {
            achievement_4.transform.Find("Lock (3)").gameObject.SetActive(false);
            achievement_4.transform.Find("Checkmark (3)").gameObject.SetActive(true);
        }
        if (GameManager.total_WavNum >= 50)
        {
            achievement_5.transform.Find("Lock (4)").gameObject.SetActive(false);
            achievement_5.transform.Find("Checkmark (4)").gameObject.SetActive(true);
        }
    }

    public void Reset_Stats()
    {
        PlayerPrefs.DeleteAll();
        //GameManager.killText.text = "0";
        GameManager.kills = 0;
        GameManager.deaths = 0;
        GameManager.total_WavNum = 0;
        GameManager.hiScore = 0;
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
