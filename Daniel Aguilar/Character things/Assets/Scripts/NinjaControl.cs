using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaControl : MonoBehaviour {

    public float moveSpeed { get; set; }
    public float jumpHigh { get; set; }
    public Object shuriken;
    private Vector2 touchOrigin = -Vector2.one;
    private Vector2 touchFinal;
    private Vector2 distancia;
    

    // Use this for initialization
    void Start () {
        shuriken = Resources.Load("shuriken");
        moveSpeed = 3f;
        jumpHigh = 10f;
    }
	
	// Update is called once per frame
	void Update () {

        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        // mayor que 0 si queremos contar mas de un dedo.
        if (Input.touchCount > 0)
        {
            
            Touch touch = Input.touches[0];

            if(touch.phase == TouchPhase.Began)
            {
                touchOrigin = touch.position;

            }else if (touch.phase == TouchPhase.Ended && touchOrigin!=-Vector2.one)
            {
                touchFinal = touch.position;
                distancia.x = touchFinal.x - touchOrigin.x;
                distancia.y = touchFinal.y - touchOrigin.y;

                // comprovar que efectivamente el dedo ha sido arrastrado
                if (Mathf.Abs(distancia.x) > 1 && Mathf.Abs(distancia.y) > 1)
                {
                    if (distancia.y > 0)
                    {
                        transform.position += Vector3.up * jumpHigh * Time.deltaTime;
                    }
                } else if (distancia.x > transform.position.x)
                {
                    ;
                }
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(shuriken, transform.position + (transform.right * 2), transform.rotation);
        }
    }


    //void OnMouseDown()
    //{

    //    this.distancia = this.transform.position.z;

    //    transform.position += Vector3.up * jumpHigh * Time.deltaTime;
    //}

    //void OnMouseDrag()
    //{
       
    //    Vector3 temp = Input.mousePosition;
        
    //    //Debug.Log("mouse: ", temp.z);
    //    //temp.z = this.distancia;
    //    //this.transform.position = Camera.main.ScreenToWorldPoint(temp);
    //}

}
