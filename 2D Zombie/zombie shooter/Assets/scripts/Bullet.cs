using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    Rigidbody2D rb2d;

    Collider2D coll2D;

    public int speed;

    //List<ParticleSystem> allParticles;

    public float lifeTime;

    public int damage;

    public List<string> m_collisionTags;

    // Use this for initialization
    void Start()
    {
        //allParticles = GetComponentsInChildren<ParticleSystem>().ToList();
        rb2d = GetComponent<Rigidbody2D>();
        coll2D = GetComponent<Collider2D>();
        StartCoroutine("SelfDestruct");
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy();
    }

    void Destroy()
    {
        coll2D.enabled = false;
        rb2d.velocity = Vector2.zero;
        rb2d.Sleep();
        foreach (MeshRenderer m in GetComponentsInChildren<MeshRenderer>())
        {
            m.enabled = false;
        }
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        var hit = coll.gameObject;
		var hitplayer = hit.tag = "Enemy";
        if (hitplayer != null)
        {
            var Zomhealth = hit.GetComponent<ZombieHealth>();
            Debug.Log("hit");
            Zomhealth.ZomDamage(damage);
            Destroy(gameObject);
        }
    }
}
