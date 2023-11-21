using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Video : MonoBehaviour
{
    [SerializeField] GameObject video;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            video.SetActive(true);
        }
    }
}
