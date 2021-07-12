using UnityEngine;

public class BowScript : MonoBehaviour
{

    public GameObject pivot;
    public GameObject player;
    public float lookSpeed = 50;

    // Update is called once per frame
    void Update()
    {

        Vector3 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, Time.deltaTime * lookSpeed);

    }
}
