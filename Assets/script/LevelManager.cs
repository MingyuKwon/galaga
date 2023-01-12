using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float deathDelay = 1f;
    Score score;

    int currentIndex; 
    
    void Awake() {
        score = FindObjectOfType<Score>();
    }
    void Start() {
        currentIndex = SceneManager.GetActiveScene().buildIndex;
    }
    
    public void LoadGame()
    {
        if(score != null)
        {
            score.ClearScore();
        }
        SceneManager.LoadScene("Game");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadResult()
    {
        StartCoroutine(loadResult());
    }

    public void QuitGame()
    {
        Debug.Log("QuittingGame");
        Application.Quit();
    }

    IEnumerator loadResult()
    {
        yield return new WaitForSeconds(deathDelay);
        SceneManager.LoadScene("Result");
    }
}
