using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControllerNavUI : MonoBehaviour {

    public EventSystem eventSystem;
    public EventSystem evs2;
    public EventSystem evs3;

    public GameObject startPanel;
    public GameObject pausePanel;
    public GameObject deathPanel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(startPanel.active == false && pausePanel.active == true)
        {
            evs2.enabled = false;
            eventSystem.enabled = true;
        } else if(deathPanel.active == true)
        {
            evs3.enabled = true;
            evs2.enabled = false;
            eventSystem.enabled = false;
        }
	}
}
