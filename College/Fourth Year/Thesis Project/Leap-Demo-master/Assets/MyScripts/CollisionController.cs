using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class CollisionController : MonoBehaviour {
   //public int count; 
    public Text countText;
    public string levelToLoad;
    public GameObject scoreText;
	// Use this for initialization
	void Start () {
        scoreText = GameObject.Find("Score");
        //count = 0;
        }

    //Score system and collisions with game objects
    void OnCollisionEnter(Collision other)
    {
        //C
        //GameObject.Find("Spawner").GetComponent<Spawner>().spawned = false;
        if (other.gameObject.name == "holeHit")
        {
            scoreText.GetComponent<ScoreTracker>().score = scoreText.GetComponent<ScoreTracker>().score + 1;
            Debug.Log(gameObject.name + " has collided with " + other.gameObject.name);
            GameObject.Find("Spawner").GetComponent<Spawner>().SpawnObjects();
            Destroy(this.gameObject);
        }
        //else if (other.gameObject.tag == "Miss")
        //{
            //scoreText.GetComponent<ScoreTracker>().score = scoreText.GetComponent<ScoreTracker>().score - 1;

            //GameObject.Find("Spawner").GetComponent<Spawner>().SpawnObjects();
            //Destroy(this.gameObject);
        //}
    }
   
	void Update () 
    {
        //if (count >= 100) {LoadScene(); }  
	}
}


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


