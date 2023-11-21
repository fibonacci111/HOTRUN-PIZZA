using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveFinish : MonoBehaviour
{
    [SerializeField] GameObject walls_and_finish;
    private bool enter;

    private void Update()
    {
        if (enter&&Input.GetKeyDown(KeyCode.E)) {
            walls_and_finish.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enter = true;
        }
    }
    private void OnTriggeExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enter = false;
        }
    }
}
