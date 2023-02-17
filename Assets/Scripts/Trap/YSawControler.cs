using UnityEngine;

public class YSawControler : SawControler
{


    private void FixedUpdate()
    {
        Patrol();
        Rotation();
    }

    public override void Patrol()
    {

        if (RunLeftSaw == true)
        {

            transform.position = new Vector2(transform.position.x, transform.position.y + speedRunSaw * Time.deltaTime );

            if (transform.position.y >= posit2)
            {
                RunLeftSaw = false;
            }

        }

        if (RunLeftSaw == false && RunRightSaw == false)
        {
            transform.position = new Vector2( transform.position.x, transform.position.y - speedRunSaw * Time.deltaTime);

            if (transform.position.y <= posit1)
            {
                RunRightSaw = true;
            }
        }

        if (RunRightSaw == true)
        {
            transform.position = new Vector2( transform.position.x,  transform.position.y + speedRunSaw * Time.deltaTime);

            if (transform.position.y >= posit2)
            {
                RunLeftSaw = true;
                RunRightSaw = false;
            }
        }

    }



}
