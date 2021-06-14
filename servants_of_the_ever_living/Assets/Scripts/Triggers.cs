using UnityEngine;

public class Triggers : MonoBehaviour
{
    public Transform balathorBossSpawn;
    public GameObject balathorPrefab;
    public GameObject bossHealthbar;
    //Trigger when player enters it
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            bossHealthbar.SetActive(true);
            Instantiate(balathorPrefab, balathorBossSpawn.position, Quaternion.identity);
            DestroyObject();
        }
    }

    //Destroys object
   private void DestroyObject()
   {
        Destroy(gameObject, 1);
   }
}
