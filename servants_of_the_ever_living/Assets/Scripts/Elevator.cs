using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Elevator : MonoBehaviour
{
    [SerializeField]
    private GameObject ButtonCanvas;
    private bool inArea = false;
    private void Update()
    {
        if (inArea)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("ere");
                SceneManager.LoadScene(0);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")) {
            ButtonCanvas.SetActive(true);
            inArea = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            ButtonCanvas.SetActive(false);
            inArea = false;
        }
    }
}
