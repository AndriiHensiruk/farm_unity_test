using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleManager : MonoBehaviour
{
    //Connecting objects to control them
    public Holes hole;
    public Mole mole;
    public SeedPackeg seedPackeg; 
    private Vector2 screenBounds;
    private Vector2 originalPosition;
    public Holes[,] holes = new Holes[3, 3];

    public float timer = 0, spawnTime = 1;
    public int killMole = 0, rockCount = 0;
    bool flag = false;

    //Creating a matrix for burrows
    void CreateHole()
    {
        for (int i = 0; i < holes.GetLength(0); i++)
        {
            for (int j = 0; j < holes.GetLength(1); j++)
            {
                Vector3 pos = new Vector3(-screenBounds.x/2+i*5, -screenBounds.y/2+j*3, 0);
                holes[i, j] = (Holes)Instantiate(hole, pos, Quaternion.identity);
            }
        }
       
    }

    //Call of the mole
    void CreateMole()
    {
        int x = Random.Range(0, holes.GetLength(0)), y = Random.Range(0, holes.GetLength(0));
        while (!holes[x, y].GetComponentInChildren<Mole>())
        {
           Mole m = (Mole)Instantiate(mole, holes[x, y].GetComponentInChildren<SpawnPosition>().transform.position, Quaternion.identity);
            m.transform.SetParent(holes[x, y].transform);
        }
       
    }
   
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
       
        CreateHole();
    }

   
    void Update()
    {
        //Stopping the spawning mole
        if (killMole < 5)
        {
            timer += Time.deltaTime;
            if (timer >= spawnTime)
            {
                CreateMole();
                timer = 0;
            }



        } //Spawn a bag of seeds
        else if (!flag)
        {
            Vector2 pos;
            pos = new Vector2(screenBounds.x-1, -screenBounds.y +3);

            Instantiate(seedPackeg, pos, seedPackeg.transform.rotation);
            flag = true;
        }

       

    }
}
