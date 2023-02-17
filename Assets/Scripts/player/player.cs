using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{

    public static player playerClass;
    public static Rigidbody2D _Rigidbody2D;
    public static Animator Anim;

    bool PlayerGraunded;
    bool PlayerJampAnim = false ;
   
    public float speed = 0;
    public float normalSpeed = 10;
    public float jamp = 15;
    private bool graund = true;
    public float Uron = 4;
   

    public Image HPStrip;
    public  float FullHP = 1.000f;
    public float damage = 0.150f;


    public void Awake()
    {
        playerClass = this;
    }

    void Start()
    {        
        _Rigidbody2D = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
                    
    }
     
      

    public void FixedUpdate()
    {       
        _Rigidbody2D.velocity = new Vector2(speed, _Rigidbody2D.velocity.y);

        AnimatorPlayer();
        testGame();
    }


    public void AnimatorPlayer()
    {
        Anim.SetBool("PlayerRun", speed != 0.0f);
        Anim.SetBool("jampPlayer", PlayerJampAnim == true);
                      
    }

    
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Graund")
        {
            graund = true;
            PlayerGraunded = true;
            PlayerJampAnim = false;
        }


        if (collision.gameObject.name.Equals("MovingPlatform"))
        {
            this.transform.parent = collision.transform;
        }


    }


    public void OnCollisionExit2D(Collision2D collision)
    {
        if( collision.gameObject.name.Equals ("MovingPlatform"))
        {
            this.transform.parent = null;
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Sing")
        {
            SceneManager.LoadScene(1);
        }

    }


    public void Menu()
    {
        SceneManager.LoadScene(0);
    }


    public void TakeDamage()
    {
       Destroy(gameObject);
    }


    public void ButtonAttask()
    {
        Anim.SetTrigger("PlayerAttack");
    }

  

    public void ButtonLeft()
    {
        if( speed >= 0.0f)
        {
            speed = normalSpeed;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
           
        }
    }

    public void ButtonRight()
    {
        if (speed <= 0.0f)
        {
            speed = -normalSpeed;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }   
    }


    public void ButtonStopRun()
    {
        speed = 0f;        
    }

    public void ButtonJamp()
    {
        if (true && graund)
        {
             _Rigidbody2D.velocity = new Vector2(_Rigidbody2D.velocity.x, jamp);

            graund = false;
            PlayerJampAnim = true;
              
            
        }
    }

   
    public void testGame()
    {
      if( Input.GetKeyDown(KeyCode.D))
        {
            ButtonLeft();
        }
       else if ( Input.GetKeyUp(KeyCode.D))
        {
            ButtonStopRun();
        }

      if ( Input.GetKeyDown(KeyCode.A))
        {
            ButtonRight();
        }
      else if( Input.GetKeyUp(KeyCode.A))
        {
            ButtonStopRun();
        }


      if ( Input.GetKeyUp(KeyCode.Space))
        {
            ButtonJamp();
        }


    }

   




}
