using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;
public class finihs : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource FinishSound;
    private bool levelCompleted = false;
    public Healthbar healthbar;
    public CollectableItems CItemScript ;//= new CollectableItems();
    public Life life;
    private void Start()
    {
        FinishSound = GetComponent<AudioSource>();
        CItemScript = FindObjectOfType(typeof(CollectableItems)) as CollectableItems;
        life = FindObjectOfType(typeof(Life)) as Life;
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.name == "player" && !levelCompleted){
            FinishSound.Play();
            levelCompleted = true;
            Invoke("IsLevelCompleted",2f);
            
        }
    }

    private void IsLevelCompleted()
    {
        int age =InputAge.age;
        const int punishingHealth = 10;
        float health = healthbar.slider.value; 
        print("Healthleft");
        print (health);

        int totalCollectables = (int)CollectableItems.ECollectables.BROCOLLI;
        print (totalCollectables);
        float finalHealth = health; 

        for (int i = 0; i <totalCollectables; i++)
        {
            var item = (CollectableItems.ECollectables)i;
            Debug.Log(item.ToString());
            
            Debug.Log(age);
            
            int requiredCollectable = CItemScript.GetMaxItems(item);//CItemScript.GetMaxItems((CollectableItems.ECollectables)i); //4
            Debug.Log(requiredCollectable);
            int collected = CItemScript.GetCollectedItems((CollectableItems.ECollectables)i);; //2
            Debug.Log(collected);
            int difference = Mathf.Max(requiredCollectable - collected, 0); //2
            finalHealth -= (difference * punishingHealth); //FinalHealth = 20
        }

        if (finalHealth <=0 )
        {
            life.die();
        }
        Debug.Log("Complete Leve");
        CompleteLevel();
    }

    private void CompleteLevel(){

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

    // Update is called once per frame

}
