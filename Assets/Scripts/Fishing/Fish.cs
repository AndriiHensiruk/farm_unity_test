using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    GameController gc;

    private Rigidbody2D rb;
    public float moveSpeed = 3f;
    float maxDistance, minDistance;
    private Vector2 screenBounds;
    private SpriteRenderer renderer;

    public float distance = 10f;
    Collider2D fishCollider;

   
    
    void Start()
    {
        fishCollider = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        maxDistance = transform.position.x + distance;
        minDistance = transform.position.x - distance;
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        gc.numFish++;
       
    }

    private void FixedUpdate()
    {
        transform.Translate(transform.right * moveSpeed * Time.deltaTime);

        if (transform.position.x > maxDistance)
        {
            renderer.flipX = false;
            moveSpeed = -Random.Range(1, moveSpeed); ;
        }


        if (transform.position.x < minDistance)
        {
            renderer.flipX = true;
            moveSpeed = -moveSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Fish fish = collision.GetComponent<Fish>();
        if (fish != null)
        {
           
            if (renderer.flipX)
            renderer.flipX = false;
            if (!renderer.flipX)
                renderer.flipX = true;
            moveSpeed = -moveSpeed;
        }
       

    }

    
}
