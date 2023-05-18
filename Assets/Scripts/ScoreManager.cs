using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager instance;
    private int score = 0;

    public static ScoreManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ScoreManager>();
                if (instance == null)
                {
                    GameObject scoreManagerObject = new GameObject("ScoreManager");
                    instance = scoreManagerObject.AddComponent<ScoreManager>();
                }
            }
            return instance;
        }
    }

    public void AddScore(int value)
    {
        score += value;
        Debug.Log("Score: " + score);
    }
}
