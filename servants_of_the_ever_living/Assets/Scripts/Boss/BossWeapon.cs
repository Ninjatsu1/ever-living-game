using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
    public int minDamage = 1;
    public int maxDamage = 10;

    public Vector3 attackOffset;
    public float attackRange = 0.5f;
    public LayerMask attackMask;
    public Transform attackPosition;

    //boss basic attack
    public void Attack()
    {
        Collider2D playerToDamage = Physics2D.OverlapCircle(attackPosition.position, attackRange, attackMask);
        if (playerToDamage != null)
        {
            playerToDamage.GetComponent<PlayerStats>().TakeDamage(Random.Range(minDamage, maxDamage));
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(attackPosition.position, attackRange);
    }
}
