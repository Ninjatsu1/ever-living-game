using UnityEngine;
using System.Collections;

public class Triggers : MonoBehaviour
{
    public Transform balathorBossSpawn;
    public GameObject balathorPrefab;
    public GameObject bossHealthbar;
    private GameMaster gm;
    public GameObject playerHUD;
    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();

    }
    //Trigger when player enters it
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //bossHealthbar.SetActive(true);
            SpawnBossHealthBar();
            SpawnBoss();
            DestroyObject();
        }
    }
    private void SpawnBossHealthBar()
    {
       GameObject newBossHealthbar =
       Instantiate(bossHealthbar, transform.position, transform.rotation);
        
       newBossHealthbar.gameObject.transform.SetParent(playerHUD.transform, false);
        newBossHealthbar.transform.localScale = new Vector3(1, 1, 1);

        //playerHUD.transform.parent = playerHUD.transform;
        gm.GetObjects();
    }

    //Spawns boss
    private void SpawnBoss()
    {
        Instantiate(balathorPrefab, balathorBossSpawn.position, Quaternion.identity);

    }

    //Destroys object
    private void DestroyObject()
   {
        Destroy(gameObject, 1);
   }
}
