using System;
using UnityEngine;

public class PizzaPickup3434 : MonoBehaviour
{
    public KeyCode pickupKey = KeyCode.E;
    [SerializeField] GameObject sound1;
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
         if (switching == 1 &&pizza.activeSelf && !playerPizza.activeSelf&&Input.GetKeyDown(KeyCode.E))
            {
		sound1.SetActive(false);
                pizza.SetActive(false);
                playerPizza.SetActive(true);
                sound1.SetActive(true);
                
               
            }
              
            else if (switching == 1 &&!pizza.activeSelf && playerPizza.activeSelf&&Input.GetKeyDown(KeyCode.E))
              {
		sound1.SetActive(false);
                pizza.SetActive(true);
                playerPizza.SetActive(false);

                sound1.SetActive(true);
              }
    }
}
