using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{

    Animator animatorFireball;
    Rigidbody2D rigidbody2DFireaball;
    Transform Player2;


    player traget;
    Vector2 vector2Fireball;

    public float SpeedFireball = 7f;
    public bool CheckGraund = false;



   public void Start()
    {
        rigidbody2DFireaball = GetComponent<Rigidbody2D>();
        animatorFireball = GetComponent<Animator>();
        traget = GameObject.FindObjectOfType<player>();

        shootingFireballs();

        if (CheckGraund == false)
        {
            shootingFireballs();

        }
        else
        {
            SpeedFireball = 0f;
        }
               


    }

    public void FixedUpdate()
    {
        DestroyFireball();
     
    }


    

    public void shootingFireballs()
    {
        vector2Fireball = (traget.transform.position - transform.position).normalized * SpeedFireball;
        rigidbody2DFireaball.velocity = new Vector2(vector2Fireball.x, vector2Fireball.y);

    }





    public IEnumerator DestroyFireball()
    {
        yield return new WaitForSeconds(8);
        Destroy(gameObject);


    }








    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Graund")
        {
            CheckGraund = true;
           animatorFireball.SetTrigger("ExplosionFireball");
           
        }
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Sword")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }



    }


    public void ExplosionDestoy()
    {
        Destroy(gameObject);
    }






}
