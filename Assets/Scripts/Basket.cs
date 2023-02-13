using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Basket : MonoBehaviour
{
    public float speed = 1;
    private Vector2 originalPosition;

    bool goForward, goBack = false;

    private Vector2 screenBounds;
    private float posStateX;
    int numberScene = 0;
    GameController gc;
    [SerializeField] int vegetablesCount;
    [SerializeField] int fishCount, jarCount;
    List<Vegetables> caughtVegetables;
    List<Fish> caughtFish;
    List<MilkGlass> milkGlasses;
    Collider2D myCollider;
    private void Awake()
    {
       

        myCollider = GetComponent<Collider2D>();
        caughtVegetables = new List<Vegetables>();
        caughtFish = new List<Fish>();
        milkGlasses = new List<MilkGlass>();

        //Checking objects for spawning and removing duplicates
        Basket[] controllers = FindObjectsOfType<Basket>();
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
        //Determining the size of the game window
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        posStateX = -screenBounds.x + 3;
        originalPosition = transform.position;

        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
       
    }
    private void Update()
    {
        //Object movement
        transform.Translate(transform.right * speed * Time.deltaTime);
        if (transform.position.x > posStateX) goForward = true;
        
        if (GameObject.FindWithTag("Vegetables") && gc.numVegetables == vegetablesCount)
        {
            goBack = true;
            goForward = false;
        }

        if(GameObject.FindWithTag("Fish") && gc.numFish == fishCount)
        {
            goBack = true;
            goForward = false;
        }

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
        speed = -2;
       
        Debug.Log("GoBack");
        
        Destroy(gameObject, 3f);
        SceneManager.LoadScene(numberScene);
    }

    //Tracking the object's collision with others
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Vegetables")
        {
            vegetablesCount++;

            //Adding objects to a new list
            Vegetables vegetables = collision.gameObject.GetComponent<Vegetables>();
            caughtVegetables.Add(vegetables);

            //Transmission of ancestral properties
            collision.transform.SetParent(transform);
            collision.transform.position = gameObject.transform.position;
            collision.transform.rotation = transform.rotation;
            //collision.transform.localScale = Vector3.one;

        }
        if (collision.gameObject.tag == "Fish")
        {
            //Adding objects to a new list 

            fishCount++;
            Fish fish = collision.gameObject.GetComponent<Fish>();
            caughtFish.Add(fish);

            //Transmission of ancestral properties
            collision.transform.SetParent(transform);
            collision.transform.position = gameObject.transform.position;
            collision.transform.rotation = transform.rotation;
            //collision.transform.localScale = Vector3.one;

        }
        if (collision.gameObject.tag == "MilkGlass")
        {
            //Adding objects to a new list 

            jarCount++;
            MilkGlass milkGlass = collision.gameObject.GetComponent<MilkGlass>();
            milkGlasses.Add(milkGlass);

            //Transmission of ancestral properties
            collision.transform.SetParent(transform);
            collision.transform.position = gameObject.transform.position;
            collision.transform.rotation = transform.rotation;
            //collision.transform.localScale = Vector3.one;

        }
    }
}
