using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
    public Animator anim;
    public Rigidbody rbody;
    public AudioClip audio;

    private float inputH;
    private float inputV;
    private bool run;
    private bool point;
    //private bool block;
    public float rotate = 100.0f;
    public int speed = 2;

	// Use this for initialization
	void Start () {
	    anim = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody>();
        run = false;
        point = false;
        //block = false;
	}
   

   

    /*void runLeft()
    {
        GameObject.Find("LeftRun").GetComponent<ParticleSystem>().Play();
        GetComponent<AudioSource>().clip = audio;
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().volume = 2.0f;
        GetComponent<AudioSource>().pitch = 1.2f;
    }

    void runRight()
    {
        GameObject.Find("RightRun").GetComponent<ParticleSystem>().Play();
        GetComponent<AudioSource>().clip = audio;
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().volume = 2.0f;
        GetComponent<AudioSource>().pitch = 1.2f;
    }*/
    void walkLeft()
    {
        GameObject.Find("LeftParticle").GetComponent<ParticleSystem>().Play();
        GetComponent<AudioSource>().clip = audio;
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().volume = 1.0f;
        GetComponent<AudioSource>().pitch = 1.0f;
    }
    void walkRight()
    {
        GameObject.Find("RightParticle").GetComponent<ParticleSystem>().Play();
        GetComponent<AudioSource>().clip = audio;
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().volume = 1.0f;
        GetComponent<AudioSource>().pitch = 1.0f;
    }
    void running()
    {
        GetComponent<AudioSource>().clip = audio;
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().volume = 2.0f;
        GetComponent<AudioSource>().pitch = 1.2f;
    }

    void animationsActions() {
        if (Input.GetKeyDown("mouse 1"))
        {
            anim.Play("Body|Point", -1, 0f);
        }
        if (Input.GetKeyDown("1"))
        {
            anim.Play("Run", -1, 0f);
        }
        if (Input.GetKeyDown("mouse 0"))
        {
            anim.Play("Body|Blocking F", -1, 0f);
        }
        if (Input.GetKeyDown("3"))
        {
            anim.Play("Body|walk", -1, 0f);
        }
    }
	// Update is called once per frame
	void Update () {

        animationsActions();

        //Running 
        if (Input.GetKey(KeyCode.LeftShift)){
            run = true;
        }
        else{
            run = false;
        }
        if (run){
            gameObject.transform.position += transform.forward * Time.deltaTime * (speed + 5);
        }
        //Movement directions
        if (Input.GetKey("w")){ 
            gameObject.transform.position += transform.forward * Time.deltaTime * speed; 
        }
        if (Input.GetKey("a")){
            gameObject.transform.Rotate(0, Time.deltaTime * -rotate, 0);
        }
        if (Input.GetKey("d")){
            gameObject.transform.Rotate(0, Time.deltaTime * rotate, 0);
        }
        if (Input.GetKey("s")){
            gameObject.transform.position -= transform.forward * Time.deltaTime * speed;
        }
        //Pointing
        if (Input.GetKey(KeyCode.Space)){
            point = true;
        }
        else{
            point = false;
        }
        
       
       
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");
        
        anim.SetFloat("inputH", inputH);
        anim.SetFloat("inputV", inputV);
        anim.SetBool("run",run);
        anim.SetBool("point", point);
        

        


      }
}

     
        
        