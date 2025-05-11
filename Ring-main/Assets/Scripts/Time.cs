using UnityEngine;
using TMPro; // TextMeshPro kullanýyorsan
using UnityEngine.SceneManagement; 

public class Times : MonoBehaviour
{
    public float toplamSure = 10f;
    public TextMeshProUGUI zamanText; // Eðer normal Text kullanýyorsan Text kullan

    private float kalanSure;
    private bool sayacAktif = true;

    void Start()
    {
        kalanSure = toplamSure;
    }

    void Update()
    {
        if (sayacAktif)
        {
            kalanSure -= Time.deltaTime;
            if (kalanSure <= 0)
            {
                kalanSure = 0;
                sayacAktif = false;
                SceneManager.LoadScene(2); // GameOver sahnesine geçiþ yap
               

            }
            zamanText.text = "Kalan Süre: "+Mathf.CeilToInt(kalanSure).ToString();
        }
    }
}
