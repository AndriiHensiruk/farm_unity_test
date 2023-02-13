using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : MonoBehaviour
{
    float speed = -1; // Display speed

    bool goForward, goBack = false;
    private Vector2 screenBounds, originalPosition; // screen size
    public GameObject prefUdder;
    private float posStateX, posStateY; //end point
    public int countGrass = 0;
    bool udder = false;
    CowManager cowManager;

    void Start()
    {
        //Determining the size of the game window
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        posStateX = screenBounds.x - 5;
        posStateY = -screenBounds.y;
        originalPosition = transform.position;

        cowManager = GameObject.FindGameObjectWithTag("CowManager").GetComponent<CowManager>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * speed * Time.deltaTime);
        if (transform.position.x < posStateX) goForward = true;
        if (countGrass == 3) 

        if (!udder)
        {
                prefUdder.SetActive(true);
                udder = true;
            
        }
        if (cowManager.countMilk >= 3)
        {
            goBack = true;
            goForward = false;

        }
        //if (GameObject.FindWithTag("Fish") && gc.numFish == fishCount)
        //{
        //    goBack = true;
        //    goForward = false;
        //}

        if (goForward) GoForward(); else if (goBack) GoBack();
    }

    //Moving forward
    void GoForward()
    {
        speed = 0;
    }

    //Moving back
    void GoBack()
    {
        speed = 2;

        Debug.Log("GoBack");

        Destroy(gameObject, 3f);

    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("Grass"))
        {
            countGrass++;

            Destroy(target.gameObject);

        }
    }
}
