using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMove : MonoBehaviour {

    public float moveSpeed { get; set; }

    // Use this for initialization
    void Start () {
        moveSpeed = 10f;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
    }
}
