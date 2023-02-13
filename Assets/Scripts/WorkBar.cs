using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkBar : MonoBehaviour
{
    Slider workSlider;
    
    void Start()
    {
        workSlider = GetComponent<Slider>();    
    }

    public void SetMaxWork(int maxWorck)
    {
        workSlider.maxValue = maxWorck;
        workSlider.value = maxWorck;

    }
    public void SetWorck(int worck)
    {
        workSlider.value = worck;
    }
}
