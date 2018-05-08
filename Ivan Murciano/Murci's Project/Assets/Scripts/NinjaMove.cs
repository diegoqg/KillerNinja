using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaMove : MonoBehaviour {
    public float speed;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        // rb = GetComponent();
	}
	
    public void RecibirDaño()
    {
        Debug.Log("NINJA A SIDO GOLPEADO");
    }
	
	void Update () {
        float moveHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime * 5.0f;
        float moveVertical = Input.GetAxis("Vertical") * Time.deltaTime * 5.0f;

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        transform.Translate(movement);

	}
}
