using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator_On : MonoBehaviour
{[SerializeField] GameObject battaryes;
    [SerializeField] GameObject image;
[SerializeField] Animator anim;
[SerializeField] GameObject Effects;
[SerializeField] AudioSource audio;
[SerializeField] AudioClip Generator;
[SerializeField] AudioClip EffectsClip;
private void OnTriggerStay(Collider other)
{
    if (other.CompareTag("Player"))
    {
        image.SetActive(true);
    }
    if (other.CompareTag("Player"))
    {
        battaryes.SetActive(false);
       // anim.CrossFade("Inter", 0.1f);
       // Effects.SetActive(true);
        //audio.clip = EffectsClip;
       // audio.Play();
    }
}
private void OnTriggerExit(Collider other)
{
    if (other.CompareTag("Player"))
    {
        image.SetActive(false);
    }

}

}

