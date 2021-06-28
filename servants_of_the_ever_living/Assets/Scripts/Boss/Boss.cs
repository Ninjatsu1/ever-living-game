using UnityEngine;
using TMPro;
public class Boss : MonoBehaviour
{
    public int maxHealth = 20;
    public int currentHealth;
    public Healthbar healthbar;
    public bool isBoss = false;
    public string bossName;
    public GameObject bossHealthbar;
    public Transform player;
    public bool isFlipped;
    private void Start()
    {
        player = GameMaster.instance.player.transform;
        healthbar = GameMaster.instance.bossHealthbar.GetComponent<Healthbar>();
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        GameMaster.instance.bossHealth.GetComponent<TextMeshProUGUI>().text = currentHealth.ToString();
        GameMaster.instance.bossNameText.GetComponent<TextMeshProUGUI>().text = bossName;
        
    }

    //Damage enemy
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        healthbar.SetHealth(currentHealth);
        GameMaster.instance.bossHealth.GetComponent<TextMeshProUGUI>().text = currentHealth.ToString();

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
     
        GameObject healthbar = GameMaster.instance.bossHealthbar.gameObject;
        Destroy(healthbar, 1f);
        Destroy(gameObject, 1f);

        

    }
}
