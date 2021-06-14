using UnityEngine;
using TMPro;
public class GameMaster : MonoBehaviour
{
    public static GameMaster instance;
    public Vector2 respawnPointPosition;
    public GameObject player;
    public TextMeshProUGUI bossNameText;
    public GameObject bossHealthbar;
    public TextMeshProUGUI bossHealth;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        } else
        {
            Destroy(gameObject);
        }
        
    }
}
