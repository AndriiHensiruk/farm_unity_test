using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
     public int numberToSpawn;
    //Objects for svavan
    public List<GameObject> spawnPool;
    //plane on which spawning takes place
   
    private Vector2 screenBounds;


    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        spawnObjects();
    }

   public void spawnObjects()
    {
        int randomItem = 0;
        GameObject toSpawn;
       // MeshCollider c = quad.GetComponent<MeshCollider>();

       
        Vector2 pos;
        float screenX, screenY;

        for (int i = 0; i < numberToSpawn; i++)
        {
            randomItem = Random.Range(0, spawnPool.Count);
            toSpawn = spawnPool[randomItem];

            //generation of spawn points
            screenX = Random.Range(-screenBounds.x+2, screenBounds.x-4);
            screenY = Random.Range(-screenBounds.y/2, screenBounds.y / 2);
            pos = new Vector2(screenX, screenY);
    
            Instantiate(toSpawn, pos, toSpawn.transform.rotation);
        }
    }
}
