using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossElfAttack : MonoBehaviour
{

   

    public float RangeDistanseAtack;
    public float RangeSizeX;
    public float RangeSizeY;
    public BoxCollider2D BoCollider2D;
    public LayerMask PlayerLayer;


    private void Start()
    {
       
    }

    

    public void Update()
    {
        if (BoxBossElfAttack())
        {
            BossElf.bossElfClass.anim.SetTrigger("BossAttackPlayer");
        }


    }



    public bool BoxBossElfAttack ()
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










}
