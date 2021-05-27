using UnityEngine;

public class Patrolling : MonoBehaviour
{
    public float patrollingSpeed;
    private Rigidbody2D rg;
    public bool facingRight;
    private Vector3 baseScale;
    [SerializeField]
    private Transform castPosition;
    [SerializeField]
    private float baseCastDistance = 1;
    [SerializeField]
    private LayerMask layer;
    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
        rg = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        transform.Translate(Vector2.right * patrollingSpeed * Time.deltaTime);
        if (IsHittingWall() || IsNearEdge())
        {
            if (facingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                facingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                facingRight = true;
            }
        }
    }
    private void ChangeDirection(bool facingRight)
    {
    }
    private bool IsNearEdge()
    {
        bool isHitting = true;
        float castDistace = baseCastDistance;

        Vector3 targetPosition = castPosition.position;
        targetPosition.y -= castDistace;
        Debug.DrawLine(castPosition.position, targetPosition, Color.blue);
        if (Physics2D.Linecast(castPosition.position, targetPosition, 1 << LayerMask.NameToLayer("Ground")))
        {
            isHitting = false;
        }
        else
        {
            isHitting = true;
        }
        return isHitting;
    }
    private bool IsHittingWall()
    {
        bool isHitting = false;
        float castDistace = baseCastDistance;
        if (facingRight == false)
        {
            castDistace = -castDistace;
        }
        Vector3 targetPosition = castPosition.position;
        targetPosition.x += castDistace;
        Debug.DrawLine(castPosition.position, targetPosition, Color.red); ;
        if (Physics2D.Linecast(castPosition.position, targetPosition, 1 << LayerMask.NameToLayer("Ground")))
        {
            isHitting = true;
        }
        else
        {
            isHitting = false;
        }
        return isHitting;

    }
}
