using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundStart : MonoBehaviour
{
    [SerializeField] GameObject sound;
    public bool alwaysActive = false;
    private bool enter = false;
    public bool ActivateOnE;

    private void FixedUpdate()
    {
        if (enter&&Input.GetKeyDown(KeyCode.E)&&ActivateOnE)
        {
            sound.SetActive(true);

        }else if (alwaysActive && enter)
        {
            sound.SetActive(true);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enter  = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enter = false;
        }
    }
}
