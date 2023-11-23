using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class Spawner111 : MonoBehaviour
{
    [SerializeField] GameObject effect;
    public float time;
    public float maxTime;
    private bool enter;
    private bool enter2;
    private void Update()
    {
        if(enter&&Input.GetKeyDown(KeyCode.E)) {
            enter2 = true;
        }
        if (enter2)
        {
            time += 1 * Time.deltaTime;
            if(time > maxTime)
            {
                effect.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enter = true;
        }
    }
}
