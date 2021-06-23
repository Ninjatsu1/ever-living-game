using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

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
            DontDestroyOnLoad(instance);
        } else
        {
            Destroy(gameObject);
        }
        
    }
    // called first
    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);
    }

    //Get objects
    public void GetObjects()
    {
        if (player.gameObject == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        if (bossNameText.gameObject == null)
        {

            bossNameText = GameObject.FindGameObjectWithTag("bossName");
            Debug.Log("Got it");

        }
        if (bossHealth.gameObject == null)
        {
            bossHealth = GameObject.FindGameObjectWithTag("bossHealth");
        }
        if (bossHealthbar.gameObject == null)
        {
            bossHealthbar = GameObject.FindGameObjectWithTag("bossHealthbar");
        }
    }
}
