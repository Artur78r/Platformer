using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SborkaSripts : MonoBehaviour
{
    // физическе свойства
    Rigidbody2D RigBod2d;
    Animator anim;

    // позиция выстреа у персонажа 
    public Transform PositionPatron;
    // префаб патронов 
    public GameObject patro;
    // активация выстрел 
    public bool PatronON = true;
    
    public float Speed;
    public float Jamp;
    public float normalSpeed;

    // отключение пыржка в воздухе 
    public bool Graund;


    // метод запуска каутины патрона 
    public void StartCarutinee()
    {
        // страрт крутины патрона 
        StartCoroutine(patronOnn());
    }





    // метод генерации  врагов 


    public void startEmemy()
    {
        // запуск карутины врагов 
        StartCoroutine(GeneratorVragov());
    }

    public GameObject enemy;
    public IEnumerator GeneratorVragov()
    {
        while (true)
        {                                       //позиция X          Y
            Instantiate(enemy, new Vector2(Random.Range(-20f, 20f), 20f), Quaternion.identity );
            yield return new WaitForSeconds(1);

        }
    }







    // метод вытрелла 
     public IEnumerator patronOnn()
    {
        PatronON = false;
        // создание патрона 
        Instantiate(patro, PositionPatron.position, transform.rotation);
        //создание карутины 
        yield return new WaitForSeconds(1);
        PatronON = true;

    }


   

    public void Start()
    {
        RigBod2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    public void Update()
    {
    }


    public void FixedUpdate()
    {
        // реализация движение персонажа по горизонтали 
        float HorizontalInput = Input.GetAxis("Horizontal");
        RigBod2d.velocity = new Vector2(HorizontalInput * Speed, RigBod2d.velocity.y);


        anim.SetBool("Run", HorizontalInput!= 0);
        anim.SetBool("Graund", Graund);

        //реализация прыжка 
        if (Input.GetKey(KeyCode.Space))
        {
            RigBod2d.velocity = new Vector2(RigBod2d.velocity.x, Jamp);
            // вариант с добавлением силы персонажу 
            RigBod2d.AddForce(transform.up * Jamp, ForceMode2D.Impulse);

            
            anim.SetTrigger("Jamp");
        }


        // реализания поворота персонажа
        if (Speed > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (Speed < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }

        // вариант через вектор 
        if (HorizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        if (HorizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        
    }




   // реализация кнопок движения 
    public void LeftRun()
    {
        if (Speed >= 0.0f)
        {
            Speed = -normalSpeed;
        }
    }

    public void RightRun()
    {
        if (Speed <= 0f)
        {
            Speed = normalSpeed;
        }
    }


    public void StopRun()
    {
        Speed = 0;
    }
    
    
    
    // реализация кнопки прыжка 
    public void Jamping()
    {
        RigBod2d.AddForce(transform.up * Jamp, ForceMode2D.Impulse);

    }





    // реализация одного прыжка от земли 
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.tag == "имя тега")
        {
            Graund = true;
        }

    }

    // метод к которому привязывается collision
    public void Jamping2()
    {
        if ( true && Graund)
        {
            RigBod2d.AddForce(transform.up * Jamp, ForceMode2D.Impulse);
            Graund = false;
        }

    }


    /*
 * опсание скрипта врагов ---------------------------------------------------------------

      Rigidbody2D rbod;
    public Transform player;


    public float speed = 2;
    public float agroDist = 5f;
    public float aaaai = 5;

    void Start()
    {
        rbod = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (distToPlayer < agroDist)
       {
            startHung();
       }
       else
       {
            stopHung();
        }

        

    }




    public void startHung()
    {
        if(player.position.x > transform.position.x)
       {
            rbod.velocity = new Vector2(speed, 0);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
       else if(player.position.x < transform.position.x)
       {
            rbod.velocity = new Vector2(-speed, 0);
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }

    public void stopHung()
    {
        rbod.velocity = new Vector2(rbod.velocity.x, rbod.velocity.y);
    }



    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fireboll")
        {
            rbod.GetComponent<Renderer>().material.color = Color.red;
            rbod.velocity = new Vector2(rbod.velocity.x , rbod.velocity.y * aaaai);
            StartCoroutine(distroi());

            Debug.Log("произошло столкновение");
        }
    }





    public IEnumerator distroi()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);







    описание скрипта выстрелов -------------------------------------------------------

     public float speedbol = 10f;

    public void Start()
    {
        StartCoroutine(death());
    }

    private void Update()
    {
        transform.Translate(Vector2.right * speedbol * Time.deltaTime);

      
    }


    public IEnumerator death()
    {
        yield return new WaitForSeconds(8);
        Destroy(gameObject);
    }



    public void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    




    описание скрипта камеры -----------------------------------------------
    public Transform player;
    public float speedcam;
    public Vector3 pos;
    

    private void Awake()
    {
        if(!player)
        {
            player = FindObjectOfType < Goblin >().transform;
        }
    }

     
    void Update()
    {
        pos = player.position;
        pos.z = -10f;
        
        
        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * speedcam );
    }























*/








}

















