using UnityEngine;

public class Yaya : MonoBehaviour
{
    public int hiz;
    Animator anim;
    public Sprite Ondensprite;
    public Sprite Arkadansprite;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }




    private void Update()
    {
        transform.Translate(Vector2.down * hiz * Time.deltaTime);
        if (transform.position.y < -20)
        {

            anim.SetBool("arkadanMi", true);
            transform.rotation = Quaternion.Euler(0f, 0f, 180f);
            GetComponent<SpriteRenderer>().sprite = Arkadansprite;
            
           

        }

        if (transform.position.y > -13)
        {
            anim.SetBool("arkadanMi", false);
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            GetComponent<SpriteRenderer>().sprite = Ondensprite;
         

        }
    }

    
}
