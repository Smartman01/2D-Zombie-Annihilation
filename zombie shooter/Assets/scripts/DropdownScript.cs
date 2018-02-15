using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownScript : MonoBehaviour {

    public GameObject startMenu;

    public GameObject acheMenu;

    Dropdown m_DropDown;

	// Use this for initialization
	void Start () {
        m_DropDown = GetComponent<Dropdown>();
	}
	
	// Update is called once per frame
	void Update () {
		if(m_DropDown.value == 1)
        {
            startMenu.SetActive(false);
            acheMenu.SetActive(true);
        }
        else
        {
            startMenu.SetActive(true);
            acheMenu.SetActive(false);
        }
	}
}
