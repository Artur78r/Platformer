using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSorcer : MonoBehaviour
{
    Animator animatorBoss;
    Rigidbody2D Rigidbody2DBoss;
    public Transform Player2;
    public Transform healthStrip;
    public Transform FierballPosition;
    public GameObject fierboall;
    Vector3 PosBoss;


    public float ColliderDistance;
    public float sizeAxisX;
    public float sizeAxisY;
    public BoxCollider2D BoxxCollider2D; 
    public LayerMask playerLayer;  


    public float SpeedBoss;
    public float health = 0.99f;
    public float Damage = 0.05f;
    


    private void Start()
    {
        Rigidbody2DBoss = GetComponent<Rigidbody2D>();
        animatorBoss = GetComponent<Animator>();
        Player2 = GameObject.FindGameObjectWithTag("Player").transform;

    }


    private void FixedUpdate()
    {
        if(BossAttack())
        {
            Attack();
            PositionBoss();
            Flip();

        }
        else
        {
            PositionBoss();
            Flip();
            Harassment();
        }
        
        
        
        
       
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
       if ( collision.gameObject.tag == "Sword")
        {
            health = health - Damage;
            healthStrip.transform.localScale = new Vector3(health, 0.96f, 0);

        }

    }


    public void Attack()
    {

        animatorBoss.SetTrigger("AttackTrigger");
    
    }


    public void AttackMomentAnimation()
    {
        // Instantiate(fierboall, FierballPosition.position, transform.rotation);
        Instantiate(fierboall, FierballPosition.position, transform.rotation);
    }


    public bool BossAttack()
    {
        RaycastHit2D hit =
            Physics2D.BoxCast(BoxxCollider2D.bounds.center + transform.right * ColliderDistance * transform.localScale.x,
            new Vector3(BoxxCollider2D.bounds.size.x * sizeAxisX, BoxxCollider2D.bounds.size.y * sizeAxisY, BoxxCollider2D.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        return hit.collider != null;
    }


    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(BoxxCollider2D.bounds.center + transform.right * ColliderDistance * transform.localScale.x,
            new Vector3(BoxxCollider2D.bounds.size.x * sizeAxisX, BoxxCollider2D.bounds.size.y * sizeAxisY, BoxxCollider2D.bounds.size.z));
    }



    public void Harassment()
    {        
        transform.position = Vector2.MoveTowards(transform.position,  Player2.position, SpeedBoss * Time.deltaTime);
    }

    public void Flip()
    {
        if (transform.position.x < Player2.position.x)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (transform.position.x > Player2.position.x)
        {
           transform.localRotation = Quaternion.Euler(0, 180, 0);
        }

    }

    public void PositionBoss()
    {
        PosBoss.y = 2f;

        transform.localPosition = new Vector3(transform.position.x, PosBoss.y, transform.position.z);
    }




}
