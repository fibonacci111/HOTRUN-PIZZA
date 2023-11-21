using UnityEngine;
using UnityEngine.Video;

public class TeleportToCheckpoint : MonoBehaviour
{
    private bool onStay;
    public Transform player;
   [SerializeField] GameObject video;
    float timer = 0;
    private void FixedUpdate()
    {
        if(onStay)
        {
            video.SetActive(true);
            
            Checkpoint.TeleportToLastCheckpoint(player.transform);
        }
        if (!video.activeSelf)
        {
            timer = 0;
        }
        if(video.activeSelf&&timer<30) {
            timer += 0.1f;
            
        }else if (timer >= 30 && video.activeSelf)
        {
            
            video.SetActive(false);
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
