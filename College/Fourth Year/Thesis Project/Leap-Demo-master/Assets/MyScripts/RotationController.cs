/*using UnityEngine;
using System.Collections;
using Leap.Unity;


public class RotationController : MonoBehaviour {
    public Quaternion rotationHand;
    public HandModel hand_model;
	
    // Use this for initialization
	void Start () {
        hand_model = GetComponent<HandModel>();
	}
    public Quaternion handRotation()
    {
        Debug.Log(hand_model.GetPalmRotation());
        return hand_model.GetPalmRotation();       
    }
	// Update is called once per frame
	void Update () {
        if (handRotation <= 0.2)
        { 
             public Quaternion rotation = Quaternion.Euler(0, 30, 0);
        }
	}
}*/
