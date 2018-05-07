using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMap : MonoBehaviour {

    public float freq = 4f;
    float crono;
    // Use this for initialization
    void Start () {
        crono = freq;
    }
	
	// Update is called once per frame
	void Update () {
        crono -= Time.deltaTime;
        if (crono <= 0){
            Destroy(gameObject);
        }
    }
}
