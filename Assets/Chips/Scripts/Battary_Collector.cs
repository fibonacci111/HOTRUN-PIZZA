using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Battary_Collector : MonoBehaviour
{
    [SerializeField] GameObject gameObject;
    [SerializeField] Text text;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player_Controller1 pla))
        {
            Player_Controller1.pla.Pass += 1;
            text.text = Player_Controller1.pla.Pass.ToString();
            gameObject.SetActive(false);
        }
    }
}

