/*using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public int count; 
    public Text countText;
    public string levelToLoad;
	// Use this for initialization
	void Start () {
        count = 0;
        setCountText();
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
    void setCountText()
    {
        countText.text = "Score: " + count.ToString();
    }
	// Update is called once per frame

    public void LoadScene (){ 
        SceneManager.LoadScene(levelToLoad);
    }
	void Update () 
    {
        if (count >= 100) {LoadScene(); }  
	}
}
*/