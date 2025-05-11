using UnityEngine;

public class Spawner10 : MonoBehaviour
{
    public GameObject arabaPrefab;
    public Sprite[] arabaSpritelari;
    public float spawnZamani = 1.5f;
    public float kontrolYaricapi = 0.5f; // Çakýþma kontrol yarýçapý

    private float[] seritler = new float[] { -10.91f, -8.51f };

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

        float rastgeleX = Random.Range(-444f, -380f);
        float secilenY = seritler[Random.Range(0, seritler.Length)];
        Vector3 pozisyon = new Vector3(rastgeleX, secilenY, 0f);

        // Çakýþma kontrolü
        Collider2D varOlan = Physics2D.OverlapCircle(pozisyon, kontrolYaricapi);
        if (varOlan != null)
        {
            // Orada zaten bir obje var, spawnlama
            return;
        }

        GameObject yeniAraba = Instantiate(arabaPrefab, pozisyon, Quaternion.Euler(0f, 0f, 270f));
        

        SpriteRenderer sr = yeniAraba.GetComponent<SpriteRenderer>();
        if (sr != null && arabaSpritelari.Length > 0)
        {
            sr.sprite = arabaSpritelari[Random.Range(0, arabaSpritelari.Length)];
        }

        if (yeniAraba.GetComponent<ArabaHareket>() == null)
        {
            yeniAraba.AddComponent<ArabaHareket>();
        }
    }
}
