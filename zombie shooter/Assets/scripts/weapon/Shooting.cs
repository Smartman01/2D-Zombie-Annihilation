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

    void Start()
    {
        control = transform.root.GetComponent<PlayerController>();
    }

    void Update()
    {
        ammo.text = clip.ToString() + " / " + reserve.ToString();
        md90();
        ak47();
        an94();
        ar15();
        as_val();
        mp5sd();
        ithace37();
        m21_black();
        famas_g2();
        minimi();
        mac11();
        mossberg_590();
        winchester_1300();

        if ((Input.GetButton("Fire1") || Input.GetAxis("RT") > 0) && Time.time > nextFire && clip > 0)
        {
            nextFire = Time.time + fireRate;
            clip -= 1;
            gunAudioSource.clip = gunAudioClip;
            gunAudioSource.Play();
            shoot();
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
            /*else
            {
                if (weapon.GetComponent<SpriteRenderer>().sprite.name == "gun_aims_pm_md90")
                {
                    var shotsFired = 30 - clip;
                    clip = 30;
                    reserve -= shotsFired;
                }
                if (weapon.GetComponent<SpriteRenderer>().sprite.name == "gun_ak47")
                {
                    var shotsFired = 25 - clip;
                    clip = 25;
                    reserve -= shotsFired;
                }
                if (weapon.GetComponent<SpriteRenderer>().sprite.name == "gun_an94")
                {
                    var shotsFired = 40 - clip;
                    clip = 40;
                    reserve -= shotsFired;
                }
                if (weapon.GetComponent<SpriteRenderer>().sprite.name == "gun_ar15")
                {
                    var shotsFired = 15 - clip;
                    clip = 15;
                    reserve -= shotsFired;
                }
                if (weapon.GetComponent<SpriteRenderer>().sprite.name == "gun_as_val")
                {
                    var shotsFired = 50 - clip;
                    clip = 50;
                    reserve -= shotsFired;
                }
                if (weapon.GetComponent<SpriteRenderer>().sprite.name == "gun_hk_mp5sd")
                {
                    var shotsFired = 35 - clip;
                    clip = 35;
                    reserve -= shotsFired;
                }
                if (weapon.GetComponent<SpriteRenderer>().sprite.name == "gun_ithace37")
                {
                    var shotsFired = 30 - clip;
                    clip = 30;
                    reserve -= shotsFired;
                }
                if (weapon.GetComponent<SpriteRenderer>().sprite.name == "gun_m21_black")
                {
                    var shotsFired = 5 - clip;
                    clip = 5;
                    reserve -= shotsFired;
                }
                if (weapon.GetComponent<SpriteRenderer>().sprite.name == "gun_fa_mas_g2")
                {
                    var shotsFired = 25 - clip;
                    clip = 25;
                    reserve -= shotsFired;
                }
                if (weapon.GetComponent<SpriteRenderer>().sprite.name == "gun_fn_minimi")
                {
                    var shotsFired = 20 - clip;
                    clip = 20;
                    reserve -= shotsFired;
                }
                if (weapon.GetComponent<SpriteRenderer>().sprite.name == "gun_ingram_mac11")
                {
                    var shotsFired = 10 - clip;
                    clip = 10;
                    reserve -= shotsFired;
                }
                if (weapon.GetComponent<SpriteRenderer>().sprite.name == "gun_mossberg_590")
                {
                    var shotsFired = 15 - clip;
                    clip = 15;
                    reserve -= shotsFired;
                }
                if (weapon.GetComponent<SpriteRenderer>().sprite.name == "gun_winchester_1300")
                {
                    var shotsFired = 5 - clip;
                    clip = 5;
                    reserve -= shotsFired;
                }
            }*/
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
    }

    void md90()
    {
        if (weapon.GetComponent<SpriteRenderer>().sprite.name == "gun_aims_pm_md90" && GameManager.eDBool == false)
        {
            //clip = 30;
            //reserve = 200;
            fireRate = 0.1f;
            B_damage.damage = 30;
        }
    }

    void ak47()
    {
        if (weapon.GetComponent<SpriteRenderer>().sprite.name == "gun_ak47" && GameManager.eDBool == false)
        {
            //clip = 55;
            //reserve = 250;
            fireRate = 0.4f;
            B_damage.damage = 25;
        }
    }

    void an94()
    {
        if (weapon.GetComponent<SpriteRenderer>().sprite.name == "gun_an94" && GameManager.eDBool == false)
        {
            //clip = 30;
            //reserve = 230;
            fireRate = 0.1f;
            B_damage.damage = 15;
        }
    }

    void ar15()
    {
        if (weapon.GetComponent<SpriteRenderer>().sprite.name == "gun_ar15" && GameManager.eDBool == false)
        {
            //clip = 30;
            //reserve = 201;
            fireRate = 0.45f;
            B_damage.damage = 40;
        }
    }

    void as_val()
    {
        if (weapon.GetComponent<SpriteRenderer>().sprite.name == "gun_as_val" && GameManager.eDBool == false)
        {
            //clip = 30;
            //reserve = 220;
            fireRate = 0.5f;
            B_damage.damage = 60;
        }
    }

    void mp5sd()
    {
        if (weapon.GetComponent<SpriteRenderer>().sprite.name == "gun_hk_mp5sd" && GameManager.eDBool == false)
        {
            //clip = 30;
            //reserve = 100;
            fireRate = 0.1f;
            B_damage.damage = 30;
        }
    }

    void ithace37()
    {
        if (weapon.GetComponent<SpriteRenderer>().sprite.name == "gun_ithace37" && GameManager.eDBool == false)
        {
            //clip = 30;
            //reserve = 100;
            fireRate = 0.4f;
            B_damage.damage = 35;
        }
    }

    void m21_black()
    {
        if (weapon.GetComponent<SpriteRenderer>().sprite.name == "gun_m21_black" && GameManager.eDBool == false)
        {
            //clip = 30;
            //reserve = 220;
            fireRate = 1.5f;
            B_damage.damage = 100;
        }
    }

    void famas_g2()
    {
        if (weapon.GetComponent<SpriteRenderer>().sprite.name == "gun_fa_mas_g2" && GameManager.eDBool == false)
        {
            //clip = 30;
            //reserve = 220;
            fireRate = 0.3f;
            B_damage.damage = 30;
        }
    }

    void minimi()
    {
        if (weapon.GetComponent<SpriteRenderer>().sprite.name == "gun_fn_minimi" && GameManager.eDBool == false)
        {
            //clip = 30;
            //reserve = 100;
            fireRate = 0.5f;
            B_damage.damage = 20;
        }
    }

    void mac11()
    {
        if (weapon.GetComponent<SpriteRenderer>().sprite.name == "gun_ingram_mac11" && GameManager.eDBool == false)
        {
            //clip = 30;
            //reserve = 240;
            fireRate = 0.1f;
            B_damage.damage = 10;
        }
    }

    void mossberg_590()
    {
        if (weapon.GetComponent<SpriteRenderer>().sprite.name == "gun_mossberg_590" && GameManager.eDBool == false)
        {
            //clip = 30;
            //reserve = 208;
            fireRate = .75f;
            B_damage.damage = 75;
        }
    }

    void winchester_1300()
    {
        if (weapon.GetComponent<SpriteRenderer>().sprite.name == "gun_winchester_1300" && GameManager.eDBool == false)
        {
            //clip = 30;
            //reserve = 20;
            fireRate = 1f;
            B_damage.damage = 50;
        }
    }
}
