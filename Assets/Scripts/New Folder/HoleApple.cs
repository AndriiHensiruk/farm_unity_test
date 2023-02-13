using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleApple : MonoBehaviour
{
    Vector2 pos;
    float screenX, screenY;
    bool flag1, flag2 = false;
    int countFeth = 0;
    public GameObject seedlingsObjekt, seedPakeg;
    public GameObject  TreePref;
    private Vector2 screenBounds, originPos;
    // Start is called before the first frame update
    void Start()
    {
        originPos = transform.position;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        screenX = (1+originPos.x);
        screenY = (2);
        pos = new Vector2(screenX, screenY);
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!flag1)
        {
            if (!GameObject.FindGameObjectWithTag("Rock"))
            {
                Instantiate(TreePref, pos, TreePref.transform.rotation);
                flag1 = true;
            }
                
        }
       
        
    }

    private void OnTriggerEnter2D(Collider2D target)
    {


       

        if (target.gameObject.tag == "Packeg")
        {
            countFeth++;
                Instantiate(seedlingsObjekt, transform.position, seedlingsObjekt.transform.rotation); 
            if (countFeth > 3)
            {
                Destroy(target.gameObject);
                Instantiate(seedPakeg, pos, seedPakeg.transform.rotation);
              
            }
        }

    }
}
