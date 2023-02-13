using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedPackeg : MonoBehaviour
{
    private Collider2D collider2D;

    MoleManager manager;

    public GameObject prefObjekt;
    
    private bool worck, goBack = false;

    private Vector2 originalPosition, screenBounds, seedPosition;
    float speed = 5;
    public int wolckAwei = 0;
    void Awake()
    {
        //Checking objects for spawning and removing duplicates

        Tool[] controllers = FindObjectsOfType<Tool>();
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
        manager = GameObject.FindGameObjectWithTag("MoleManager").GetComponent<MoleManager>();
        collider2D = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Touch tracking
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 1))
        {
            return;
        }

        //Object movement
        if (Vector2.Distance(transform.position, prefObjekt.transform.position) <= 1)
        {
            worck = true;
            goBack = false;
        }

        if (Vector2.Distance(transform.position, prefObjekt.transform.position) >= 0)
        {
            worck = false;

        }
        if (Vector2.Distance(transform.position, originalPosition) < 1 && worck == false)
        {
            goBack = true;
        }

        if (goBack) GoBack(); else if (worck) Worck();

        if (manager.rockCount == 9)
        {
            Destroy(gameObject, 3f);
            Destroy(GameObject.Find("Seed"));
            goBack = true;

        }


    }


    void GoBack()
    {
        transform.position = Vector2.MoveTowards(transform.position, originalPosition, speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    void Worck()
    {
        transform.rotation = Quaternion.Euler(0, 0,  200);

    }

   
}
