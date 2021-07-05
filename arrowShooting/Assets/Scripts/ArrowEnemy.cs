using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowEnemy : MonoBehaviour
{

    [SerializeField]

    GameObject bullet;
    public float launchForce;
    public Transform PointyEnd;

    float fireRate;
    float nextFire;


    // Use this for initialization
    void Start()
    {
        fireRate = 2f;
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfTimeToFire ();
    }

    void CheckIfTimeToFire()
        {
        if (Time.time > nextFire) {
           GameObject newArrow = Instantiate(bullet, PointyEnd.position, PointyEnd.rotation);
        nextFire = Time.time + fireRate;
            newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
        }
        
    }


}
