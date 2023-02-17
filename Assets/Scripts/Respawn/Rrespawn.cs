using UnityEngine;


public  class Rrespawn : MonoBehaviour
{

    public static Rrespawn Res;

    public Transform RespawnPoint;
    public GameObject PlayerPrefab;


    public static bool SpawnStart = true;
    public static bool SpawnPoint01 = false;
    public static bool RespawnPoint02 = false;


    
    private void Awake()
    {
        Res = this;
               
    }
    

    public  void RespawChekpoint()
    {

          if (SpawnStart == true)
        {
            GameObject player = Instantiate(PlayerPrefab, RespawnPoint.position, Quaternion.identity);
        }
        if ( SpawnPoint01 == true)
        {
            Respaw01.respaw01.Respawnpoin01();
        }
        if (RespawnPoint02 == true)
        {
            Respawn02._respawn02.RespawnPoint002();

        }
                
       
                               
    }


    


}
