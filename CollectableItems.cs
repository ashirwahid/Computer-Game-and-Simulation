using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CollectableItems : MonoBehaviour
{
    
    public enum ECollectables
    {
        CHERRY,
        AVACADO,
        KIWI,
        BROCOLLI
    };

    public Life life;
    public int maxHealth = 100;
    public int currentHealth=100; 
    private int cherries = 0;
    private int avacados = 0;
    private int kiwi = 0;
    private int brocolli = 0;
    public Healthbar healthbar;
    
    [SerializeField] private Text cherriesText;
    [SerializeField] private Text kiwiText;
    [SerializeField] private Text brocolliText;
    [SerializeField] private Text avacadosText;
    [SerializeField] private AudioSource CollectSoundEffect;
    public int age;
    public int max_cherries;
    public int eighteenmax_cherries;
    public int sixtymax_cherries;

    public int max_kiwis;
    public int eighteenmax_kiwis;
    public int sixtymax_kiwis;
    

    public int max_brocolli;
    public int eighteenmax_brocolli;
    public int sixtymax_brocolli;
    public int max_avacado;
    public int eighteenmax_avacado ;
    public int sixtymax_avacado;
    // Update is called once per frame
    public void SetMaxItems(ECollectables ItemType, int maxNumber)
    {
        switch (ItemType)
        {
            case ECollectables.CHERRY:
                max_cherries = maxNumber;
                break;

            case ECollectables.KIWI:
                max_cherries = maxNumber;
                break;
                
            case ECollectables.AVACADO:
                max_cherries = maxNumber;
                break;
            case ECollectables.BROCOLLI:
                max_cherries = maxNumber;
                break;        
        }
    }



    public int GetMaxItems(ECollectables ItemType)
    {
        
            switch (ItemType)
        {
            case ECollectables.CHERRY :
                return max_cherries;
    //            break;

            case ECollectables.KIWI:
                return max_kiwis;
  //              break;

            case ECollectables.AVACADO:
                return max_avacado;
//                break;
        
            case ECollectables.BROCOLLI:
                return max_brocolli;
                //break;
        }
        return 0;
        
        
    }
    public int GetCollectedItems(ECollectables ItemType)
    {
        switch (ItemType)
        {
            case ECollectables.CHERRY:
                return cherries;
                break;
            case ECollectables.AVACADO:
                return avacados;
                break;
            case ECollectables.KIWI:
                return kiwi;
                break;
            case ECollectables.BROCOLLI:
                return brocolli;
                break;
        }

        return 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        age =InputAge.age;
        //Debug.Log("Age: "+InputAge.age);
        if (collision.gameObject.CompareTag("Cherry"))
        {
            CollectSoundEffect.Play();
            //print (healthbar.slider.value);
            Destroy(collision.gameObject);
            cherries++;
            if ((age < 18) && cherries>max_cherries){
                healthbar.slider.value -=10;
            }
            if ((age >= 18 && age < 60) && cherries>eighteenmax_cherries){
                healthbar.slider.value -=10;
            }
            if ((age >=60) && cherries>sixtymax_cherries){
                healthbar.slider.value -=10;
            }
            cherriesText.text = "cherries: " + cherries;

        }
        if (collision.gameObject.CompareTag("covid"))
        {
            print("Healthbar");
            //print(healthbar.slider.value);
            CollectSoundEffect.Play();
            healthbar.SetHealth(currentHealth-20);
            currentHealth = currentHealth-20;
            if(currentHealth<5){
                gameObject.GetComponent<Life>().die();
                
            }  
        }
        
        if (collision.gameObject.CompareTag("avacado"))
        {
            CollectSoundEffect.Play();
            print (healthbar.slider.value);
            avacados++;
            if ((age < 18) && avacados>max_avacado){
                healthbar.slider.value -=10;
            }
            if ((age >= 18 && age < 60) && avacados>eighteenmax_avacado){
                healthbar.slider.value -=10;
            }
            if ((age >=60) && avacados>sixtymax_avacado){
                healthbar.slider.value -=10;
            }
            avacadosText.text = "avacados: " + avacados;
            healthbar.SetHealth(currentHealth+10);
            currentHealth = currentHealth+10;
            Destroy(collision.gameObject);  
        }
        if (collision.gameObject.CompareTag("kiwi"))
        {
            CollectSoundEffect.Play();
            kiwi++;
            if ((age < 18) && kiwi>max_kiwis){
                healthbar.slider.value -=10;
            }
            if ((age >= 18 && age < 60) && kiwi>eighteenmax_kiwis){
                healthbar.slider.value -=10;
            }
            if ((age >=60) && kiwi>sixtymax_kiwis){
                healthbar.slider.value -=10;
            }
            kiwiText.text = "Kiwi: " + kiwi;
            healthbar.SetHealth(currentHealth+5);
            currentHealth = currentHealth+5;
            Destroy(collision.gameObject);  
        }
       if (collision.gameObject.CompareTag("brocolli"))
        {
            CollectSoundEffect.Play();
            brocolli++;
            if ((age < 18) && brocolli>max_brocolli){
                healthbar.slider.value -=10;
            }
            if ((age >= 18 && age < 60) &&  brocolli>eighteenmax_brocolli){
                healthbar.slider.value -=10;
            }
            if ((age >=60) && brocolli>sixtymax_brocolli){
                healthbar.slider.value -=10;
            }
            kiwiText.text = "brocolli: " + brocolli;
            healthbar.SetHealth(currentHealth+10);
            currentHealth = currentHealth+10;
            Destroy(collision.gameObject);  
        }

        
    }
}
