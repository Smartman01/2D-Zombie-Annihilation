using UnityEngine.UI;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Rigidbody2D bulletPrefab;

    public GameObject muzzleFlashPrefab;

    public Transform bulletSpawn;

    public float speed;

    private PlayerController control;

    public float fireRate = 0.5f;

    float nextFire = 0.0f;

    public int clip = 30;

    public int reserve = 200;

    public Text ammo;

    public GameObject weapon;

    public Bullet B_damage;

    public AudioSource gunAudioSource;
    public AudioClip gunAudioClip;
    public AudioClip reloadClip;

    private Animator anim;

    public static bool shot;

    void Start()
    {
        anim = GetComponent<Animator>();
        control = transform.root.GetComponent<PlayerController>();
    }

    void Update()
    {
        ammo.text = clip.ToString() + " / " + reserve.ToString();

        Weapon();

        if ((Input.GetButton("Fire1") || Input.GetAxis("RT") > 0) && Time.time > nextFire && clip > 0)
        {
            nextFire = Time.time + fireRate;
            clip -= 1;
            gunAudioSource.clip = gunAudioClip;
            gunAudioSource.Play();
            shoot();
        }
        else
        {
            anim.SetBool("Shoot", false);
        }

        if (Input.GetKeyUp(KeyCode.R) || Input.GetButtonUp("XButton") && clip != 30 && reserve != 0)
        {
            var totalAmmo = clip + reserve;
            if (totalAmmo <= 30)
            {
                clip = totalAmmo;
                reserve = 0;
            } else
            {
                var shotsFired = 30 - clip;
                clip = 30;
                reserve -= shotsFired;
            }

            gunAudioSource.clip = reloadClip;
            gunAudioSource.Play();
        }
    }

    void shoot()
    {
        if (control.facingRight)
        {
            Rigidbody2D bulletInstance = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
            Instantiate(muzzleFlashPrefab, bulletSpawn.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            bulletInstance.velocity = new Vector2(speed, 0);
        }
        else
        {
            Rigidbody2D bulletInstance = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.Euler(new Vector3(0, 0, 180))) as Rigidbody2D;
            Instantiate(muzzleFlashPrefab, bulletSpawn.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            bulletInstance.velocity = new Vector2(-speed, 0);
        }

        anim.SetBool("Shoot", true);
    }

    void Weapon()
    {
        if (weapon.GetComponent<SpriteRenderer>().sprite.name == "gun_aims_pm_md90" && GameManager.eDBool == false)
        {
            //clip = 30;
            //reserve = 200;
            fireRate = 0.1f;
            B_damage.damage = 30;
        } else if (weapon.GetComponent<SpriteRenderer>().sprite.name == "gun_ak47" && GameManager.eDBool == false)
        {
            //clip = 55;
            //reserve = 250;
            fireRate = 0.4f;
            B_damage.damage = 25;
        } else if (weapon.GetComponent<SpriteRenderer>().sprite.name == "gun_an94" && GameManager.eDBool == false)
        {
            //clip = 30;
            //reserve = 230;
            fireRate = 0.1f;
            B_damage.damage = 15;
        } else if (weapon.GetComponent<SpriteRenderer>().sprite.name == "gun_ar15" && GameManager.eDBool == false)
        {
            //clip = 30;
            //reserve = 201;
            fireRate = 0.45f;
            B_damage.damage = 40;
        } else if (weapon.GetComponent<SpriteRenderer>().sprite.name == "gun_as_val" && GameManager.eDBool == false)
        {
            //clip = 30;
            //reserve = 220;
            fireRate = 0.5f;
            B_damage.damage = 60;
        } else if (weapon.GetComponent<SpriteRenderer>().sprite.name == "gun_hk_mp5sd" && GameManager.eDBool == false)
        {
            //clip = 30;
            //reserve = 100;
            fireRate = 0.1f;
            B_damage.damage = 30;
        } else if (weapon.GetComponent<SpriteRenderer>().sprite.name == "gun_ithace37" && GameManager.eDBool == false)
        {
            //clip = 30;
            //reserve = 100;
            fireRate = 0.4f;
            B_damage.damage = 35;
        } else if (weapon.GetComponent<SpriteRenderer>().sprite.name == "gun_m21_black" && GameManager.eDBool == false)
        {
            //clip = 30;
            //reserve = 220;
            fireRate = 1.5f;
            B_damage.damage = 100;
        } else if (weapon.GetComponent<SpriteRenderer>().sprite.name == "gun_fa_mas_g2" && GameManager.eDBool == false)
        {
            //clip = 30;
            //reserve = 220;
            fireRate = 0.3f;
            B_damage.damage = 30;
        } else if (weapon.GetComponent<SpriteRenderer>().sprite.name == "gun_fn_minimi" && GameManager.eDBool == false)
        {
            //clip = 30;
            //reserve = 100;
            fireRate = 0.25f;
            B_damage.damage = 20;
        } else if (weapon.GetComponent<SpriteRenderer>().sprite.name == "gun_ingram_mac11" && GameManager.eDBool == false)
        {
            //clip = 30;
            //reserve = 240;
            fireRate = 0.1f;
            B_damage.damage = 10;
        } else if (weapon.GetComponent<SpriteRenderer>().sprite.name == "gun_mossberg_590" && GameManager.eDBool == false)
        {
            //clip = 30;
            //reserve = 208;
            fireRate = .75f;
            B_damage.damage = 75;
        } else if (weapon.GetComponent<SpriteRenderer>().sprite.name == "gun_winchester_1300" && GameManager.eDBool == false)
        {
            //clip = 30;
            //reserve = 20;
            fireRate = 1f;
            B_damage.damage = 50;
        }
    }
}
