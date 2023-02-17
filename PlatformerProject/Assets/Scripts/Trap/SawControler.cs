using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawControler : MonoBehaviour
{

  [SerializeField] public float speedRotation = 1f;
   public float speedRunSaw = 1;
   
    public float posit1;
    public float posit2 ;

   public  bool RunLeftSaw = true ;
   public  bool RunRightSaw = false;


    

      
    private void FixedUpdate()
    {
                    
        Patrol();
        Rotation();
    }



    public void Rotation()
    {
        transform.Rotate(Vector3.forward * speedRotation);
    }


 
    public virtual void Patrol()
    {

       
        if ( RunLeftSaw == true )
        {
          
           transform.position = new Vector2(transform.position.x + speedRunSaw * Time.deltaTime , transform.position.y);
                
           if ( transform.position.x >= posit2 )
            {
                RunLeftSaw = false;
            }

        }

       if ( RunLeftSaw == false && RunRightSaw == false )
        {
            transform.position = new Vector2(transform.position.x - speedRunSaw * Time.deltaTime, transform.position.y);

            if ( transform.position.x <= posit1)
            {
                RunRightSaw = true;
            }
        }

       if ( RunRightSaw == true)
       {
           transform.position = new Vector2(transform.position.x + speedRunSaw * Time.deltaTime, transform.position.y);

         if ( transform.position.x >= posit2)
         {
            RunLeftSaw = true;
            RunRightSaw = false;
         }    
       }


    }
        




}
