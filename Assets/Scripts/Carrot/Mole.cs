using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{
    public float minLifeTime = 1, maxLifeTime = 3, lifeTime = 1, timer = 0;
    MoleManager manager;
    void Start()
    {
        lifeTime = Random.Range(minLifeTime, maxLifeTime);
        manager =  GameObject.FindGameObjectWithTag("MoleManager").GetComponent<MoleManager>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= lifeTime)
        {
            Destroy(gameObject);

        }
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0))
        {
            manager.killMole++;
            Debug.Log("TOUCH");
            print(manager.killMole);
            Destroy(gameObject);
            return;
        }
    }

    
}
