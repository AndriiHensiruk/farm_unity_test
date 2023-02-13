using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    MoleManager manager;
    public GameObject funnelTool, seedlingPref;
    private Vector2 screenBounds;
    bool flag = false;
  
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("MoleManager").GetComponent<MoleManager>();
       
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        manager.rockCount++;


    }
    private void Update()
    {
        //Defining the position for spawning on the screen
        if (!flag)
        {
            Vector2 pos;
            pos = new Vector2(screenBounds.x - 1, -screenBounds.y + 3);

            if ((manager.rockCount == 9) && (!GameObject.FindGameObjectWithTag("Packeg")))
            {
                Instantiate(funnelTool, pos, funnelTool.transform.rotation);
                flag = true;
            }

              
        }
       
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
       

        if (target.gameObject.tag == "Tools")
        {
            Instantiate(seedlingPref, transform.position , seedlingPref.transform.rotation);
        }
    }


}
