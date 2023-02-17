using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{


    public float speedArrow;

    Rigidbody2D rigiidbody2D;


    public void Start()
    {
        rigiidbody2D = GetComponent<Rigidbody2D>();
    }



    public void FixedUpdate()
    {
        rigiidbody2D.transform.Translate(Vector2.left * speedArrow * Time.deltaTime);
        StartCoroutine(DestroyArrow());
    }


    public IEnumerator DestroyArrow()
    {

        yield return new WaitForSeconds(8);
        Destroy(gameObject);

    }





    public void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.tag == "Graund")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Sword")
        {
            Destroy(gameObject);
        }
    }





}
