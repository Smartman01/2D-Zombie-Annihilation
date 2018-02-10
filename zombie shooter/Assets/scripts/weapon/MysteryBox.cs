using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteryBox : MonoBehaviour {

    Animation movement;

    public bool openBox = false, canTakeWeapon, triggerWeapon, boxIsOpen;

    public int mysteryBoxPrice;

    //public bool showMysteryBoxGUI = false;
    //public GUISkin mySkin;

    public GameObject[] guns;
    public int[] gunIndex;
    public GameObject weapon;
    public int selectedGun;
    public Transform gunPosititon;
    int weaponIndex;

    public float timer;
    public int counter, counterCompare;

	// Use this for initialization
	void Start () {
        movement = GetComponentInChildren<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
        if (openBox)
        {
            OpenMysteryBox();
            openBox = false;
            canTakeWeapon = false;
            triggerWeapon = true;
        }
        else if(movement.IsPlaying("gunMovement"))
        {
            timer += Time.deltaTime;

            if(timer < 4.0f && counter < counterCompare)
            {
                counter++;
            }
            else if(counter == counterCompare)
            {
                counter = 0;
                RandomizeWeapons();
                counterCompare++;
            }
            else if (triggerWeapon)
            {
                canTakeWeapon = true;
                triggerWeapon = false;
            }
            guns[selectedGun].transform.position = gunPosititon.transform.position;
        }
        else //if (boxIsOpen)
        {
            counter = 0;
            counterCompare = 0;
            timer = 0;
            DisableGuns();
        }
    }

    void RandomizeWeapons()
    {
        int gunCount = guns.Length;
        int rand = Random.Range(0, gunCount);

        while(rand == selectedGun)
        {
            rand = Random.Range(0, gunCount);
        }

        selectedGun = rand;

        DisableGuns();

        guns[selectedGun].SetActive(true);
        guns[selectedGun].transform.position = gunPosititon.transform.position;
    }

    void DisableGuns()
    {
        for (int i = 0; i < guns.Length; i++)
        {
            guns[i].SetActive(false);
        }
    }

    void OpenMysteryBox()
    {
        RunGunMovement();
    }

    void RunGunMovement()
    {
        movement.Play();
    }

    /*void OnGUI()
    {
        GUI.skin = mySkin;
        GUIStyle style1 = mySkin.customStyles[0];
        if (showMysteryBoxGUI)
        {
            GUI.Label(new Rect(Screen.width - (Screen.width / 1.7f), Screen.height - (Screen.height / 1.4f), 800, 100), "Press key << E >> to open box  $" + mysteryBoxPrice, style1);
        }
        if (canTakeWeapon)
        {
            GUI.Label(new Rect(Screen.width - (Screen.width / 1.7f), Screen.height - (Screen.height / 1.4f), 800, 100), "Press key << E >> to take weapon", style1);
        }
    }*/

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            /*if (!boxIsOpen)
            {
                showMysteryBoxGUI = true;
            }
            else
                showMysteryBoxGUI = false;*/

            if (Input.GetKeyUp("e") && GameManager.money >= mysteryBoxPrice && !boxIsOpen && !openBox && timer == 0)
            {
                GameManager.money -= mysteryBoxPrice;
                openBox = true;
            }

            if (canTakeWeapon && Input.GetKeyUp("t"))
            {
                weapon.GetComponent<SpriteRenderer>().sprite = guns[selectedGun].GetComponent<SpriteRenderer>().sprite;
                
                canTakeWeapon = false;
                //boxIsOpen = true;
                /*
				if (setElement == 8)
				{
					Pickup pickupGOW1 = hit.transform.GetComponent<Pickup>();
					addStickGrenades(pickupGOW1.amount);
				}
				*/
                for (int i = 0; i < guns.Length; i++)
                {
                    guns[i].SetActive(false);
                }
                //CloseLid();
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //showMysteryBoxGUI = false;
            canTakeWeapon = false;
            boxIsOpen = false;
        }
    }
}
