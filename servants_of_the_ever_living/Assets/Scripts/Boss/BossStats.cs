using UnityEngine;
using TMPro;
public class BossStats : MonoBehaviour
{
    public string bossName;
    public int maxHealth = 100;
    public int currentHealth;
    public Healthbar bossHealthBar;
    private GameMaster gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        currentHealth = maxHealth;
        SetName();
    }

    private void SetName()
    {
        gm.bossNameText.GetComponent<TextMeshProUGUI>().text = bossName;
        gm.bossNameText.gameObject.SetActive(true);
    }
}
