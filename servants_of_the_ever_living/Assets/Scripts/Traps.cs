using UnityEngine;

public class Traps : MonoBehaviour
{

    PlayerStats playerStats;

    private void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

         }

    //When player collides with trap -> Instakill
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerStats>().TakeDamage(playerStats.currentHealth);
        }
                
    }

}
