using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public static List<Transform> collectedCheckpoints = new List<Transform>();
    private bool hasTeleported = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasTeleported)
        {
            if (!IsCheckpointCollected(transform))
            {
                collectedCheckpoints.Add(transform);
                TeleportToLastCheckpoint(other.transform);
                hasTeleported = true; // Устанавливаем флаг телепортации
            }
        }
    }

    public static void TeleportToLastCheckpoint(Transform playerTransform)
    {
        if (collectedCheckpoints.Count > 0)
        {
            playerTransform.position = collectedCheckpoints[collectedCheckpoints.Count - 1].position;
        }
    }

    bool IsCheckpointCollected(Transform checkingCheckpoint)
    {
        foreach (Transform collectedCheckpoint in collectedCheckpoints)
        {
            if (checkingCheckpoint == collectedCheckpoint)
            {
                return true;
            }
        }
        return false;
    }
}
