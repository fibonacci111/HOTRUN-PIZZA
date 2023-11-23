using System.Collections;
using System.Collections.Generic; 
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Raycas : MonoBehaviour
{
    Camera cam;


    public bool snd;
    public bool snd1;

    public AudioSource aud;
    private float time = 0;

    public Animator animator;
    public Animator animator2;
    public Animator animator3;
    public string currentAnimation;
    public string currentAnimation2;

    public GameObject a;
    public GameObject b;
    public GameObject c;

    public int lvlNum;

    public LayerMask start;  
    public LayerMask autors;
    public LayerMask exit;

    public LayerMask menu;
    public LayerMask allo;
    public string allo1;
    public LayerMask pamagiti;
    public string pamagiti1;
    public LayerMask chips;
    public string chips1;
    public LayerMask danil;
    public string danil1;
    public LayerMask denis;
    public string denis1;
    public LayerMask dima;
    public string dima1;
    public LayerMask ds;
    public string ds1;
    public LayerMask glock;
    public string glock1;
    public LayerMask zhenya;
    public string zhenya1;
    public LayerMask scum;
    public string scum1;
    public LayerMask rudolph;
    public string rudolph1;
    public LayerMask lvl;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        print(cam.name);
        animator = GetComponent<Animator>();

    }

    void Animationn(string animation)
    {
        if(currentAnimation == animation) return;



               
            


        animator.Play(animation);

        currentAnimation = animation;
    }

    void Animationn2(string animation2)
    {
        if (currentAnimation2 == animation2) return;

           


        animator2.Play(animation2);

        currentAnimation2 = animation2;
    }



    // Update is called once per frame

    

    void Update()
    {
        time += 1 * Time.deltaTime;
        
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 100f;
        mousePos = cam.ScreenToWorldPoint(mousePos);
        Debug.DrawRay(transform.position, mousePos - transform.position, Color.blue);

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100, start))
        {
            Debug.Log(hit.transform.name);
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("aboaba");
                SceneManager.LoadScene(1);
                Time.timeScale = 1;
            }

                if (snd == false)
            {
                aud.Play();
                snd = true;

            }
                
            Animationn("on");
            
        }
        else
        {
            Animationn("off") ;
            snd = false;
        }

        if (Physics.Raycast(ray, out hit, 100, exit))
        {
            Debug.Log(hit.transform.name);

            if (snd1 == false)
            {
                aud.Play();
                snd1 = true;

            }

            Animationn2("on");
            
        }
        else
        {
            Animationn2("off");
            snd1 = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            

            if (Physics.Raycast(ray, out hit, 100, allo))
            {
                Debug.Log(hit.transform.name);
                Application.OpenURL(allo1);
            }
            if (Physics.Raycast(ray, out hit, 100, start))
            {
                Debug.Log("aboaba");
                SceneManager.LoadScene(1);
                Time.timeScale = 1;
            }
            if (Physics.Raycast(ray, out hit, 100, autors))
            {
                Debug.Log(hit.transform.name);
                a.transform.position = new Vector3(215, 400, 18);
                
                Time.timeScale = 0;
            }
            if (Physics.Raycast(ray, out hit, 100, menu))
            {
                Debug.Log(hit.transform.name);
                a.transform.position = new Vector3(215, 1, 18);
                Time.timeScale = 0;
            }
            if (Physics.Raycast(ray, out hit, 100, pamagiti))
            {
                Debug.Log(hit.transform.name);
                Application.OpenURL(pamagiti1);
            }
            if (Physics.Raycast(ray, out hit, 100, chips))
            {
                Debug.Log(hit.transform.name);
                Application.OpenURL(chips1);
            }
            if (Physics.Raycast(ray, out hit, 100, danil))
            {
                Debug.Log(hit.transform.name);
                Application.OpenURL(danil1);
            }
            if (Physics.Raycast(ray, out hit, 100, denis))
            {
                Debug.Log(hit.transform.name);
                Application.OpenURL(denis1);
            }
            if (Physics.Raycast(ray, out hit, 100, dima))
            {
                Debug.Log(hit.transform.name);
                Application.OpenURL(dima1);
            }
            if (Physics.Raycast(ray, out hit, 100, ds))
            {
                Debug.Log(hit.transform.name);
                Application.OpenURL(ds1);
            }
            if (Physics.Raycast(ray, out hit, 100, glock))
            {
                Debug.Log(hit.transform.name);
                Application.OpenURL(glock1);
            }
            if (Physics.Raycast(ray, out hit, 100, zhenya))
            {
                Debug.Log(hit.transform.name);
                Application.OpenURL(zhenya1);
            }
            if (Physics.Raycast(ray, out hit, 100, scum))
            {
                Debug.Log(hit.transform.name);
                Application.OpenURL(scum1);
            }
            if (Physics.Raycast(ray, out hit, 100, rudolph))
            {
                Debug.Log(hit.transform.name);
                Application.OpenURL(rudolph1);
            }
            if (Physics.Raycast(ray, out hit, 100, lvl))
            {
                Debug.Log(hit.transform.name);
                SceneManager.LoadScene(lvlNum);
                Time.timeScale = 1;
            }
            if (Physics.Raycast(ray, out hit, 100, exit))
            {
                Debug.Log(hit.transform.name);
                Application.Quit();
            }
        }
    }
        

}
