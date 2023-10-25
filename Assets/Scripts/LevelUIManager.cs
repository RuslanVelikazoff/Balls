using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelUIManager : MonoBehaviour
{
    public Button exitButton;

    public TextMeshProUGUI scoreText;

    private int score;

    private void Start()
    {
        score = 0;

        addScore(0);

        InitializeButton();
    }

    private void InitializeButton()
    {
        if (exitButton != null)
        {
            exitButton.onClick.RemoveAllListeners();
            exitButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(0);
            });
        }
    }

    public void addScore(int addScore)
    {
        score += addScore;

        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }

        scoreText.text = "Score: " + score;
    }
}
