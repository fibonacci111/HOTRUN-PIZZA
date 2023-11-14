using UnityEngine;

public class PizzaPickup : MonoBehaviour
{
    public KeyCode pickupKey = KeyCode.E;
    public GameObject pizza;
    public GameObject playerPizza;

  
    public Player_Controller1 playerController;

    private void Start()
    {
        
        playerController = FindObjectOfType<Player_Controller1>();
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Trigger entered");

        if (other.CompareTag("Player") && Input.GetKeyDown(pickupKey) && pizza.activeSelf && !playerPizza.activeSelf)
        {
            pizza.SetActive(false);
            playerPizza.SetActive(true);

           
            playerController.isPizzaTake = true;
        }
        else if (other.CompareTag("Player") && Input.GetKeyDown(pickupKey) && pizza.activeSelf == false && playerPizza.activeSelf)
        {
            pizza.SetActive(true);
            playerPizza.SetActive(false);

            playerController.isPizzaTake = false;
        }
    }
}
