using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Audio : MonoBehaviour
{
    public AudioClip[] aboba;
    public AudioSource audio;
    void Start()
    {
        audio.clip = aboba[0];
        audio.Pause();
    }

    public void OnTriggerEnter()
    {
        audio.clip = aboba[0];
        audio.Play();
    }
    public void On_Click_Sound()
    {
        audio.clip = aboba[0];
        audio.Play();
    }

}
