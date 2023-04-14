using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float sceneLoadDelay = 1.5f;

   public void LoadGame()
    {
        if(ScoreKeeper.Instance != null)
        {
            ScoreKeeper.Instance.ResetScore();
        }
        SceneManager.LoadScene("Game");
    }
    public void LoadMainMenu()
    {
        ScoreKeeper.Instance.ResetScore();
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadGameOverMenu()
    {
        StartCoroutine(WaitAndLoad("GameOver", sceneLoadDelay));
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    private IEnumerator WaitAndLoad(string sceneName , float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
