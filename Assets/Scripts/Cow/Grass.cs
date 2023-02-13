using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
    float speed = -2; // Display speed

    bool goForward, goBack = false;
    private Vector2 screenBounds, pos; // screen size

    private float posStateX, posStateY; //end point
    // Start is called before the first frame update
    void Start()
    {
        //Determining the size of the game window
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        posStateX = -screenBounds.x + 5;
       
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.up * speed * Time.deltaTime);

        if ((transform.position.x > posStateX)) speed = 0;
       
    }

}
