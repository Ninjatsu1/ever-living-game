using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float moveSpeed = 7f;

    Rigidbody2D rb;

    Player1 target;
    Vector2 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
        target = GameObject.FindObjectOfType<Player1>();
        //moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
       // rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals ("Player"))
        {
            
            Destroy (gameObject);
        }
    }

    void Update()
    {
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }



}
