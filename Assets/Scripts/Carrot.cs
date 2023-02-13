using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    GameController gc;

    private Collider2D collider2D;
    private SpriteRenderer renderer;
    private Vector2 originalPosition, screenBounds;
   
    public GameObject prefBasket;

    private bool flag = false;

    


    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        renderer = GetComponent<SpriteRenderer>();
       
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        gc.numVegetables++;

        collider2D = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0))
        {
         
            Debug.Log("TOUCH");
            Destroy(GameObject.FindGameObjectWithTag("Rock"));

            return;
        }
        // Search for objects by name
        if (!GameObject.FindGameObjectWithTag("Rock") && !GameObject.FindGameObjectWithTag("Tools"))
            if (!flag)  //stop spawning
            {
                SpawnerBasket(prefBasket);
                flag = true;
            }



    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Basket")
        {
            renderer.flipY = true;

            collider2D.enabled = false;

        }

    }
   

    void SpawnerBasket(GameObject gameObject)
    {
        Vector2 pos;

        float posX = -screenBounds.x;
        float posY = -screenBounds.y + 1;

        pos = new Vector2(posX, posY);
        Instantiate(gameObject, pos, gameObject.transform.rotation);
    }
}
