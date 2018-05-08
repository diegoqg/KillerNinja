using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaAttack : MonoBehaviour {


    public Object weapon;
    public float fireRate;
    public LayerMask noHit;

    private float timeToFire = 0f;
    private Transform firePoint;
    

    // Use this for initialization
    void Start () {

        weapon = Resources.Load("shuriken");
    }
	
	// Update is called once per frame
	void Update () {
        
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, firePointPosition - mousePosition, 100, noHit);
        //Instantiate(weapon, transform.position, );
        
        Debug.DrawLine(firePointPosition, (firePointPosition - mousePosition) * 100, Color.black);

        if (Input.GetButtonDown("Fire1"))
        {
        }
    }
}
