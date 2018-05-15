using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaControl : MonoBehaviour {

    public float moveSpeed;
    public float jumpHigh;
    private Vector2 touchOrigin = -Vector2.one;
    private Vector2 touchFinal;
    private Vector2 distancia;
    private int vidas { get; set; }

    // Use this for initialization
    void Start() {
        vidas = 1;
        moveSpeed = 3f;
        jumpHigh = 10f;
    }

    // Update is called once per frame
    void Update() {

        transform.position += Vector3.right * moveSpeed * Time.deltaTime;

        // si el personaje ha caido
        if (transform.position.y < -15f)
        {
            Component cameraScript = Camera.main.gameObject.GetComponent("CamFollow");
            Destroy(cameraScript);
            Destroy(gameObject);
        }
            
        // mayor que 0 si queremos contar mas de un dedo.
        else if (Input.touchCount > 0)
        {

            Touch touch = Input.touches[0];

            if (touch.phase == TouchPhase.Began)
            {
                touchOrigin = touch.position;

            } else if (touch.phase == TouchPhase.Ended && touchOrigin != -Vector2.one)
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
        }else if (Input.GetButtonDown("Jump"))
        {
            transform.position += Vector3.up * jumpHigh * Time.deltaTime;
        }

    }

    public void recibirDaño()
    {
        vidas--;

        if(vidas == 0)
        {
            //ME MUEROOOO
            Component cameraScript = Camera.main.gameObject.GetComponent("CamFollow");
            Destroy(cameraScript);
            Destroy(gameObject);
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
