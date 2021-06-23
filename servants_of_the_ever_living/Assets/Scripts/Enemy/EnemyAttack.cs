using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackArea;
    [SerializeField]
    private Transform player;
    private bool isAttacking;
    private Animator myAnimation;
    public float meleeRange;
    public int damage;
    public LayerMask whatIsPlayer;
    private float timeBetweenAttack;
    public float startTimeBetweenAttack;
    public Transform attackPosition;
    // Start is called before the first frame update
    void Start()
    {
        myAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Collider2D[] playerToDamage = Physics2D.OverlapCircleAll(attackPosition.position, meleeRange, whatIsPlayer);
        if (timeBetweenAttack <= 0)
        {
            Attack();
          
            timeBetweenAttack = startTimeBetweenAttack;

        }
        else 
        {
            timeBetweenAttack -= Time.deltaTime;
        }
      
        
    }

    //Attack player
    public void Attack()
    {
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);
        if (distanceToPlayer < attackArea)
        {
            isAttacking = true;
            if (isAttacking)
            {

                myAnimation.SetTrigger("IsAttacking");
                Collider2D playerToDamage = Physics2D.OverlapCircle(attackPosition.position, meleeRange, whatIsPlayer);

                if (playerToDamage != null)
                {
                    playerToDamage.GetComponent<PlayerStats>().TakeDamage(damage);
                }
            }
        }
        else if (distanceToPlayer > attackArea)
        {

            isAttacking = false;
        }
        else if(distanceToPlayer == attackArea)
        {

            isAttacking = false;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(attackPosition.position, meleeRange);
    }
}
