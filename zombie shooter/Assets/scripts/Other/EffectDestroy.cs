using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDestroy : MonoBehaviour {

    public float delay;
    float countdown;

    // Use this for initialization
    void Start () {
        countdown = delay;
    }
	
	// Update is called once per frame
	void Update () {
        countdown -= Time.deltaTime;
        if (countdown <= 0f)
            Destroy(gameObject);
	}
}
