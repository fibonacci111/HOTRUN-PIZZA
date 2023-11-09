using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desk_animation : MonoBehaviour
{
    private bool enter = false;
    [SerializeField] Animator anim;
    private void Update()
    {
        if(enter)
        {
            anim.SetBool("Start", true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player")&&Input.GetKeyDown(KeyCode.E))
        {
            enter = true;
        }
    }
}
