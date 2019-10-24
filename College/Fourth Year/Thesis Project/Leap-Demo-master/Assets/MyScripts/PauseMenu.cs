using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour {
    GameObject[] pauseObjects;
    GameObject[] finishObjects;
    GameObject[] completeObjects;
    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;

        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");			//gets all objects with tag ShowOnPause
        finishObjects = GameObject.FindGameObjectsWithTag("ShowOnFinish");			//gets all objects with tag ShowOnFinish
        completeObjects = GameObject.FindGameObjectsWithTag("ShowOnComplete");	    //gets all objects with tag ShowOnComplete


        hidePaused();
        hideFinished();
        hideComplete();

        //Checks to make sure MainLevel is the loaded level
        //if (Application.loadedLevelName == "MainLevel")
        //playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

        //uses the p button to pause and unpause the game
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1 && ScoreTracker.alive == true)
            {
                Time.timeScale = 0;
                showPaused();
            }
            else if (Time.timeScale == 0 && ScoreTracker.alive == true)
            {
                Time.timeScale = 1;
                hidePaused();
            }
        }

        //shows finish gameobjects if player is dead and timescale = 0
       // if (Time.timeScale == 0 && ScoreTracker.alive == false)
        //{
        //    Time.timeScale = 0;
        //    showFinished();
       // }
        //shows finish gameobjects if player is dead and timescale = 1
        if (Time.timeScale == 1 && ScoreTracker.alive == false)
        {
            Time.timeScale = 0;
            showFinished();    
        }
       
        //shows complete gameobjects if player is complete and timescale = 0
        //if (Time.timeScale == 0 && ScoreTracker.completedLvl == true)
        //{
         //   Time.timeScale = 0;
         //   showComplete();
       // }
        //shows complete gameobjects if player is complete and timescale = 1
        if (Time.timeScale == 1 && ScoreTracker.completedLvl == true)
        {
            Time.timeScale = 0;
            showComplete();
        }
      
    }


    //Reloads the Level
    public void Reload()
    {      
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //TutorialScreenWarmup.guiShow = false;
    }

    //controls the pausing of the scene
    public void pauseControl()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            showPaused();
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            hidePaused();
        }
    }

    //shows objects with ShowOnPause tag
    public void showPaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }

    //hides objects with ShowOnPause tag
    public void hidePaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
    }

    //shows objects with ShowOnFinish tag
    public void showFinished()
    {
        foreach (GameObject g in finishObjects)
        {
            g.SetActive(true);
        }
    }

    //hides objects with ShowOnFinish tag
    public void hideFinished()
    {
        foreach (GameObject g in finishObjects)
        {
            g.SetActive(false);
        }
    }

    public void showComplete()
    {
        foreach (GameObject g in completeObjects)
        {
            g.SetActive(true);
        }
    }

    //hides objects with ShowOnComplete tag
    public void hideComplete()
    {
        foreach (GameObject g in completeObjects)
        {
            g.SetActive(false);
        }
    }

    //loads inputted level
    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
}
