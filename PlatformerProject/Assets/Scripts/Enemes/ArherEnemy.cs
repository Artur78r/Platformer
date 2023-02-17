using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArherEnemy : MonoBehaviour
{


    [SerializeField] private Transform postionArrow;
    [SerializeField] private GameObject Arrow;
    [SerializeField] private  float TimeShoting;
    private float CocooldownTime = Mathf.Infinity;


    private  Animator anim;
    private  Rigidbody2D rigidbody2d;


    public float RangeDistanseAtack;
    public float RangeSizeX;
    public float RangeSizeY;
    public BoxCollider2D BoCollider2D;
    public LayerMask PlayerLayer;


    [SerializeField] private float speedArchar;
    [SerializeField] private Transform Player;


    [SerializeField] private float FullHp;
    [SerializeField]  private float Damage;
    [SerializeField] private Transform HP;




    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        
       
      
    }

    private void Update()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }





    private  void FixedUpdate()
    {
        if (EnemyArherBox())
        {
            retreat();
            Flip();
            Attack();
        }
        else
        {

        }

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Sword")
        {

            FullHp = FullHp - Damage;
            HP.transform.localScale = new Vector3(FullHp, 0.45f, 0);
            if ( FullHp <=0)
            {
                anim.SetTrigger("DieArther");

                Damage = 0;
                CocooldownTime = 0;
                StartCoroutine(Die());
            }

        }

        if(collision.gameObject.tag == "trap")
        {
            anim.SetTrigger("DieArther");
            StartCoroutine(Die());
        }

        if (collision.gameObject.tag == "Apple")
        {

            FullHp = FullHp - Damage;
            HP.transform.localScale = new Vector3(FullHp, 0.45f, 0);
            if (FullHp <= 0)
            {
                anim.SetTrigger("DieArther");

                Damage = 0;
                CocooldownTime = 0;
                StartCoroutine(Die());
            }

        }




    }


    private IEnumerator Die()
    {
        
        yield return new WaitForSeconds(2);
        Destroy(gameObject);

    }

    private void Attack()
    {
        CocooldownTime +=Time.deltaTime;
        

        if (CocooldownTime >= TimeShoting)
        {
            anim.SetTrigger("AttackArcher");
            CocooldownTime = 0f;
        }
    }

    public void AttackMoment()
    {
        Instantiate(Arrow, postionArrow.position, transform.rotation);
    }




    private void retreat()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.position, -speedArchar * Time.deltaTime);
        anim.SetTrigger("RunArcher");


    }


    public  bool EnemyArherBox()
    {
        RaycastHit2D hit =
           Physics2D.BoxCast(BoCollider2D.bounds.center + transform.right * RangeDistanseAtack * transform.localScale.x,
           new Vector3(BoCollider2D.bounds.size.x * RangeSizeX, BoCollider2D.bounds.size.y * RangeSizeY, BoCollider2D.bounds.size.z),
           0,Vector2.left , 0 , PlayerLayer);

             return hit.collider != null;

    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(BoCollider2D.bounds.center + transform.right * RangeDistanseAtack * transform.localScale.x,
           new Vector3(BoCollider2D.bounds.size.x * RangeSizeX, BoCollider2D.bounds.size.y * RangeSizeY, BoCollider2D.bounds.size.z));
    }
       

    private void Flip()
    {

        if(transform.position.x > Player.position.x)
        {
           transform.localRotation = Quaternion.Euler(0, 0, 0);

        }
        if(transform.position.x < Player.position.x)
        {
            
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }

    }



}
