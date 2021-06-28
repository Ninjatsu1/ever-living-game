using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 20;
    public int currentHealth;
    public Healthbar healthbar;
    private GameMaster gm;
    public GameObject bossHealthbar;
    public GameObject floatingText;
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        gm = GameMaster.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    //Damage enemy
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        healthbar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            EnemyDeath();
        }
    }
    
    //Enemy death
    public void EnemyDeath()
    {
        DestroyImmediate(gameObject);
    }
}
