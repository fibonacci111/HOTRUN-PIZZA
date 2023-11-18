using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Dialog3 : MonoBehaviour
{
    [SerializeField] GameObject windowDialog;
    [SerializeField] TextMeshProUGUI textDialog;
    [SerializeField] Button button;
    [SerializeField] Transform target;
    [SerializeField] Transform camera;
    bool look;
    public string[] message;
    private int numberDialog = 0;
    [SerializeField] GameObject DeleteDialogue;
    private void Update()
    {
       
    }
    private void OnTriggerEnter(Collider collision)
    {

        if (collision.tag == "Player")
        {
            Cursor.lockState = CursorLockMode.Confined;
           
        
            CameraMoveController.instance.speed = 0;
            if (numberDialog == message.Length - 1)
            {
                button.gameObject.SetActive(false);

            }
            else
            {
                button.gameObject.SetActive(true);
                button.onClick.AddListener(NextDialog);
            }

            windowDialog.SetActive(true);
            textDialog.text = message[numberDialog];
        }
    }

    private void OnTriggerExit(Collider collision)
    {
Cursor.lockState = CursorLockMode.Locked;
    }

    public void NextDialog()
    {
        numberDialog++;
        textDialog.text = message[numberDialog];
        if (numberDialog == message.Length - 1)
        {
            button.gameObject.SetActive(false);
            look = false;
            DeleteDialogue.SetActive(false);
            Player_Controller1.pla.Speed = Player_Controller1.pla.NormalSpeed;
            CameraMoveController.instance.speed = CameraMoveController.instance.normalSpeed;
             windowDialog.SetActive(false);
            numberDialog = 0;
            button.onClick.RemoveAllListeners();
        }
    }
}

