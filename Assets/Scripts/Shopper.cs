using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopper : MonoBehaviour
{
    public float speed = 1;
    public GameObject[] prefSceneObject;
    bool flag = false;

    int randomInt;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * speed * Time.deltaTime);
        
        if (transform.position.x > 0)  
        {
            
            speed = 0;
            if (!flag)
            {
                SpawnRandom();
                flag = true;
            }
           
           
        }
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
        screenX = 2.5f;
        screenY = 2.5f;
        pos = new Vector2(screenX, screenY);

        Instantiate(toSpawn, pos, toSpawn.transform.rotation);
        
    }
}
