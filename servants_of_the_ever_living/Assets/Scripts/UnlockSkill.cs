using UnityEngine;

public class UnlockSkill : MonoBehaviour
{
    public GameObject ButtonCanvas;
    private bool Player;
    private bool IsAbleToUnlockSkill = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsAbleToUnlockSkill)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                GameMaster.instance.player.GetComponent<PlayerController>().isDoubleJumpUnlocked = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ButtonCanvas.SetActive(true);
            Debug.Log("Player is here");
            IsAbleToUnlockSkill = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ButtonCanvas.SetActive(false);
            IsAbleToUnlockSkill = false;
        }
    }

}
