using UnityEngine.SceneManagement;
using UnityEngine;

public class Credits : MonoBehaviour
{
    public string mainMenuName;

    //Back to main menu
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(mainMenuName);
    }
}
