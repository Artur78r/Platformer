using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy1 : MonoBehaviour
        
{
    public static Enemy1 _Enemy1;


    Rigidbody2D _rigidbody2D;
    Animator anim;

    public float speed = 1f;
    public float pos1 = 28.7f;
    public float pos2 = 33.6f;
    bool moveRight = true;
    bool moveLeft = false;


    public float ColliderDistance; 
    public float sizeAxisX;
    public float sizeAxisY;
    public BoxCollider2D BoxxCollider2D; // сама коробка 
    public LayerMask playerLayer;  // слой игока 

       
    public Transform player;


    
    public float FullHp =  0.5f;
    public float Damage;
    public Transform HP;






    void Start()
    {
        _rigidbody2D = GetComponent < Rigidbody2D > ();
        anim = GetComponent<Animator>();
        // player = GameObject.FindGameObjectWithTag("Player").transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;


        _Enemy1 = this; 
    }

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }



    public void FixedUpdate()
    {

        
        
        if (EnemyAttack())
        {
            anim.SetTrigger("ElfAttack");
            Agresive();

        }
        else
        {
            Patrul();
            flip();
        }

    }



    public void Agresive()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

        if (transform.position.x < player.position.x)
        {
            transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        }
        if (transform.position.x > player.position.x)
        {

            transform.localScale = new Vector3(-0.3f, 0.3f, 0.3f);
        }


    }

    




    public void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Sword")
        {
           
           _rigidbody2D.AddForce(transform.up * 4, ForceMode2D.Impulse);

           
            FullHp = FullHp - Damage;
            HP.transform.localScale = new Vector3(FullHp, 0.45f, 0);

            if (FullHp <= 0)
            {
                StartCoroutine(Die());
                Damage = 0f;
            }
        }

        if (collision.gameObject.tag == "Apple")
        {

            _rigidbody2D.AddForce(transform.up * 2, ForceMode2D.Impulse);


            FullHp = FullHp - Damage;
            HP.transform.localScale = new Vector3(FullHp, 0.45f, 0);

            if (FullHp <= 0)
            {
                StartCoroutine(Die());
                Damage = 0f;
            }
        }




    }

    



    public bool EnemyAttack()
    {
        RaycastHit2D hit =
            Physics2D.BoxCast(BoxxCollider2D.bounds.center + transform.right * ColliderDistance * transform.localScale.x ,
            new Vector3(BoxxCollider2D.bounds.size.x * sizeAxisX, BoxxCollider2D.bounds.size.y * sizeAxisY, BoxxCollider2D.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        return hit.collider != null;
    }


    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(BoxxCollider2D.bounds.center + transform.right * ColliderDistance * transform.localScale.x ,
            new Vector3(BoxxCollider2D.bounds.size.x * sizeAxisX, BoxxCollider2D.bounds.size.y * sizeAxisY, BoxxCollider2D.bounds.size.z));
    }





    public IEnumerator Die()
    {
        anim.SetTrigger("DieElf");
        _rigidbody2D.GetComponent<Renderer>().material.color = Color.red;
        speed = 0;
       
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
        

    }



    public void flip()
    {

        if ( moveRight == true)
        {
          
            transform.localScale = new Vector3(0.3f,0.3f,0.3f);

        }
        if(moveRight == false)
        {
            
            transform.localScale = new Vector3( -0.3f , 0.3f, 0.3f);

        }

        


    }



    public void Patrul()
    {
        

        if (moveRight == true)
        {

             _rigidbody2D.transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (transform.position.x >= pos2)
            {
                moveRight = false;
            }

        }

        if (moveLeft == false && moveRight == false)
        {
           
            _rigidbody2D.transform.Translate(Vector2.left * speed * Time.deltaTime);

            if (transform.position.x <= pos1)
            {

                moveLeft = true;
            }

        }

        else if (moveLeft == true)
        {
            
            _rigidbody2D.transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (transform.position.x <= pos2)
            {

                moveRight = true;
                moveLeft = false;

            }


        }
    }


  





    


  



}
