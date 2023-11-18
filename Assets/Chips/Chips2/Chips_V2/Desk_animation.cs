using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desk_animation : MonoBehaviour
{
    private bool enter = false;
    [SerializeField] Animator anim;
    [SerializeField] Animator HandAnim;
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
            if (Player_Controller1.pla.isPizzaTake)
            {
                HandAnim.CrossFade("Pizza action", 0.2f);
            }
            else
            {
                HandAnim.CrossFade("Action", 0.2f);
            }
            enter = true;
        }
    }
}
