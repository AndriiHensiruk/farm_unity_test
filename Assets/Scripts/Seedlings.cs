using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seedlings : MonoBehaviour
{
    private Collider2D collider2D;

    public GameObject toolObjekt;

    public int numberToSpawn = 5;
    public GameObject prefSpownObjekt;

    private bool angry, chill = false;

    private Vector2 originalPosition;
    public int cheakWoater;
    bool flag = false;
    private Vector2 screenBounds, pos;


    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        collider2D = GetComponent<Collider2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
      
        pos = new Vector2(screenBounds.x - 3, -screenBounds.y + 3);

    }

    // Update is called once per frame
    void Update()
    {
       
       

        if (cheakWoater == 2 )
        {
            if (!flag)
            {
                float x = transform.position.x;
                float y = transform.position.y;
                Vector2 pos;

                for (int i = 0; i < numberToSpawn; i++)
                {
                    float posX = Random.Range(-x, x);
                    float posY = Random.Range(-y, y);

                    pos = new Vector2(posX, posY+i);
                    Instantiate(prefSpownObjekt, pos, prefSpownObjekt.transform.rotation);
                }
                   
                flag = true;
            }
        }

    }

   

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Holes") && !GameObject.FindGameObjectWithTag("Packeg"))
        {
            Vector2 pos;
            pos = new Vector2(screenBounds.x - 3, -screenBounds.y + 3);
            Instantiate(toolObjekt, pos, prefSpownObjekt.transform.rotation);

        }

        if (collision.CompareTag("Tools"))
        {
            cheakWoater++;
        }

    }
}
