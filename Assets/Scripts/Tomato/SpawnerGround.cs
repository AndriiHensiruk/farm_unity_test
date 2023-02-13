using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerGround : MonoBehaviour
{
     public int numberToSpawn;
    //Objects for svavan
    public GameObject prefGround;
    //plane on which spawning takes place
   
    private Vector2 screenBounds;


    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        spawnObjects();
    }

   public void spawnObjects()
    {
       
        Vector2 pos;
        float screenX, screenY;
       
        
        for (int i = 0; i < numberToSpawn; i++)
        {
           
                screenX = (-screenBounds.x + 7) + i*5;

                screenY = (-screenBounds.y / 2) ;
                pos = new Vector2(screenX, screenY);

                Instantiate(prefGround, pos, prefGround.transform.rotation);
            
          
           
        }
    }
}
