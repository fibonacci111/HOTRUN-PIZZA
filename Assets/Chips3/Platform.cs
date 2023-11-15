using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Platform : MonoBehaviour
{
  
    [SerializeField] float speed;
    [SerializeField] private Transform position1, position2;
    private bool _switch = false;
    bool detected = false;
    [SerializeField] Transform player;
    
    [SerializeField] GameObject enemy;
    float percent;
    [SerializeField] float normalSpeed;
    float zeroSpeed = 0;
    float EnemyStayTimer = 0;
    [SerializeField] float EnemyStayTimeMax;

    private void FixedUpdate()
    {
       


        if (_switch == false)
        {
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, position1.position, speed * Time.deltaTime);
            EnemyStay();

        }
        else if (_switch == true)
        {
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, position2.position, speed * Time.deltaTime);
            EnemyStay();

        }

        if (enemy.transform.position == position1.position)
        {

            _switch = true;
            EnemyMove();
        }
        else if (enemy.transform.position == position2.position)
        {


            _switch = false;
            EnemyMove();
        }

       

       
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetPositionAndRotation(gameObject.transform.position, other.transform.rotation);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = null;
        }
    }


    void EnemyStay()
    {

        EnemyStayTimer += 1f * Time.deltaTime;
        speed = zeroSpeed; 
        if (EnemyStayTimer >= EnemyStayTimeMax)
        {
           
            speed = normalSpeed;
            if (_switch == true)
            { enemy.transform.LookAt(position2); }
            else if (_switch == false)
            { enemy.transform.LookAt(position1); }


        }

    }
    void EnemyMove()
    {

        if (EnemyStayTimer >= 0)
        {

            EnemyStayTimer = 0;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(position1.position, position2.position);
    }
}

