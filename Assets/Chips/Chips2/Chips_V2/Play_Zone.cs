using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

using UnityEngine.UI;
public class Play_Zone : MonoBehaviour
{
 


    [SerializeField] float Timer;
    [SerializeField] float DetectTime;
   

  
    bool detected = false;
   
    [SerializeField] Transform player;
   
    
   
   

    [SerializeField] TextMeshProUGUI Time_Zone;

    private bool OnStay;
    private void Update()
    {
       

        if (detected)
        {
            Detected();

            DetectUp();

        }
        else
        {
            DetectDown();

        }
       Zone_Time();
    }
    private void FixedUpdate()
    {
        if(OnStay)
        {
            Checkpoint.TeleportToLastCheckpoint(player.transform);
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {

 detected = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            detected = true;

        }

    }
    private void DetectUp()
    {
        DetectTime += 1f * Time.deltaTime;


    }
    private void DetectDown()
    {

        if (DetectTime > 0)
        {
           
                DetectTime = 0;

            OnStay = false;
        }
    }
    private void Detected()
    {
        if (DetectTime >= Timer)
        {
            OnStay = true;

        }
    }
    void Zone_Time()
    {

        if (DetectTime > 0&&DetectTime<=Timer)
        {
            Time_Zone.text = Convert.ToInt32(DetectTime).ToString() + "/ " + Timer;
        }
        else
        {
            Time_Zone.text = "";
        }
    }
   
}


