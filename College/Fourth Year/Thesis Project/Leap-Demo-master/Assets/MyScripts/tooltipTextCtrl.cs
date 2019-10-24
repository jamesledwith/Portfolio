using UnityEngine;
using System.Collections;

public class tooltipTextCtrl : MonoBehaviour {
    public Transform popuptext;
    public static bool status = false;
	// Use this for initialization
	void Start () {
	
	}
    void OnMouseEnter() {
        if (status == false)
        {
            if (gameObject.name == "Ball Roll Title")
            {
                popuptext.GetComponent<TextMesh>().text = "This game tests your hand eye coordination\n choose your level difficulty";
            }
            if (gameObject.name == "Shape Switch")
            {
                popuptext.GetComponent<TextMesh>().text = "This game tests your spatial awareness and dexterity\n  choose your level difficulty";
            }
            status = true;
            Instantiate(popuptext, new Vector3(transform.position.x, transform.position.y, 0), popuptext.rotation);
           
        }
    }

    void OnMouseExit()
    {
        if (status == true)
        {
            status = false;
        }
    }

	// Update is called once per frame
	void Update () {
	
	}
}
