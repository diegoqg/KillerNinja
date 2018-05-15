using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMove : MonoBehaviour {

    public float moveSpeed { get; set; }
    public float frequency = 3f;
    private Vector3 target;
    private Vector2 mousePos;
    private float crono;

    // Use this for initialization
    void Start() {
        moveSpeed = 30f;
        crono = frequency;
        Debug.Log(Time.time);
        /*target = Input.mousePosition;
        target.y -= 150f;
        Debug.Log(target);
        */
        /*mousePos = new Vector2();
        mousePos.x = Input.mousePosition.x;
        mousePos.y = Camera.main.pixelHeight - Input.mousePosition.y;
        target = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0));
        target = new Vector3(mousePos.x, mousePos.y, 0);*/
    }

    // Update is called once per frame
    void Update() {
        transform.position = transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        crono = crono - Time.deltaTime;
        if(crono < 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        //EL DIEGO ES GILIPOLLAS.
        if (col.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy found");
        }

        else if (col.gameObject.tag == "Boss")
        {
            Debug.Log("Boss found");
        }
        Destroy(gameObject);
    }
}
