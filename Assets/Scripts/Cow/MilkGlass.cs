using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkGlass : MonoBehaviour
{
   
   
    
    [SerializeField] Udder udder;
    public int touch;
    public GameObject prefMilk, prefBox;
    public bool milking = false;

    Collider2D myCollider;

    void Awake()
    {
     
        myCollider = GetComponent<Collider2D>();
       
    }
   

    private void Start()
    {

        udder = GameObject.FindGameObjectWithTag("Udder").GetComponent<Udder>();
    }
    private void Update()
    {
        

        if (GameObject.FindWithTag("Milk") && GameObject.FindWithTag("Cow"))
        {
            Instantiate(prefBox);
        }
        if (udder.countTouch > 3)
            if(milking)
            {
                prefMilk.SetActive(true);
                milking = false;
            }


    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("Udder"))
        {
            milking = true;


        }
    }
}
