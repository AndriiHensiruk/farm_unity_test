using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockApple : MonoBehaviour
{
    public GameObject shonelTool;

    int countDestroy = 0;
    private Vector2 screenBounds;
    
    void Start()
    {
       
       
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        Vector2 pos = new Vector2(screenBounds.x - 3, -screenBounds.y + 3);
      Instantiate(shonelTool, pos, shonelTool.transform.rotation);


    }
    private void Update()
    {
        if (countDestroy > 3) {
            Destroy(gameObject);
           
        }
            
     
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
       

        if (target.gameObject.tag == "Tools")
        {
            countDestroy++;
        }
    }


}
