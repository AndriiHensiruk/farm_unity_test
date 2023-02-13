using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunnelTool : MonoBehaviour
{
    private Collider2D collider2D;

    GameController gc;

    public GameObject prefObjekt;

    private bool worck, goBack = false;

    private Vector2 originalPosition, screenBounds;
    float speed = 5;
    public int wolckAwei = 0;
    void Awake()
    {
        FunnelTool[] controllers = FindObjectsOfType<FunnelTool>();
        if (controllers.Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
   
    void Start()
    {
        originalPosition = transform.position;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        collider2D = GetComponent<Collider2D>();
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 1))
        {
            return;
        }


        if (Vector2.Distance(transform.position, prefObjekt.transform.position) <= 1)
        {
            worck = true;
            goBack = false;
        }

        if (Vector2.Distance(transform.position, prefObjekt.transform.position) >= 1)
        {
            worck = false;

        }
        if (Vector2.Distance(transform.position, originalPosition) < 1 && worck == false)
        {
            goBack = true;
        }

        if (goBack) GoBack(); else if (worck) Worck();

        //Destruction of the object after completing the task
        if (gc.numRock == 9)
        {
            Vector2 pos;
            pos = new Vector2(screenBounds.x+3, transform.position.y);
            originalPosition = pos;
           collider2D.enabled = false;
            gc.numRock = 9;
            if(Vector2.Distance(transform.position, pos) >=1) Destroy(gameObject, 3f);
            
        }

        if (gc.numVegetables > 9)
        {
            Vector2 pos;
            pos = new Vector2(screenBounds.x + 3, transform.position.y);
            originalPosition = pos;
            collider2D.enabled = false;
            
            if (Vector2.Distance(transform.position, pos) >= 1) Destroy(gameObject, 3f);
        }

        

    }

    //Moving 
    void GoBack()
    {
        transform.position = Vector2.MoveTowards(transform.position, originalPosition, speed * Time.deltaTime);
        

    }

    void Worck()
    {
        

      //  Debug.Log("Worck");
    }

}
