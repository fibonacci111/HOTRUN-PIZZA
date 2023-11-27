using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GoloText : MonoBehaviour
{
    [SerializeField] GameObject windowDialog;
    [SerializeField] TextMeshProUGUI textDialog;
    [SerializeField] Button button;


    bool look;
    public string[] message;
    private int numberDialog = 0;
   // [SerializeField] GameObject DeleteDialogue;
    bool enter = false;

    public bool isFinish;
    [SerializeField] GameObject Finish_Jump;
    private void Update()
    {
        if (enter&&Input.GetKeyDown(KeyCode.E))
        {
            Cursor.lockState = CursorLockMode.Confined;
            look = true;
         
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
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            enter = true;
        }
        
    }

    private void OnTriggerExit(Collider collision)
    {
        enter = false;
        windowDialog.SetActive(false);
        numberDialog = 0;
        CameraMoveController.instance.speed = CameraMoveController.instance.normalSpeed;
        button.onClick.RemoveAllListeners();
    }

    public void NextDialog()
    {
        numberDialog++;
        textDialog.text = message[numberDialog];
        if (numberDialog == message.Length - 1)
        {
            button.gameObject.SetActive(false);
            look = false;
            // DeleteDialogue.SetActive(false);
            Player_Controller1.pla.Speed = Player_Controller1.pla.NormalSpeed;
            CameraMoveController.instance.speed = CameraMoveController.instance.normalSpeed;
            Cursor.lockState = CursorLockMode.Locked;
            if (isFinish)
            {
                Finish_Jump.SetActive(true);
            }
        }
    }
}
