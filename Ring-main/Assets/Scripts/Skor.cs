using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; // Singleton referansý

    public int score = 0;
    public Text scoreText;
    public TextMeshProUGUI highScoreText;
    public SkorManager skorManager;


    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject); // Fazla olaný yok et
    }

    void Start()
    {
        InvokeRepeating("SkoruArtir", 1f, 1f);
        highScoreText.text += SkorManager.HighScore.ToString();

    }

    void SkoruArtir()
    {
        AddScore(10);
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Skor: " + score;
    }
}
