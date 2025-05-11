using UnityEngine;

public class Spawner8 : MonoBehaviour
{
    public GameObject arabaPrefab;
    public Sprite[] arabaSpritelari;
    public float spawnZamani = 1.5f;
    public float kontrolYaricapi = 0.5f; // Çakýþma kontrol yarýçapý


    private float[] seritler = new float[] { -8.5f, -10.7f };

    void Start()
    {
        InvokeRepeating(nameof(ArabaSpawnla), 1f, spawnZamani);
    }

    void ArabaSpawnla()
    {
        if (arabaPrefab == null)
        {
            Debug.LogWarning("arabaPrefab eksik, lütfen atayýn!");
            return;
        }

        float rastgeleX = Random.Range(-158.6f, -261f);
        int seritIndex = Random.Range(0, seritler.Length);
        float secilenY = seritler[seritIndex];
        Vector3 pozisyon = new Vector3(rastgeleX, secilenY, 0f);
        Collider2D varOlan = Physics2D.OverlapCircle(pozisyon, kontrolYaricapi);
        
        if (varOlan != null)
        {
            // Orada zaten bir obje var, spawnlama
            return;
        }
        
        GameObject yeniAraba = Instantiate(arabaPrefab, pozisyon, Quaternion.Euler(0f, 0f, 270f));
 
        

        // Sprite deðiþtir
        SpriteRenderer sr = yeniAraba.GetComponent<SpriteRenderer>();
        if (sr != null && arabaSpritelari.Length > 0)
        {
            sr.sprite = arabaSpritelari[Random.Range(0, arabaSpritelari.Length)];
        }

        // Hareket scripti ekle (varsa atlama)
        if (yeniAraba.GetComponent<ArabaHareket>() == null)
        {
            yeniAraba.AddComponent<ArabaHareket>();
        }
    }
}
