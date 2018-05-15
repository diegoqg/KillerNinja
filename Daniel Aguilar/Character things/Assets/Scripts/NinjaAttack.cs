using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaAttack : MonoBehaviour {

    public float fireRate = 1f;
    public Object weapon;
    public LayerMask toHit;

    private float timeToFire = 0f;
    private Transform firePoint;
    private Animator anim;

    // Use this for initialization
    void Start () {
        firePoint = transform;
        if (firePoint == null)
        {
            Debug.Log("no firepoint");
        }
        weapon = Resources.Load("shuriken");

        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        //shoot();
        if (Time.time > timeToFire && !anim.GetBool("Jump"))
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Vector3 shootDirection;
                shootDirection = Input.mousePosition;
                shootDirection.z = 0.0f;
                shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
                shootDirection = shootDirection - transform.position;

                /*GameObject bulletInstance = (GameObject)Instantiate(weapon, transform.position + new Vector3(1.5f, 1.5f, 0.0f), Quaternion.Euler(new Vector3(0, 0, 0)));

                if (bulletInstance != null)
                    bulletInstance.GetComponent<Rigidbody>().velocity = new Vector2(shootDirection.x * 5f, shootDirection.y * 5f);*/
                timeToFire = Time.time + 1 / fireRate;
                Instantiate(weapon, transform.position + new Vector3(1f, 1f, 0f), transform.rotation);
                
            }
        }
        
    }

    public void shoot()
    {
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        //RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 100, toHit);

        Debug.DrawLine(firePointPosition, (mousePosition - firePointPosition) * 100, Color.cyan);
    }
}
