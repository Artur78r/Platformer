using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossElf : MonoBehaviour
   
{
  public static  BossElf bossElfClass;

    private float CocooldownTime = Mathf.Infinity;
    [SerializeField] private float TimeShoting;

    Rigidbody2D Rigidbodyyy2D;
    public Animator anim;

    public Transform Player;

    public float RangeDistanseAtack;
    public float RangeSizeX;
    public float RangeSizeY;
    public BoxCollider2D BoCollider2D;
    public LayerMask PlayerLayer;


    public float FullHp = 0.95f;
    public float Damage = 0.01f;
    public Transform HP;
    


    void Start()
    {
        Rigidbodyyy2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        bossElfClass = this;
    }

    private void Update()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }




    private void FixedUpdate()
    {
          Flip();
           
        if (BoxBossElf())
        {
            callingTheFighters();
        }
    }




    public void callingTheFighters()
    {

        CocooldownTime += Time.deltaTime;

        if (CocooldownTime >= TimeShoting)
        {
            anim.SetTrigger("BossAttack");
           
            CocooldownTime = 0f;
        }
           

    }
       

    public void openDoor()
    {
      DoorZamka.doorZamkaClass.OpenDoor();
    }






    public bool BoxBossElf()
    {
        RaycastHit2D hit =
           Physics2D.BoxCast(BoCollider2D.bounds.center + transform.right * RangeDistanseAtack * transform.localScale.x,
           new Vector3(BoCollider2D.bounds.size.x * RangeSizeX, BoCollider2D.bounds.size.y * RangeSizeY, BoCollider2D.bounds.size.z),
           0, Vector2.left, 0, PlayerLayer);

        return hit.collider != null;
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(BoCollider2D.bounds.center + transform.right * RangeDistanseAtack * transform.localScale.x,
           new Vector3(BoCollider2D.bounds.size.x * RangeSizeX, BoCollider2D.bounds.size.y * RangeSizeY, BoCollider2D.bounds.size.z));
    }

    public void Flip ()
    {

        if (transform.position.x > Player.position.x)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);

        }
        if (transform.position.x < Player.position.x)
        {

            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }



    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Sword")
        {
            FullHp = FullHp - Damage;
            HP.transform.localScale = new Vector3(FullHp, 0.95f, 0);


            if( FullHp <= 0)
            {
                Damage = 0;
                anim.SetTrigger("DieBoss");

            }



        }
    }



    public void Destroy()
    {
        Destroy(gameObject);
        Block.BlockClass.DestroyBlock();
    }




}



