using UnityEngine;

public class Boss_run : StateMachineBehaviour
{
    Transform player;
    public float attackRange = 3f;
    Rigidbody2D rb;
    public float speed = 1;
    Boss boss;
    string[] attacks = { "Attack", "Stab" };
    private float timer = 0;
    private float timeMax = 2;
    private float timeMin = 1;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Boss>();

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.LookAtPlayer();
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPosition = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPosition);
        if (Vector2.Distance(player.position, rb.position) <= attackRange)
        {

            if (timer <= 0)
            {
                PlayRandomly(animator);
                timer = Random.Range(timeMin, timeMax);
            } else
            {
                timer -= Time.deltaTime;
            }
            //PlayRandomly();
                
         
            //attack
        }
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
 
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
        animator.ResetTrigger("Stab");
    }

    private void PlayRandomly(Animator animator)
    {
        System.Random random = new System.Random();
        int randomAttack = random.Next(attacks.Length);
        string attack = attacks[randomAttack];
        animator.SetTrigger(attack);
    }
}
