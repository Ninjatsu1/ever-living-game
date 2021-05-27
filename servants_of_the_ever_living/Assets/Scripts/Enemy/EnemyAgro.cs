using UnityEngine;

public class EnemyAgro : MonoBehaviour
{
   
    [SerializeField]
    private Transform player;

    [SerializeField]
    private Transform castPoint;

    [SerializeField]
    private Transform castPointBehind;

    [SerializeField]
    private float agroRange;

    [SerializeField]
    private float checkDistance;

    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private Transform wallAndFloorDetect;

    [SerializeField]
    private float stoppingDistance;

    //private Transform hitDetect;
    public bool isAgro = false;
    public bool isSearching;
   
    private Rigidbody2D rb;
    public bool isFacingLeft = true;

    // Start is called before the first frame update
    void Start()
    {
        isFacingLeft = true;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (IsNearEdge())
        {
            isAgro = false;
            isSearching = false;
        }
        if (CanSeePlayer(agroRange))
        {
            isAgro = true;
            StopMovement();
        }
        else
        {
            if (isAgro)
            {
                if (!isSearching)
                {
                    isSearching = true;
                    Invoke("StopChasingPlayer", 1);
                }
               
            }
            
        }
        if (isAgro)
        {
            ChasePlayer();
        }

    }
    //chace player
    void ChasePlayer()
    {
        if (transform.position.x < player.position.x)
        {
            //enemy is to left side of player, move right
            rb.velocity = new Vector2(movementSpeed, 0);
            transform.localScale = new Vector2(-1, 1); //To do flip

            isFacingLeft = false;
        }
        else 
        {
            transform.localScale = new Vector2(1, 1);

            //enemy is right side of the player, move left
            rb.velocity = new Vector2(-movementSpeed, 0);
            isFacingLeft = true;
        }
    }

    //Player is seen but agroing is stopped
    private void StopMovement()
    {
       
        if (Vector2.Distance(player.position, gameObject.transform.position) <= stoppingDistance)
        {
            isAgro = false;
            rb.velocity = new Vector2(0, 0);
        }
    }

    //stop
    private void StopChasingPlayer()
    {
        isAgro = false;
        isSearching = false;
        rb.velocity = Vector2.zero;
    }

    //Sees player
    bool CanSeePlayer(float distance)
    {
        bool chasingPlayer = false;
        float castDistance = distance;
        Vector2 endPosition = castPoint.position + Vector3.left * castDistance;
        Vector2 endPositionBehind = castPointBehind.position + Vector3.right * castDistance;

        RaycastHit2D hit = Physics2D.Linecast(castPoint.position, endPosition, 1 << LayerMask.NameToLayer("Action"));
        RaycastHit2D hitBehind = Physics2D.Linecast(castPointBehind.position, endPositionBehind, 1 << LayerMask.NameToLayer("Action"));

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                chasingPlayer = true;
            }
           
            else
            {
                chasingPlayer = false;
            }
            Debug.DrawLine(castPoint.position, hit.point, Color.yellow);

        }
        else
        {
            Debug.DrawLine(castPoint.position, endPosition, Color.blue);


        }
        if (hitBehind.collider != null)
        {
            Debug.Log(hitBehind.collider.name);
            if (hitBehind.collider.gameObject.CompareTag("Player"))
            {
                chasingPlayer = true;
            } else
            {
                chasingPlayer = false;
            }
            Debug.DrawLine(castPointBehind.position, hitBehind.point, Color.yellow);
        }
        else
        {
            Debug.DrawLine(castPointBehind.position, endPositionBehind, Color.blue);
        }
        return chasingPlayer;
    }

    //Check if it's near edge
    private bool IsNearEdge()
    {
        bool isHitting = true;

        Vector3 targetPosition = wallAndFloorDetect.position;
        targetPosition.y -= checkDistance;
        Debug.DrawLine(wallAndFloorDetect.position, targetPosition, Color.cyan);
        if (Physics2D.Linecast(wallAndFloorDetect.position, targetPosition, 1 << LayerMask.NameToLayer("Ground")))
        {
            isHitting = false;
        }
        else
        {
            isHitting = true;
        }
        return isHitting;
    }
 
}