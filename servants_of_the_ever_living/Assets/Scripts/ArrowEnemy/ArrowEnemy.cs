using UnityEngine;

public class ArrowEnemy : MonoBehaviour
{

    [SerializeField]

    GameObject bullet;
    public float launchForce;
    public Transform PointyEnd;
    public bool IsPlayerDetected = false;

    float fireRate;
    float nextFire;


    // Use this for initialization
    void Start()
    {
        fireRate = 2f;
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

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



    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            IsPlayerDetected = true;
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        IsPlayerDetected = false;
    }




}
