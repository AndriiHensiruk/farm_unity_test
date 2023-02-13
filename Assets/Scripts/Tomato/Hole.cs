using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    Vector2 pos;
    float screenX, screenY;

    public GameObject seedlingsObjekt;

    private Vector2 screenBounds, originPos;
    // Start is called before the first frame update
    void Start()
    {
        originPos = transform.position;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        screenX = (1+originPos.x);
        screenY = (2);
        pos = new Vector2(screenX, screenY);
        Instantiate(seedlingsObjekt, pos, seedlingsObjekt.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
