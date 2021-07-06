using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class colliderscript : MonoBehaviour
{

    private ArrowEnemy arrowEnemy;

    private void Awake()
    {
        arrowEnemy = GetComponent<ArrowEnemy>();
    }

  private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerStats>(out PlayerStats player))
        {
         
        }
    }


}
