using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public bool isGameActive = true;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int value)
    {
        if (isGameActive) 
        {
            score += value;
            scoreText.text = "Score: " + score;
        }
    }

    public void EndGame()
    {
        isGameActive = false;
    }
}
