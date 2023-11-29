using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Battary_Collector : MonoBehaviour
{
    [SerializeField] GameObject gameObject;
    [SerializeField] Text text;
    private bool enter;
    [SerializeField] GameObject image;
    private void Update()
    {
        if (enter && Input.GetKeyDown(KeyCode.E))
        {
            Player_Controller1.pla.Pass += 1;
            text.text = Player_Controller1.pla.Pass.ToString();
            gameObject.SetActive(false);
            image.SetActive(true);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player_Controller1 pla))
        {
            enter = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player_Controller1 pla))
        {
            enter = true;
        }
    }
}

