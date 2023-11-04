using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller1 : MonoBehaviour
{
    [SerializeField] CharacterController cc;
    [SerializeField] public float Speed = 10f;
    [SerializeField] GameObject menu;
    public bool finish = false;
    Vector3 velosity;
    public float gravity = -9.81f;
    public Transform GroundCheck;
    public float GroundDistanse = 0.4f;
    public LayerMask Ground;
    bool isGround;
    public float JumpHeight = 10f;
private  bool a = false;
    public float NormalSpeed;
    public float Sprint = 100f;
    private bool enter = false;
    private bool isSitting = false;
    [SerializeField] float Plus_height;
    [SerializeField] float HeightNormal;
    [SerializeField] float HeightDown;
    [SerializeField] float Plus_time;
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
        else
        {
            Speed = NormalSpeed;
        }
        float horisontal = Input.GetAxisRaw("Horizontal");
        Vector3 move = transform.right * horisontal + transform.forward * vertical;
        cc.Move(move * Speed * Time.deltaTime);

        velosity.y += gravity * Time.deltaTime;
        cc.Move(velosity * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGround)
        {
            velosity.y = Mathf.Sqrt(JumpHeight * -2f * gravity);
        }
        Player_down();
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
    public void Player_down()
    {
      
        if (Input.GetKey(KeyCode.LeftControl) && isGround&& a)
        {
            
            cc.height = HeightDown;
            
            a = false;

        }
        else if(Input.GetKeyUp(KeyCode.LeftControl) && isGround && !a)
        {
            StartCoroutine(Down_Time());
            
            a = true;
        }


    }
    IEnumerator Down_Time()
    {
      

        while (cc.height <= HeightNormal)
        {
            yield return new WaitForSeconds(Plus_time);
            cc.height += Plus_height;
            enter = true;
        }

        isSitting = false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(GroundCheck.position, GroundDistanse);
    }
}
