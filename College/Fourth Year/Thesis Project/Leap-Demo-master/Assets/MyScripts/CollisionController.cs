using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class CollisionController : MonoBehaviour {
   //public int count; 
    public Text countText;
    public string levelToLoad;
    public GameObject scoreText;
    public GameObject livesText;
    public GameObject plane;
    public float timeInTrigger = 3f;
	// Use this for initialization
	void Start () {
        scoreText = GameObject.Find("Score");
        livesText = GameObject.Find("Lives");
        plane = GameObject.Find("Plane");
        }

    //Score system and collisions with game objects
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Miss")
        {
            livesText.GetComponent<ScoreTracker>().lives = livesText.GetComponent<ScoreTracker>().lives - 1;
            Debug.Log(gameObject.name + " has collided with " + other.gameObject.name);
            GameObject.Find("Spawner").GetComponent<Spawner>().SpawnObjects();         
            Destroy(this.gameObject);
            plane.SetActive(true);
        }

        if (other.gameObject.tag == "Score")
        {
            scoreText.GetComponent<ScoreTracker>().score = scoreText.GetComponent<ScoreTracker>().score + 1;
            Debug.Log(gameObject.name + " has collided with " + other.gameObject.tag);
            GameObject.Find("Spawner").GetComponent<Spawner>().SpawnObjects();
            Destroy(this.gameObject);
        }
        
        else
        {
            Debug.Log("Spawner not working");
        }
            //else if (other.gameObject.tag == "Miss")
        //{
            //scoreText.GetComponent<ScoreTracker>().score = scoreText.GetComponent<ScoreTracker>().score - 1;

            //GameObject.Find("Spawner").GetComponent<Spawner>().SpawnObjects();
            //Destroy(this.gameObject);
        //}
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GrabTimer"))
        {
            timeInTrigger = timeInTrigger - Time.deltaTime;
            scoreText.GetComponent<ScoreTracker>().score = scoreText.GetComponent<ScoreTracker>().score + 1; 
            plane.SetActive(false);
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("GrabTimer"))
        {
            timeInTrigger = timeInTrigger - Time.deltaTime;

            if (timeInTrigger <= 0.0f)
            {
                //GameObject.Find("Spawner").GetComponent<Spawner>().SpawnObjects();
                plane.SetActive(true);
                GameObject.Find("Spawner").GetComponent<Spawner>().SpawnObjects();
                Destroy(this.gameObject);
            }
            
        }
    }
    public void hitScore() {
    }

    public void hitMiss() { 
        
    }


	void Update () 
    {
        //if (count >= 100) {LoadScene(); }  
	}
}

/*if (other.gameObject.name == "holeHit")
     {
         hitScore();
         scoreText.GetComponent<ScoreTracker>().score = scoreText.GetComponent<ScoreTracker>().score - 1;
         Debug.Log(gameObject.name + " has collided with " + other.gameObject.name);
         GameObject.Find("SpawnerTwo").GetComponent<Spawner>().SpawnObjects();
         this.num = Random.Range(0, 3);
         Destroy(this.gameObject);
     } 
     if (other.gameObject.name == "holeHit")
     {
         hitScore();
         scoreText.GetComponent<ScoreTracker>().score = scoreText.GetComponent<ScoreTracker>().score - 1;
         Debug.Log(gameObject.name + " has collided with " + other.gameObject.name);
         GameObject.Find("SpawnerThree").GetComponent<Spawner>().SpawnObjects();
         this.num = Random.Range(0, 3);
         Destroy(this.gameObject);
     }

     if (other.gameObject.tag == "Score" && num == 1)
     {
         scoreText.GetComponent<ScoreTracker>().score = scoreText.GetComponent<ScoreTracker>().score + 1;
         Debug.Log(gameObject.name + " has collided with " + other.gameObject.tag);
         GameObject.Find("Spawner").GetComponent<Spawner>().SpawnObjects();
         this.num = Random.Range(0, 3);
         Destroy(this.gameObject);
     }
     if (other.gameObject.tag == "Score" && num == 2)
     {
         scoreText.GetComponent<ScoreTracker>().score = scoreText.GetComponent<ScoreTracker>().score + 1;
         Debug.Log(gameObject.name + " has collided with " + other.gameObject.tag);
         GameObject.Find("SpawnerTwo").GetComponent<Spawner>().SpawnObjects();
         this.num = Random.Range(0, 3);
         Destroy(this.gameObject);
     }
     if (other.gameObject.tag == "Score" && num == 3)
     {
         scoreText.GetComponent<ScoreTracker>().score = scoreText.GetComponent<ScoreTracker>().score + 1;
         Debug.Log(gameObject.name + " has collided with " + other.gameObject.tag);
         GameObject.Find("SpawnerThree").GetComponent<Spawner>().SpawnObjects();
         this.num = Random.Range(0, 3);
         Destroy(this.gameObject);
     }*/





/*public void LoadScene ()
    { 
        SceneManager.LoadScene(levelToLoad);
    }


//Collider to count score when not touching the floor
void OnTriggerStay(Collider other)
{
   if (other.gameObject.CompareTag("PickupTimer"))
   {
       other.gameObject.SetActive(true);
       count++;
       countText.text = "Score: " + count.ToString();
   }
}
void OnTriggerEnter(Collider other)
{
   if (other.gameObject.CompareTag("DropReset"))
   {
       other.gameObject.SetActive(true);
       count = 0;
       countText.text = "Score: " + count.ToString();
   }
}

//void setCountText()
    //{
    //    countText.text = "Score: " + count.ToString();
    //}*/


