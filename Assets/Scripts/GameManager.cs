using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : Singleton<GameManager>
{
    public GameObject failScreen;
    public bool isGameOver;

    private void Awake()
    {
        isGameOver = false;
    }

    public void Death()
    {
        failScreen.SetActive(true);
        isGameOver = true;
    }
    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
