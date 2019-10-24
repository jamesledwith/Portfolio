using UnityEngine;
using System.Collections;

public class hoverText : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //GetComponent<TextMesh>().renderer.sortingOrder = 10;
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if (tooltipTextCtrl.status == false){
            Destroy(gameObject);
        }
	}
}
