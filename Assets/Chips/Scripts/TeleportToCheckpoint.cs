using UnityEngine;

public class TeleportToCheckpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("sdfsdf");
        if (other.CompareTag("Player"))
        {
            Checkpoint.TeleportToLastCheckpoint(other.transform);
        }
    }
}
