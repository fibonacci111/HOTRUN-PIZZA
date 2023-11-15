using System;
using UnityEngine;

public class PizzaPickup : MonoBehaviour
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
    {if (switching != 0)
        {
            SetPizzaAct();
        }
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
         if (switching == 1 &&pizza.activeSelf && !playerPizza.activeSelf&&Input.GetKeyDown(KeyCode.E))
            {
                pizza.SetActive(false);
                playerPizza.SetActive(true);
            
                
                playerController.isPizzaTake = true;
            }
              
            else if (switching == 1 &&!pizza.activeSelf && playerPizza.activeSelf&&Input.GetKeyDown(KeyCode.E))
              {
                pizza.SetActive(true);
                playerPizza.SetActive(false);

                playerController.isPizzaTake = false;
              }
    }
}
