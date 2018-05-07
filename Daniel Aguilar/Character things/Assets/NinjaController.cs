using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaController : MonoBehaviour {

    public float moveSpeed = 3f;
    public float jumpHigh = 3f;
    float distancia;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
    }


    void OnMouseDown()
    {

        this.distancia = this.transform.position.z;

    }

    void OnMouseDrag()
    {
       
        Vector3 temp = Input.mousePosition;
        
        //Debug.Log("mouse: ", temp.z);
        //temp.z = this.distancia;
        //this.transform.position = Camera.main.ScreenToWorldPoint(temp);
        transform.position += Vector3.up * jumpHigh * Time.deltaTime;
    }

}
