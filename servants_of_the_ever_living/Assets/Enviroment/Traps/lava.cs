using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lava : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody2D rb;
    public float DestroyTime = 1f;

    //public LayerMask whatIsGround;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, DestroyTime);
    }



    //When player collides with trap -> -20HP
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerStats>().TakeDamage(20);
            Destroy(gameObject);
        }
        else if (other.transform.tag == "Ground")
        {
            Destroy(gameObject);
        }


    }

    public void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
