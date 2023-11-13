using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Lift : MonoBehaviour
{
    [SerializeField] Transform enemy;
    [SerializeField] Transform position1;
    [SerializeField] Transform position2;
    private bool _switch;
    public float speed;

    public bool switching = false;

    void FixedUpdate()
    {

        if (_switch == false && !switching )
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
        
      
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E) && switching&& other.CompareTag("Player"))
        {
            switching = false;
        }
        else if (Input.GetKeyDown(KeyCode.E) && !switching && other.CompareTag("Player"))
        {
            switching = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(position1.position, position2.position);
    }
}
