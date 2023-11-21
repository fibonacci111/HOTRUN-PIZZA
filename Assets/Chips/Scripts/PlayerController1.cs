using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_Controller1 : MonoBehaviour
{
    [SerializeField] public CharacterController cc;
    [SerializeField] public float Speed = 10f;
    [SerializeField] GameObject menu;
    public bool finish = false;
    Vector3 velosity;
    public float gravity = -9.81f;
    public Transform GroundCheck;
    public float GroundDistanse = 0.4f;
    public LayerMask Ground;
    [NonSerialized] public bool isGround;
    public float JumpHeight = 10f;
    [NonSerialized ]public   bool a = false;
    public float NormalSpeed;
    public float Sprint = 100f;
    
     public bool isPizzaTake = false;
    
    [NonSerialized] public bool enter = false;
    [SerializeField] Animator anim;
    [SerializeField] Animator handAnim;
    [SerializeField] GameObject stepSound;
    [SerializeField] GameObject Eimage;
    public int Pass;
    [SerializeField] GameObject MainMenu;
  
   public static Player_Controller1 pla;
    private void Awake()
    {
        pla = this;
    }
    private void Start()
    {

        Time.timeScale = 1;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MainMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0;
        }
        isGround = Physics.CheckSphere(GroundCheck.position, GroundDistanse, Ground);
        if (isGround && velosity.y < 0)
        {
            velosity.y = -2f;
        }

        float vertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Speed = Sprint;

        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            Speed = NormalSpeed;
        }
        float horisontal = Input.GetAxisRaw("Horizontal");
        if (isPizzaTake)
        {
            handAnim.SetBool("IsPizzaWalking", true);
        }
        if (horisontal !=0 || vertical != 0)
        {
             if (isGround)
                {
                    stepSound.SetActive(true);
                }
                else
                {
                    stepSound.SetActive(false);
                }
            anim.SetBool("IsWalk", true);
            if (!isPizzaTake)
            {


                handAnim.SetBool("IsWalking", true);
               
            }

        }
        else
        {
            if (isPizzaTake)
            {
                handAnim.SetBool("IsPizzaWalking", true);
            }
            else
            {
                handAnim.SetBool("IsPizzaWalking", false);
            }
            anim.SetBool("IsWalk", false);
            
            stepSound.SetActive(false);
            
            handAnim.SetBool("IsWalking", false);
        }
        Vector3 move = transform.right * horisontal + transform.forward * vertical;
        Vector3 move_forword = transform.forward * vertical;
        if (vertical != -1 && !isGround)
        {
            move_forword.Normalize();
            cc.Move(move_forword * Speed * Time.deltaTime);
        }
        else if (isGround)
        {
            move.Normalize();
            cc.Move(move * Speed * Time.deltaTime);
        }
            velosity.y += gravity * Time.deltaTime;
            cc.Move(velosity * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGround&& !isPizzaTake)
        {
            velosity.y = Mathf.Sqrt(JumpHeight * -2f * gravity);
        }
        
        
        
       
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.TryGetComponent<Finish_Taker>(out Finish_Taker fin))
    //    {
    //        finish = true;
    //    }
    //    else if (other.TryGetComponent<Enemy_Detect>(out Enemy_Detect lose))
    //    {
    //        menu.SetActive(true);
    //        Time.timeScale = 0;
    //    }
    //}
   
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(GroundCheck.position, GroundDistanse);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EDown"))
        {
            Eimage.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("EDown"))
        {
            Eimage.SetActive(false);
        }
    }
}


