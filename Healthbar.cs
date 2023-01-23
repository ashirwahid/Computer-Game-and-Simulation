using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Healthbar : MonoBehaviour
{

    public Slider slider;
    public void SetMaxHealth(int health){
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetHealth(int health){
        
        slider.value = health;
    }

    static int CheckHealth(int health)
   {
       return health;
   }
    
    // Start is called before the first frame update
   
}
