using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public string mainGameScene;
    //Load and start new game
    public void NewGame()
    {
        SceneManager.LoadScene(mainGameScene);

    }

    //Quit game
    public void Quit()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }
    //To do: continue game
}
