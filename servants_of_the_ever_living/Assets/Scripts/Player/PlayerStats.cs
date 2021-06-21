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
    public GameObject floatingText;
    public GameObject DamagePopUpCanvas;

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
        int damage = damageAmount;
        healthbar.SetHealth(currentHealth);
        SetCurrentHealth(currentHealth);
        if (floatingText != null)
        {
            DisplayFloatingText(damage);
        }
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    //Display floating text top of the player
    private void DisplayFloatingText(int damageAmount)
    {
        Debug.Log(damageAmount);
        GameObject newDamageText = 
       Instantiate(floatingText, DamagePopUpCanvas.transform.position, Quaternion.identity);
        TextMeshProUGUI textmeshobject =
        newDamageText.GetComponent<TextMeshProUGUI>();
        textmeshobject.text = damageAmount.ToString();
       newDamageText.transform.parent = DamagePopUpCanvas.transform;

    }

    //Player dies and moves to last checkpoint
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