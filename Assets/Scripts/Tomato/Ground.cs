using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public GameObject toolObjekt;

    public GameObject prefSpownObjekt;

    private Vector2 originalPosition;
    int calkDestroi;
    private Vector2 screenBounds;
    private float posStateX;
    bool stop = false;
  
    GameController gc;


    // Start is called before the first frame update
    void Start()
    {
       
        originalPosition = transform.position;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        Vector2 pos;
        pos = new Vector2(screenBounds.x-3, -screenBounds.y+3);
        Instantiate(toolObjekt, pos, prefSpownObjekt.transform.rotation);
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

       
    }

    


   
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag( "Tools"))
        {
            Destroy(gameObject);
            Instantiate(prefSpownObjekt, transform.position, prefSpownObjekt.transform.rotation);
            // Debug.Log("Worck");

            gc.graund++;
        }

    }

}
