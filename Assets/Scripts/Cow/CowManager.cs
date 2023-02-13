using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowManager : MonoBehaviour
{
    // objects for spawning on stage
    public GameObject prefCow;
    public GameObject prefGrass;
    public int countMilk = 0;
 
     bool Flag = false;
    private Vector2 screenBounds;

    void Start()
    {
        // start of spawning with the definition of starting points
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        Vector2 pos1;
        pos1 = new Vector2(screenBounds.x + 3, -screenBounds.y + 3);
        Instantiate(prefCow, pos1, prefCow.transform.rotation);

        for (int i=0; i<3; i++)
        {
            Vector2 pos;
            pos = new Vector2(-screenBounds.x - 3*i, -screenBounds.y + 3);
            Instantiate(prefGrass, pos, prefGrass.transform.rotation);
        }
       
    }

   
    void Update()
    {
        
            
            
        
    }


}
