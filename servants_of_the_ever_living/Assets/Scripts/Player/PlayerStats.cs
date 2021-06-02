using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Healthbar healthbar;
    public TextMeshProUGUI healthText;
    private GameMaster gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        SetCurrentHealth(currentHealth);
        transform.position = gm.respawnPointPosition;
    }
    //Take damage
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        healthbar.SetHealth(currentHealth);
        SetCurrentHealth(currentHealth);
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    //Update health
    public void SetCurrentHealth(int healthAmount)
    {
        healthText.text = currentHealth.ToString();

    }

}