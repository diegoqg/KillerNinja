using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaControl : MonoBehaviour {

    public float moveSpeed;
    public float jumpHigh;
    private Vector2 touchOrigin = -Vector2.one;
    private Vector2 touchFinal;
    private Vector2 distancia;
    private Vector3 changeColider = new Vector3(0,0.1f,0);
    private float jumpTime;
    private Animator anim;
    private CapsuleCollider myCollider;
    private int vidas { get; set; }
    private bool up = true;

    // Use this for initialization
    void Start() {
        vidas = 1;
        anim = GetComponent<Animator>();
        myCollider = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update() {

        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        //jumpTime -= Time.deltaTime;

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
        }

        if (Input.GetButtonDown("Jump") && !anim.GetBool("Jump"))
        {
            anim.SetBool("Jump", true);
            Debug.Log("EL JUMP ESTA PUESTO EN :" + anim.GetBool("Jump"));
            
        }

        if (anim.GetBool("Jump"))
        {
            Debug.Log(myCollider.center + " SALTA " + up);

            if (up) myCollider.center += changeColider;
            else myCollider.center -= changeColider;

            
           if (myCollider.center.y < 0.7)
            {
                myCollider.center = new Vector3(0.0f, 0.7f, 0.0f);
            }
            GetComponent<Rigidbody>().useGravity = false;
        }

        if(anim.GetBool("Jump"))
            jumpTime -= Time.deltaTime;

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

    bool AnimatorIsPlaying()
    {
        return anim.GetCurrentAnimatorStateInfo(0).length >
               anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }


    void stopJump()
    {
        up = true;
        anim.SetBool("Jump", false);
        myCollider.center = new Vector3(0f, 0.7f, 0f);
        GetComponent<Rigidbody>().useGravity = true;
    }

    void coliderUp()
    {
        up = true;
    }

    void coliderDown()
    {
        up = false;
    }

}
