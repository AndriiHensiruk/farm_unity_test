using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    //The speed of falling on the object
    int speed = - 5;
    Collider2D myCollider;
    // Start is called before the first frame update
    void Start()
    {
      
        myCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.up * speed * Time.deltaTime);
    }

    //Stop falling to the ground
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("Holes"))
        {
            speed = 0;

        }

        if (target.gameObject.tag == "Tools")
        {
            Destroy(gameObject);
        }
    }
}