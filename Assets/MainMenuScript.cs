using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject GameOverScreen;

    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene("Game");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        GameOverScreen.SetActive(true);
        Debug.Log("Game Over Screen shown");
    }

    public void QuitApp()
    {
        Application.Quit();
        Debug.Log("Application has been quit.");
    }
}
