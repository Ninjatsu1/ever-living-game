using UnityEngine;

public class UnlockSkill : MonoBehaviour
{
    public GameObject ButtonCanvas;
    public GameObject UIDoubleJumpMessage;
    private bool Player;
    private bool IsAbleToUnlockSkill = false;
    private bool DisplayDoubleJumpMessage = false;

    // Update is called once per frame
    void Update()
    {
        if (IsAbleToUnlockSkill)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                GameMaster.instance.player.GetComponent<PlayerController>().isDoubleJumpUnlocked = true;
                DoubleJumpMessage(true);
            }
        }
    }

    private void DoubleJumpMessage(bool DisplayDoubleJumpMessage)
    {
       
        if (DisplayDoubleJumpMessage)
        {
            UIDoubleJumpMessage.SetActive(true);
        } else
        {
            UIDoubleJumpMessage.SetActive(false);
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
