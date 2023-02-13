using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneActive : MonoBehaviour
{
    public int numberScene = 0;
    // Start is called before the first frame update
   void Update()
    {
        if (Input.GetMouseButtonDown(0) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended))
        {
            SceneManager.LoadScene(numberScene);
        }
       
    }
    
}
