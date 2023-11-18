using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoudPlayer : MonoBehaviour
{
    [SerializeField] GameObject sound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sound.SetActive(true);
        }
    }
}
