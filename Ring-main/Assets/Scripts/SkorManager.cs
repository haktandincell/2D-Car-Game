using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class SkorManager : MonoBehaviour
{
    public static int HighScore = 0;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI HighScoreText;
    public int score = 0; // Bu sadece o anki skor

    private void Start()
    {
        score = ScoreManager.Instance.score; // Anlýk skoru al
        ScoreText.text = "Skorun: " + score.ToString();
        HighScoreText.text = "En Yüksek Skor: " + HighScore.ToString();
    }

    public static void SetHighScore(int score)
    {
        if (score > HighScore)
        {
            HighScore = score;
        }
    }
}
