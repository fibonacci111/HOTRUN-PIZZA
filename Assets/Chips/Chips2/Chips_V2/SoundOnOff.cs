using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnOff : MonoBehaviour
{
    [SerializeField] GameObject sound;
    public bool SoundOn;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (SoundOn)
            {
                sound.SetActive(true);
            }
            else
            {
                sound.SetActive(false);
            }
        }
    }
}
