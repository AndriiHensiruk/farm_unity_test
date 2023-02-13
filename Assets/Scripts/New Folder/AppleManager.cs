using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleManager : MonoBehaviour
{
    //Objects for spawning
    public GameObject prefHole, prefRoke;

    //screen size
    private Vector2 screenBounds, originalPositionHole, originalPositionRoke;
    private float posStateX, posStateY;

    // Start is called before the first frame update
    void Start()
    {
        //Determining the size of the game window
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        //setting the spawn point
        posStateX = screenBounds.x / 2 - 5;
        posStateY = screenBounds.y / 2 - 6;
        originalPositionHole = new Vector2(posStateX, posStateY);

        Instantiate(prefHole, originalPositionHole, prefHole.transform.rotation);

        originalPositionRoke = new Vector2(posStateX, posStateY + 1);
        Instantiate(prefRoke, originalPositionRoke, prefRoke.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
