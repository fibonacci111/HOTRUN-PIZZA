using System;
using UnityEngine;

public class PizzaPickup1111111 : MonoBehaviour
{
    public KeyCode pickupKey = KeyCode.E;
    
    public GameObject pizza;
    public GameObject playerPizza;
    int switching = 0;
  
    public Player_Controller1 playerController;

    private void Start()
    {
        
        playerController = FindObjectOfType<Player_Controller1>();
    }
    private void Update()
    {
            SetPizzaAct();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
            switching = 1;
    }  
      
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switching = 0;
        }
    }
    
    private void SetPizzaAct()
    {
         if (switching == 1 &&pizza.activeSelf && !playerPizza.activeSelf)
            {
                pizza.SetActive(false);
                playerPizza.SetActive(true);
            
                
                playerController.isPizzaTake = true;
            }
           
    }
}
