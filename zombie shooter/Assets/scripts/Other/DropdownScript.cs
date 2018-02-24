using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownScript : MonoBehaviour {

    public GameObject startMenu;

    public GameObject acheMenu;

    public GameObject statsMenu;

    public GameObject controlsMenu;

    Dropdown m_DropDown;

	// Use this for initialization
	void Start () {
        m_DropDown = GetComponent<Dropdown>();
	}
	
	// Update is called once per frame
	void Update () {
		if(m_DropDown.value == 1)
        {
            controlsMenu.SetActive(false);
            startMenu.SetActive(false);
            statsMenu.SetActive(false);
            acheMenu.SetActive(true);
        }
        else if(m_DropDown.value == 2)
        {
            statsMenu.SetActive(true);
            startMenu.SetActive(false);
            acheMenu.SetActive(false);
            controlsMenu.SetActive(false);
        }
        else if(m_DropDown.value == 3)
        {
            controlsMenu.SetActive(true);
            statsMenu.SetActive(false);
            startMenu.SetActive(false);
            acheMenu.SetActive(false);
        }else
        {
            controlsMenu.SetActive(false);
            statsMenu.SetActive(false);
            startMenu.SetActive(true);
            acheMenu.SetActive(false);
        }
	}
}
