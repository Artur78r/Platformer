using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appel : MonoBehaviour
{
    Rigidbody2D Rigidbody;
    public float SpeedAppel;

    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();

    }

    public void FixedUpdate()
    {
        Rigidbody.transform.Translate(Vector2.right * SpeedAppel * Time.deltaTime);
        StartCoroutine(DestroyAppel());
        
    }

    public IEnumerator DestroyAppel()
    {

        yield return new WaitForSeconds(8);
        Destroy(gameObject);

    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Graund")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }

    }




}
