// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Playerlife : MonoBehaviour
// {
//     private Animator anim;
//     public Healthbar healthbar;
//     [SerializeField] private AudioSource deathSoundEffect;
//     // Start is called before the first frame update
//     private void Start()
//     {
//         anim = GetComponent<Animator>();
//     }

//     // Update is called once per frame
//     private void OnCollisionEnter2D(Collision2D collision)
//     {
//         if (collision.gameObject.CompareTag("trap") ){
//             // print("trap");
//             // deathSoundEffect.Play();
//             // die();
//         }
//         if ( collision.gameObject.CompareTag("covid") ){
//             print("covid reached");
//             //deathSoundEffect.Play();
//             //die();
//         }
//     }
        

//     public void die()
//     {
//         anim.SetTrigger("death");
//     }
    
// }
