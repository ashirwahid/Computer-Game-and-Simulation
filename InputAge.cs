using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputAge : MonoBehaviour
{
    //public InputField ageInput;
    public InputField InputUser;
    public GameObject PopupGO;
    public CollectableItems collectableItems;
    public static int age;

    public Persistant persistant;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    public string InputUserHandler()
    {
        Debug.Log("Log input: " + InputUser.text);
        age = int.Parse(InputUser.text);
        
        if (age < 18)
        {
            //collectableItems.SetMaxItems(CollectableItems.ECollectables.CHERRY, persistant.max_cherries);
            return "Child Diet Plan, have to collect 1 cherries, 1 avacados, 1 brocooli and 1 Kiwi";
        }
        else if (age >= 18 && age < 60)
        {
            return "Adult Diet Plan, have to collect 3 cherries, 3 avacados, 3 brocolli and 3 kiwi";
        }
        else
        {
            return "Senior Diet Plan, have to collect 2 cherries, 2 avacados, 2 seafood and 2 brocolli";
        }

        
        
    }

    public void OnStartButtonClick()
    {
        string dietPlan = InputUserHandler();
        PopupGO.GetComponent<Text>().text = dietPlan;
    }
        
}

