using UnityEngine;
using TMPro;
public class BossStats : MonoBehaviour
{
    public string bossName;
    public int maxHealth = 100;
    public int currentHealth;
    public Healthbar healthbar;
    public TextMeshProUGUI bossNameText;
    public Transform player;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        SetName();
    }

    private void SetName()
    {
        bossNameText.text = bossName;
    }
}
