using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holes : MonoBehaviour
{
    [SerializeField] Transform holeTransform;
    public GameObject prefSeed, prefGround ;
    private Vector2 originalPosition;
    int seedCount = 0;
    MoleManager manager;
    List<Seed> caughtSeed; //Declaration of a list to store objects
    bool flag = false, seed = false;
    Collider2D myCollider;

   
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("MoleManager").GetComponent<MoleManager>();
        caughtSeed = new List<Seed>();
        originalPosition = transform.position;
        myCollider = GetComponent<Collider2D>();
    }

    
    void Update()
    {

        if (seedCount == 3) //the appearance of a tubercle
        {
            if (!flag)
            {
              
                Instantiate(prefGround, transform.position, prefSeed.transform.rotation);
                
                flag = true;
            }
            
        }

        if (manager.rockCount == 9) seed = true;
       
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("Packeg"))
        {

            Vector2 pos;
            pos = new Vector2(transform.position.x, transform.position.y+1); //emergence of seeds
            if (!seed)
            {
                Instantiate(prefSeed, pos, prefSeed.transform.rotation);
                
            }
           


        }
        if (target.gameObject.tag == "Seed")
        {
            seedCount++;
            //Adding objects to a new list 

            Seed seed = target.gameObject.GetComponent<Seed>();
            caughtSeed.Add(seed);
            target.transform.SetParent(transform);
            target.transform.position = holeTransform.transform.position;
            target.transform.rotation = holeTransform.transform.rotation;
           

        }
    }
}
