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
    public float DownSpeed = 20f;
     public bool isPizzaTake = false;
    
    [NonSerialized] public bool enter = false;

   [SerializeField] Down down = new();
    
   
   
  
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
        
        
        
        down.Player_down();
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
}
[System.Serializable]public class Down
{
    
    [SerializeField] float HeightNormal;
    [SerializeField] float HeightDown;
    [SerializeField] float Plus_time;
    [SerializeField] float Plus_height;
    
   
    public void Player_down()
    {

        if (Input.GetKeyDown(KeyCode.LeftControl) && Player_Controller1.pla.isGround && Player_Controller1.pla.a)
        {
            Player_Controller1.pla.Speed = Player_Controller1.pla.DownSpeed;
            Player_Controller1.pla.cc.height = HeightDown;

            Player_Controller1.pla.a = false;


        }
        else if (Input.GetKeyDown(KeyCode.LeftControl) && Player_Controller1.pla.isGround && !Player_Controller1.pla.a)
        {
            Player_Controller1.pla.Speed = Player_Controller1.pla.NormalSpeed;
            Player_Controller1.pla.StartCoroutine(Down_Time());

            Player_Controller1.pla.a = true;

        }


    }
    IEnumerator Down_Time()
    {


        while (Player_Controller1.pla.cc.height <= HeightNormal)
        {
            yield return new WaitForSeconds(Plus_time);
            Player_Controller1.pla.cc.height += Plus_height;
                Player_Controller1.pla.enter = true;
        }

 
    }
}
