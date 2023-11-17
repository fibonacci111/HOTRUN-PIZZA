using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish_Lift : MonoBehaviour
{
    [SerializeField] Transform enemy;
    [SerializeField] Transform position1;
    [SerializeField] Transform position2;
    private bool _switch;
    public float speed;
    private bool OnStay = false;
    public bool switching = false;
    [SerializeField] Animator anim;
    [SerializeField] GameObject FinishPizza;
    void FixedUpdate()
    {

        if (_switch == false && !switching)
        {
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, position1.position, speed * Time.deltaTime);


        }
        else if (_switch == true && switching)
        {
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, position2.position, speed * Time.deltaTime);

        }

        if (enemy.transform.position == position1.position)
        {

            _switch = true;

        }
        else if (enemy.transform.position == position2.position)
        {


            _switch = false;

        }

        if (Input.GetKeyDown(KeyCode.E) && switching && OnStay&&!FinishPizza.activeSelf)
        {
            switching = false;
            if (Player_Controller1.pla.isPizzaTake)
            {
                anim.CrossFade("Pizza action", 0.2f);
            }
            else
            {
                anim.CrossFade("Action", 0.2f);
            }
        }
        else if (Input.GetKeyDown(KeyCode.E) && !switching && OnStay&&!FinishPizza.activeSelf)
        {
            if (Player_Controller1.pla.isPizzaTake)
            {
                anim.CrossFade("Pizza action", 0.2f);
            }
            else
            {
                anim.CrossFade("Action", 0.2f);
            }
            switching = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnStay = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnStay = false;
        }
    }
    //private void Player_Click_E()
    //{
    //    if (Input.GetKeyDown()) { } 

    //}
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(position1.position, position2.position);
    }
}

