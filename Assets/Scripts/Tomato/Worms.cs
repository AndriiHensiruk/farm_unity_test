using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worms : MonoBehaviour
{
    GameController gc;
    Tool tool;
    private Collider2D collider2D; 

    private SpriteRenderer renderer;
    private Rigidbody2D rigidbody;
    public float distance = 5f;
    float maxDistance, minDistance;
    public float speed = 1;
    private bool flag = false;
    public GameObject prefGlases;
    private Vector2 originalPosition, screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
        maxDistance = transform.position.x + distance;
        minDistance = transform.position.x - distance;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        gc.numWorms++;
        
        collider2D = GetComponent<Collider2D>();
    }


    void FixedUpdate()
    {
       
 
        transform.Translate(transform.right * speed * Time.deltaTime);
        

        if (transform.position.x > maxDistance)
        {
            renderer.flipX = true;
            speed = -speed;
        }


        if (transform.position.x < minDistance)
        {
            renderer.flipX = false;
            speed = -speed;
        }

    }

    private void Update()
    {
        if(!GameObject.FindGameObjectWithTag("Tools"))
            if (!flag)
            {
                Spawner(prefGlases);
                flag = true;
            }
          

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Jarglass")
        {
            
            renderer.flipY = true;
            speed = 0;

            

        }

    }

    void Spawner(GameObject gameObject)
    {
        Vector2 pos;

        float posX = -screenBounds.x;
        float posY = -screenBounds.y + 1;

        pos = new Vector2(posX, posY);
        Instantiate(gameObject, pos, gameObject.transform.rotation);
    }
}
