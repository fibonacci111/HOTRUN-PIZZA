using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Generator_On : MonoBehaviour
{[SerializeField] GameObject battaryes;
    [SerializeField] GameObject image;
[SerializeField] Animator anim;
[SerializeField] GameObject Effects;
[SerializeField] AudioSource audio;
[SerializeField] AudioClip Generator;
[SerializeField] AudioClip EffectsClip;
   public  int MaxPass = 3;
    [SerializeField] GameObject door_opener;
    [SerializeField] GameObject Buttery_Counter;
    private bool isCounted = true;
private void OnTriggerStay(Collider other)
{
    if (other.CompareTag("Player")&&isCounted)
    {
            Buttery_Counter.SetActive(true);
            isCounted = false;

    }
    if (other.CompareTag("Player") && Player_Controller1.pla.Pass >= MaxPass && Input.GetKeyDown(KeyCode.E))
    {
        battaryes.SetActive(true);
        door_opener.SetActive(true);
            Buttery_Counter.SetActive(false);
            // anim.CrossFade("Inter", 0.1f);
            // Effects.SetActive(true);
            //audio.clip = EffectsClip;
            // audio.Play();
        }
        

    }
    private void OnTriggerExit(Collider other)
{
    

}

}

