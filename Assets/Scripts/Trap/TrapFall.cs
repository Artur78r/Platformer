using System.Collections;

using UnityEngine;

public class TrapFall : MonoBehaviour
{

    Rigidbody2D Rigiidbody;

    void Start()
    {
        Rigiidbody = GetComponent<Rigidbody2D>();
    }

    public IEnumerator DestroyTrap()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if( collision.gameObject.tag == "Player")
        {
            
            Rigiidbody.bodyType = RigidbodyType2D.Dynamic;

        }
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.tag == "Graund")
        {

            Rigiidbody.GetComponent<Renderer>().material.color = Color.white;

            StartCoroutine(DestroyTrap());
        }

        if (collision.gameObject.tag == "trap")
        {
            Rigiidbody.GetComponent<Renderer>().material.color = Color.white;

            StartCoroutine(DestroyTrap());
        }




    }



}
