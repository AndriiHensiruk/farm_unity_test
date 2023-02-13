using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopperSpawner : MonoBehaviour
{
    public GameObject[] prefSceneObject;
    private Vector2 screenBounds;

    int randomInt;
    
    // Start is called before the first frame update
    void Start()
    {

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        SpawnRandom(); 
    }

    void SpawnRandom()
    {
        GameObject toSpawn;
        Vector2 pos;
        float screenX, screenY;

        randomInt = Random.Range(0, prefSceneObject.Length);
        toSpawn = prefSceneObject[randomInt];

        toSpawn.SetActive(true);
        //generation of spawn points
        screenX = -screenBounds.x;
        screenY = 0;
        pos = new Vector2(screenX, screenY);

        Instantiate(toSpawn, pos, toSpawn.transform.rotation);
    }

    
}
