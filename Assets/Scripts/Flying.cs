using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour
{
    GameController gc;

    private Collider2D collider2D;

    private SpriteRenderer renderer;
    private Rigidbody2D rigidbody;

    public float distance = 5f;
    [SerializeField] private float radius = 2f;

    float maxDistanceX, minDistanceX, maxDistanceY, minDistanceY;

    public float speed = 1;

    public GameObject prefObjekt;
    private Vector2  originalPosition;
    private bool angry, goBack, chill = false;
    float positionX, positionY, angle = 0f;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
        maxDistanceX = transform.position.x + radius;
        minDistanceX = transform.position.x - radius;
        maxDistanceY = transform.position.y + radius;
        minDistanceY = transform.position.y - radius;
        originalPosition = transform.position;

        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        gc.numVegetables++;

        collider2D = GetComponent<Collider2D>();

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0))
        {
            Debug.Log("TOUCH");
            return;
        }


        if (Vector2.Distance(transform.position, prefObjekt.transform.position) < distance)
        {
            angry = true;
            goBack = false;
            chill = false;
        }
        
        if (Vector2.Distance(transform.position, prefObjekt.transform.position) > distance)
        {
            goBack = true;
            angry = false;

        }
        if (Vector2.Distance(transform.position, originalPosition) < distance && angry == false)
        {
            chill = true;
        }

        if (chill) Chill(); else if (angry) Angry(); else if (goBack) GoBack();

    }
    void Chill()
    {
        
        positionX = originalPosition.x + Mathf.Cos(angle) * radius;
        positionY = originalPosition.y + Mathf.Sin(angle) * radius;
        //transform.Translate(transform.right * speed * Time.deltaTime);
        //transform.Translate(transform.up * speed * Time.deltaTime);
        transform.position = new Vector2(positionX, positionY);
        angle = angle + Time.deltaTime * speed;
        if (angle >= 360f) angle = 0f;

        if (transform.position.x > maxDistanceX)
        {
            renderer.flipX = true;
            speed = -speed;
        }


        if (transform.position.x < minDistanceX || transform.position.y < minDistanceY)
        {
            renderer.flipX = false;
            speed = -speed;
        }
        Debug.Log("Chill");

    }

    void Angry()
    {
        transform.position = Vector2.MoveTowards(transform.position, prefObjekt.transform.position, speed * Time.deltaTime);
        Debug.Log("Angry");
    }

    void GoBack()
    {
        transform.position = Vector2.MoveTowards(transform.position, originalPosition, speed * Time.deltaTime);
        Debug.Log("GoBack");
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Basket")
        {
            renderer.flipY = true;

            speed = 0;
            collider2D.enabled = false;
            gc.numVegetables--;

        }

    }

}
