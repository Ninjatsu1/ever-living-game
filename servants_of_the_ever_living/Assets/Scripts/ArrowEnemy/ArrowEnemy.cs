using UnityEngine;

public class ArrowEnemy : MonoBehaviour
{

    [SerializeField]

    GameObject bullet;
    public float launchForce;
    public Transform PointyEnd;
    public bool IsPlayerDetected = false;
    public LayerMask whatIsPlayer;
    public float sightRange = 10;
    float fireRate;
    float nextFire;
    public Transform SightDetection;

    // Use this for initialization
    void Start()
    {
        fireRate = 2f;
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        DetectPlayer();
        if (IsPlayerDetected)
        {
            CheckIfTimeToFire();
        }
    }

    void CheckIfTimeToFire()
    {
        if (Time.time > nextFire)
        {
            GameObject newArrow = Instantiate(bullet, PointyEnd.position, PointyEnd.rotation);
            nextFire = Time.time + fireRate;
            newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
        }

    }

    //Detect player with circle
    private void DetectPlayer()
    {
        Collider2D playerToDamage = Physics2D.OverlapCircle(SightDetection.position, sightRange, whatIsPlayer);
        if (playerToDamage != null)
        {
            if (playerToDamage.gameObject.CompareTag("Player"))
            {
                IsPlayerDetected = true;
                Debug.Log("Player here");
            }
         
        }
        else
        {
            IsPlayerDetected = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(SightDetection.position, sightRange);
    }

}
