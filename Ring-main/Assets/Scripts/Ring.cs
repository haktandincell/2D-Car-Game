using System.Collections.Generic;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;

public class ArabaKontrol : MonoBehaviour
{
    public float ileriHiz = 10f;
    public float donusHizi = 200f;
    public float normalDrift = 0.95f;
    public float elFreniDrift = 0.6f;
    public GameObject pointPopupPrefab;
    public Transform popupSpawnPoint;
    public bool sollandiMi = false;
    private HashSet<GameObject> sollananArabalar = new HashSet<GameObject>();
    public AudioSource kaynak;
    private float driftFaktoru;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.linearDamping = 1f;
        Vector3 worldPos = popupSpawnPoint.position;
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);

       
    }

    void FixedUpdate()
    {
        float ileriGeri = Input.GetAxis("Vertical");   // W/S veya ?/?
        float solaSaga = Input.GetAxis("Horizontal");  // A/D veya ?/?
        bool elFreni = Input.GetKey(KeyCode.Space);    // Space tuþuna basýldý mý?
        if (Mathf.Abs(ileriGeri) > 0.1f)
        {
            if (!kaynak.isPlaying)
                kaynak.Play();
        }
        else
        {
            if (kaynak.isPlaying)
                kaynak.Pause(); // ya da Stop() — fark: Stop baþa sarar
        }
        driftFaktoru = elFreni ? elFreniDrift : normalDrift;

        // Aracý ileri veya geri it
        rb.AddForce(transform.up * ileriGeri * ileriHiz);


        // Aracý döndür
        float hareketliMi = Vector2.Dot(rb.linearVelocity, rb.transform.up);
        if (hareketliMi > 0.1f || hareketliMi < -0.1f)
        {
            rb.MoveRotation(rb.rotation - solaSaga * donusHizi * Time.fixedDeltaTime);
        }

        // Drift etkisi: yana kayan hareketi azalt
        Vector2 ileriYonu = transform.up * Vector2.Dot(rb.linearVelocity, transform.up);
        Vector2 yanalYonu = transform.right * Vector2.Dot(rb.linearVelocity, transform.right);
        rb.linearVelocity = ileriYonu + yanalYonu * driftFaktoru;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Sollama1" || other.gameObject.name == "Sollama2")
        {
            GameObject anaAraba = other.transform.root.gameObject;

            // Zaten sollandýysa tekrar puan verme
            if (sollananArabalar.Contains(anaAraba)) return;

            // Ýlk kez sollanýyor, puaný ver
            sollananArabalar.Add(anaAraba);
            ScoreManager.Instance.AddScore(100);

            // Popup göster
            Vector3 worldPos = popupSpawnPoint.position;
            Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);

            GameObject popup = Instantiate(pointPopupPrefab, Vector3.zero, Quaternion.identity);
            popup.transform.SetParent(GameObject.Find("Canvas").transform, false);
            popup.GetComponent<RectTransform>().position = screenPos;
            Destroy(popup, 1.5f);
        }
    }


}
