using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingNet : MonoBehaviour
{
    public float speed = 1;
    private Vector2 originalPosition;

    bool goForward, goBack = false;
    bool flag = false;

    private Vector2 screenBounds;
    private float posStateX;

    GameController gc;

    [SerializeField] int fishCount;

    List<Fish> caughtFish;

    Collider2D myCollider;

    public GameObject prefBasket;

    void Awake()
    {
        FishingNet[] controllers = FindObjectsOfType<FishingNet>();

        myCollider = GetComponent<Collider2D>();
        caughtFish = new List<Fish>();

        if (controllers.Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        posStateX = screenBounds.x - 4;
        originalPosition = transform.position;
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
       
    }
    private void Update()
    {
        //Object movement
        transform.Translate(transform.right * speed * Time.deltaTime);
        if (transform.position.x > posStateX) goForward = true;
        if (gc.numFish < fishCount)
        {
            if (!flag)
            {
                Spawner(prefBasket);
                flag = true;
            } 
              
           // goBack = true;
            goForward = false;
        }

        if (goForward) GoForward(); else if (goBack) GoBack();

    }

    void GoForward()
    {
        speed = 0;

    }

    void GoBack()
    {
        speed = 2;

        Debug.Log("GoBack");

        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fish")
        {

            fishCount++;

            //Adding objects to a new list
            Fish fish = collision.gameObject.GetComponent<Fish>();
            fish.moveSpeed = 0;
            caughtFish.Add(fish);
            
            collision.transform.SetParent(transform);
            collision.transform.position = gameObject.transform.position;
            collision.transform.rotation = transform.rotation;
            //collision.transform.localScale = Vector3.one;

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
