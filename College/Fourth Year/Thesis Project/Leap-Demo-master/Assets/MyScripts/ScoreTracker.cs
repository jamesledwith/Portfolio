using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour {

    public int score = 0;
    public int goalScore = 2;
    public int lives = 3;

    public static bool alive;
    public static bool completedLvl;
	
    // Use this for initialization
	void Start () 
    {
	    alive = true;
        completedLvl = false;
	}
    

    
	// Update is called once per frame
	void Update () 
    {
        //Puts the relevent numbers in the gui based on tags
        if (gameObject.tag == "Score")
        {
            gameObject.GetComponent<Text>().text = "Score: " + score;
        }       
        if (gameObject.tag == "Lives")
        {
            gameObject.GetComponent<Text>().text = "Lives: " + lives;
        }
        if (gameObject.tag == "Goal")
        {
            gameObject.GetComponent<Text>().text = "Goal: " + goalScore;
        }


        if (score >= goalScore)
        {
            completedLvl = true;
        }
       

        if (lives <= 0)
        {
            alive = false;
        }
        
	}
}
