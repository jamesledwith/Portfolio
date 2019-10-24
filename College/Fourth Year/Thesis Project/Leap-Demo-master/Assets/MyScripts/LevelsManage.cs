using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;
public class LevelsManage : MonoBehaviour {
    public string levelName;

    public void LoadScene(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
