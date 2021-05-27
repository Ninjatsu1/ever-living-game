using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public string mainGameScene;
    public string creditsScene;

    //Load and start new game
    public void NewGame()
    {
        SceneManager.LoadScene(mainGameScene);

    }

    //Load credits scene
    public void Credits()
    {
        SceneManager.LoadScene(creditsScene);

    }
    //Quit game
    public void Quit()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }
    //To do: continue game
}
