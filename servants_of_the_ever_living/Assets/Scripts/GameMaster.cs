using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public static GameMaster instance;
    public Vector2 respawnPointPosition;
    public GameObject player;
    public GameObject bossNameText;
    public GameObject bossHealthbar;
    public GameObject bossHealth;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
        
    }
    


    //Get objects
    public void GetObjects()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        if (bossNameText == null)
        {

            bossNameText = GameObject.FindGameObjectWithTag("bossName");
            Debug.Log("Got it");

        }
        if (bossHealth == null)
        {
            bossHealth = GameObject.FindGameObjectWithTag("bossHealth");
        }
        if (bossHealthbar == null)
        {
            bossHealthbar = GameObject.FindGameObjectWithTag("bossHealthbar");
        }
    }
}
