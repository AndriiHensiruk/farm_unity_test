using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hook : MonoBehaviour
{
    private int offset = 4;
    private bool catchingFish;
    private Vector2 screenBounds;

    private List<Fish> hookedFishes;

    private int scoreInt, fishCount;
    private float moveSpeed = 3f;
    private Vector2 originalPosition, pos;
    Collider2D hookCollider;

    public GameObject prefNet;

    void Awake()
    {
        Hook[] controllers = FindObjectsOfType<Hook>();


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
        hookCollider = GetComponent<Collider2D>();
        originalPosition = transform.position;
        hookedFishes = new List<Fish>();

       
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        
       
    }
    void Update()
    {
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {


            Vector2 screenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetMouseButtonDown(0))
            {

                pos = new Vector2(screenPosition.x, screenPosition.y);

            }
           


        }
        else if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            pos = new Vector2(touchPosition.x, touchPosition.y);


        }
        if (transform.position.x == pos.x && transform.position.y == pos.y)
            pos = originalPosition;
        transform.position = Vector2.MoveTowards(transform.position, pos, moveSpeed * Time.deltaTime);

    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("Fish"))
        {
            Spawner(prefNet);
            fishCount++;
            Fish component = target.GetComponent<Fish>();
            component.moveSpeed = 0f;
            
            hookedFishes.Add(component);
            target.transform.SetParent(transform);
            target.transform.position = gameObject.transform.position;
            target.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360)); ;
           // target.transform.localScale = Vector3.one;
            Fish fish;
           
           
            
        }
    }

    private void addScore()
    {
        scoreInt++;
        
    }

    void Spawner(GameObject gameObject)
    {
        Vector2 pos;

        float posX = screenBounds.x;
        float posY = screenBounds.y - 3;

        pos = new Vector2(posX, posY);
        Instantiate(gameObject, pos, gameObject.transform.rotation);
    }
}
