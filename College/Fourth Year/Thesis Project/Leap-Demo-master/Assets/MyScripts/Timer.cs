using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    public float timer = 100f;
    public float goalTimer = 95f;
    private Text timerSec;
    public string levelToLoad;
    //public float waitTimeForSpawn = 50f;
    // Use this for initialization
	
    void Start () {
        timerSec = GetComponent<Text>();
        //StartCoroutine(waitThenSpawnObjects());
	
	}
    //IEnumerator waitThenSpawnObjects() { yield return new WaitForSeconds(waitTimeForSpawn); }
    
    void timerCountdown()
    {
        timer -= Time.deltaTime;
        gameObject.GetComponent<Text>().text = "Time: " + timer.ToString("F0"); 
        //timerSec.text = timer.ToString("F0");   
        if (timer <= 0)
        {
            SceneManager.LoadScene(levelToLoad);
        }
        if (timer <= goalTimer)
        {
            ScoreTracker.alive = false;
            //GameObject.Find("Timer").GetComponent<Spawner>().SpawnObjects();
        }
        
    }
	// Update is called once per frame
    void Update()
    {
        timerCountdown();
    }
       
}
