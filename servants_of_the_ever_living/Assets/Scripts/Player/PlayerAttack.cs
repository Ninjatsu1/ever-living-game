using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public Transform attackPosition;
    public float meleeRange;
    public LayerMask whatIsEnemy;
    public int damage;
    private Animator myAnimation;
    private float timeBetweenAttack;
    public float startTimeBetweenAttack;
    private void Start()
    {
        myAnimation = GetComponent<Animator>();
    }
    private void Update()
    {
        if (timeBetweenAttack <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                myAnimation.SetTrigger("IsAttacking");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosition.position, meleeRange, whatIsEnemy);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                }
            }
            timeBetweenAttack = startTimeBetweenAttack;

        } else
        {
            timeBetweenAttack -= Time.deltaTime;
        }
        
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosition.position, meleeRange);
    }
}
