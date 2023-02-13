using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Udder : MonoBehaviour
{
    public GameObject jarClass, woodBox;
   [SerializeField] MilkGlass milkGlass;
  
    private Vector2 screenBounds;
   public int countTouch = 0;
    bool touch = false;
    //Change me to change the touch phase used.
    TouchPhase touchPhase = TouchPhase.Ended;
  
    void Start()
    {
        //Setting the spawn position on the screen
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        

        for (int i = 0; i < 3; i++)
        {
            Vector2 pos = new Vector2(-screenBounds.x / 2+i*3, -screenBounds.y / 2);
            Instantiate(jarClass, pos, jarClass.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //We check if we have more than one touch happening.
        //We also check if the first touches phase is Ended (that the finger was lifted)
       
        if (touch) 
                if ((Input.touchCount > 0 && Input.GetTouch(0).phase == touchPhase))
        {
            Debug.Log("Touch");
                countTouch++;
        }
        

        //call the method to activate the milk in the jar
    }
    void OnMouseDown()
    {
        
       if(touch)
            countTouch++;
        Debug.Log("Touch");
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("MilkGlass"))
        {
            touch = true;
            countTouch = 0;

        }
    }
}
