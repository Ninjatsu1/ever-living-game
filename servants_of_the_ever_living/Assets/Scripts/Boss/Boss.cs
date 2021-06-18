using UnityEngine;

public class Boss : MonoBehaviour
{
    public int maxHealth = 20;
    public int currentHealth;
    public Healthbar healthbar;
    public bool isBoss = false;
    public string bossName;
    private GameMaster gm;
    public GameObject bossHealthbar;
    public Transform player;
    public bool isFlipped;
    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        player = gm.player.transform;
        healthbar = gm.bossHealthbar.GetComponent<Healthbar>();
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        gm.bossHealth.text = currentHealth.ToString();
        gm.bossNameText.text = bossName;
        bossHealthbar = GameObject.FindGameObjectWithTag("Boss");
        
    }

    //Damage enemy
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        healthbar.SetHealth(currentHealth);
        gm.bossHealth.text = currentHealth.ToString();

        if (currentHealth <= 0)
        {
            EnemyDeath();
        }
    }

    // Start is called before the first frame update
    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1;


        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }
    //Enemy death
    public void EnemyDeath()
    {
        if (isBoss)
        {
            bossHealthbar = gm.bossHealthbar.gameObject;
            bossHealthbar.gameObject.SetActive(false);
        }
        DestroyImmediate(gameObject);

    }
}
