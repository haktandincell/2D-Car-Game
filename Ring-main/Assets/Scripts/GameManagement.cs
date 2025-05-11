using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class GameManagement : MonoBehaviour
{
    public Image image;
    public Text text;
    ScoreManager scoreManager;
    Yaya yaya;
    public Animator animator;
    public GameObject pointPopupPrefab;
    public Transform popupSpawnPoint;
    public SkorManager skorManager;
    public AudioSource kaynak;


    void Start()
    {
        image.enabled = false; // Baþlangýçta resmi gizle
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("finish"))
        {
            Debug.Log("Bitiþ çizgisine ulaþýldý!");
            SkorManager.SetHighScore(ScoreManager.Instance.score);
            SceneManager.LoadScene(4);

        }

        if (other.CompareTag("Donus"))
        {
            image.enabled = !image.enabled;
        }

       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "NpcCars(Clone)")
        {
            kaynak.Play();
            StartCoroutine(SahneyiGecikmeliYukle());
        }
        if (collision.gameObject.CompareTag("Yaya"))
        {
            animator.enabled = false;
            Destroy(collision.gameObject,2f);
            ScoreManager.Instance.AddScore(-100);
            Vector3 worldPos = popupSpawnPoint.position;
            Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);

            GameObject popup = Instantiate(pointPopupPrefab, Vector3.zero, Quaternion.identity);
            popup.transform.SetParent(GameObject.Find("Canvas").transform, false);
            popup.GetComponent<RectTransform>().position = screenPos;
            Destroy(popup, 1.5f);

            Yaya yayaScript = collision.gameObject.GetComponent<Yaya>();

            if (yayaScript != null)
            {
                yayaScript.hiz = 0; // Hýzý sýfýrla
                Debug.Log("Yayaya çarpýldý, hareket durdu.");
            }
        }

    }

   
    IEnumerator SahneyiGecikmeliYukle()
    {
        yield return new WaitForSeconds(1f);
        SkorManager.SetHighScore(ScoreManager.Instance.score);
        SceneManager.LoadScene(3);
    }

}
