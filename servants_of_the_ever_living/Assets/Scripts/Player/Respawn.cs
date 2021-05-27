using UnityEngine;

public class Respawn : MonoBehaviour
{
    private GameMaster gm;
    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gm.respawnPointPosition = transform.position;
        }
    }
}
