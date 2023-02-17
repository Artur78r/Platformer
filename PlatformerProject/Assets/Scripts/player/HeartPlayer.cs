using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPlayer : MonoBehaviour
{

    public void Update()
    {
        Death();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {            
            player.playerClass.HPStrip.fillAmount = player.playerClass.FullHP;
            player.playerClass.FullHP = player.playerClass.FullHP - player.playerClass.damage;
            player.Anim.SetTrigger("DamagePlayer");
            player._Rigidbody2D.AddForce(transform.up * player.playerClass.Uron, ForceMode2D.Force);

        }
        if (collision.gameObject.tag == "trap")
        {
            player.playerClass.HPStrip.fillAmount = player.playerClass.FullHP;
            player.playerClass.FullHP = player.playerClass.FullHP - player.playerClass.damage;
            player.Anim.SetTrigger("DamagePlayer");
            player._Rigidbody2D.AddForce(transform.up * 8, ForceMode2D.Force);

        }

        if (collision.gameObject.tag == "Arrow")
        {
            player.playerClass.HPStrip.fillAmount = player.playerClass.FullHP;
            player.playerClass.FullHP = player.playerClass.FullHP - player.playerClass.damage;
            player.Anim.SetTrigger("DamagePlayer");
            player._Rigidbody2D.AddForce(transform.up * player.playerClass.Uron, ForceMode2D.Force);
        }

        


    }

    IEnumerator Damage()
    {
        player.playerClass.damage = 0;
        yield return new WaitForSeconds(1);
        player.playerClass.damage = 0.200f;
    }

    public void damagePlayer()
    {
        StartCoroutine(Damage());

    }



    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Heart")
        {
            if (player.playerClass.FullHP >= 1.000f) { }
            else
            {
                player.playerClass.FullHP = player.playerClass.FullHP + 0.200f;
            }


        }

    }

    public void Death()
    {
        player.playerClass.HPStrip.fillAmount = player.playerClass.FullHP;

        if (player.playerClass.FullHP <= 0)
        {
            StartCoroutine(GameOver());

        }

       

    }
    public IEnumerator GameOver()
    {
        player.Anim.SetTrigger("GameOver");


        yield return new WaitForSeconds(1);
        //Destroy(gameObject);
       // Destroy(gameObject);


        player.playerClass.HPStrip.fillAmount = player.playerClass.FullHP;
        player.playerClass.FullHP = 1.000f;


        RespawnPlayer(); 


    }




    public virtual void RespawnPlayer()
    {
        // Rrespawn.Res.RespawChekpoint();
        Respoint.respoitClass.TransformPoint();

    }







}
