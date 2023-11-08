using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class FireworksScriptSoundControl : MonoBehaviour
{
    private VisualEffect _numberParticle;
    private int _number = 1;
    private List<string> ts;
    [SerializeField] VisualEffect visualEffect;
    [SerializeField] AudioSource audioSource;
    //[SerializeField] AudioSource audioSource_2;
    //[SerializeField] AudioClip audioClip;
    // Start is called before the first frame update
    void Start()
    {
        _numberParticle = visualEffect.GetComponent<VisualEffect>();
        
        
    }

    // Update is called once per frame
    void Update()
    {

      if(visualEffect.aliveParticleCount >= 1 && visualEffect.aliveParticleCount < 20)
        {
            audioSource.Play();
        }

      //if(visualEffect.aliveParticleCount > 50)
      //  {
      //      audioSource_2.Play();
      //  }
    }
}
