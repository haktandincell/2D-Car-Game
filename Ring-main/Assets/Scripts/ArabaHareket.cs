using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class ArabaHareket : MonoBehaviour
{
    public float normalHiz = 5f;
    private float aktifHiz = 0f;

    private void Start()
    {
        aktifHiz = normalHiz;
    }

    void Update()
    {
        Vector2 origin = transform.position;
        Vector2 direction = transform.up;
        float mesafe = 20f;

        // Raycast at
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, mesafe);

        // Iþýný doðru çiz (origin + direction * mesafe)
        Debug.DrawLine(origin, origin + direction * mesafe, Color.red);

        if (hit.collider != null && hit.collider.gameObject != gameObject)
        {
         //   Debug.Log("Ray çarptý: " + hit.collider.name + " | Mesafe: " + hit.distance);
        }



        // Araba ileri hareket eder
        transform.Translate(Vector2.up * aktifHiz * Time.deltaTime);

        // "Yaya" tag'li objeye çarparsa dur
        if (hit.collider != null && hit.collider.gameObject != gameObject)
        {
            //Debug.Log("Ray çarptý: " + hit.collider.name + " | Mesafe: " + hit.distance);

            if (hit.collider.CompareTag("Yaya") && hit.distance < 5f) // örnek mesafe
            {
                aktifHiz = 0f;
            }
            else
            {
                aktifHiz = normalHiz;
            }
        }
        else
        {
            aktifHiz = normalHiz;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("destroy"))
            Destroy(gameObject);
        else if (other.CompareTag("destroy3"))
            transform.rotation = Quaternion.Euler(0f, 0f, 70f);
        else if (other.CompareTag("destroy4"))
            transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        else if (other.CompareTag("destroy2"))
            transform.rotation = Quaternion.Euler(0f, 0f, 120f);
        else if (other.CompareTag("destroy5"))
            transform.rotation = Quaternion.Euler(0f, 0f, 109f);
        else if (other.CompareTag("destroy6"))
            transform.rotation = Quaternion.Euler(0f, 0f, 290f);
        else if (other.CompareTag("destroy7"))
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        else if (other.CompareTag("destroy10"))
            transform.rotation = Quaternion.Euler(0f, 0f, 45f);
        else if (other.CompareTag("destroy9"))
            transform.rotation = Quaternion.Euler(0f, 0f, 290f);
        else if (other.CompareTag("destroy11"))
            transform.rotation = Quaternion.Euler(0f, 0f, 270f);
        else if (other.CompareTag("destroy12"))
            transform.rotation = Quaternion.Euler(0f, 0f, 250f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ring"))
        {
            StartCoroutine(SahneyiGecikmeliYukle());
        }

        
    }


    IEnumerator SahneyiGecikmeliYukle()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(3);
    }
}
