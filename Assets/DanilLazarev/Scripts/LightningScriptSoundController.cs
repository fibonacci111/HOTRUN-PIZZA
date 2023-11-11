using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class LightningScriptSoundController : MonoBehaviour
{
    [SerializeField] private VisualEffect visualEffect;

    [SerializeField] private AudioSource audioSource;

    //[SerializeField] private AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (visualEffect.aliveParticleCount > 0) {
            audioSource.pitch = Random.Range(0.9f, 1.1f);
            audioSource.Play();
        }
        //if (visualEffect.aliveParticleCount == 0)
        //{
        //    audioSource.Stop();
        //}
        //if (visualEffect.aliveParticleCount > 0)
        //{
        //    audioSource.PlayOneShot(audioClip, 1);
        //}
    }
}
