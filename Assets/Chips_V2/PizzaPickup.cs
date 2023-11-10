using UnityEngine;

public class PizzaPickup : MonoBehaviour
{
    public KeyCode pickupKey = KeyCode.E;
    public GameObject pizza;
    public GameObject playerPizza;
    public bool pizzaIsActive = false;

    public static PizzaPickup instance;
    private void Awake()
    {
        instance = this;
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Trigger entered");
        if (other.CompareTag("Player") && Input.GetKeyDown(pickupKey)&& pizza.activeSelf &&!playerPizza.activeSelf )
        {
            pizza.SetActive(false);
            playerPizza.SetActive(true);
            pizzaIsActive = true;
        }else if(other.CompareTag("Player") && Input.GetKeyDown(pickupKey) && pizza.activeSelf == false && playerPizza.activeSelf)
        {
            pizza.SetActive(true);
            playerPizza.SetActive(false);
            pizzaIsActive = false;
        }
    }
}
