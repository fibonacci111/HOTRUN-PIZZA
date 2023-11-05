using UnityEngine;

public class TeleportToCheckpoint : MonoBehaviour
{
    private bool onStay;
    public Transform player;

    private void FixedUpdate()
    {
        if(onStay)
        {
            
            Checkpoint.TeleportToLastCheckpoint(player.transform);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onStay= true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onStay = false;
        }
    }

}
