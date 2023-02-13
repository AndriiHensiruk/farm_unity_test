using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Milk : MonoBehaviour
{
    CowManager cowManager;
   
    void Start()
    {
        cowManager = GameObject.FindGameObjectWithTag("CowManager").GetComponent<CowManager>();
        cowManager.countMilk++;
    }

   
}
