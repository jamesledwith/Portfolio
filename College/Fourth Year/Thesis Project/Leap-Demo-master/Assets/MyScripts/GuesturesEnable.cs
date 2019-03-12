/**using UnityEngine;
using System.Collections;
using Leap;

public class GuesturesEnable : MonoBehaviour {
    Controller controller;

    public bool spinLeft;
    public bool spinRight;
    public bool moveUp;
    public bool moveDown;

    public GameObject blockOne;
	// Use this for initialization
	void Start () {
        StartCoroutine("MyEvent");
        controller = new Controller();
        //controller.EnableGesture(Gesture.GestureType.TYPECIRCLE);
        //controller.EnableGesture(Gesture.GestureType.TYPEINVALID);
        //controller.EnableGesture(Gesture.GestureType.TYPEKEYTAP);

        controller.EnableGesture(Gesture.GestureType.TYPESCREENTAP);
        controller.Config.SetFloat("Gesture.ScreenTap.MinForwardVelocity", 100.0f);
        controller.Config.SetFloat("Gesture.ScreenTap.HistorySeconds", 0.5f);
        controller.Config.SetFloat("Gesture.ScreenTap.MinDistance", 0.5f);
        
        controller.EnableGesture(Gesture.GestureType.TYPESWIPE);
        controller.Config.SetFloat("Gesture.Swipe.MinLength", 150.0f);
        controller.Config.SetFloat("Gesture.Swipe.MinVelocity", 150.0f);
        controller.Config.Save();
	}

    private IEnumerator MyEvent()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.01f); // wait half a second
            // do things
            blockOne.transform.Translate(Vector3.down * Time.deltaTime, Space.World);
            //blockOne.transform.Translate(0f, -90f * Time.deltaTime, 0f, Space.World);
        }
    }

    private void leftSpin() 
    {
        Debug.Log("Left");
        spinLeft = true;
        spinRight = false;
        moveUp = false;
        //moveDown = false;
    }
    private void rightSpin() 
    {
        Debug.Log("Right");
        spinRight = true;
        spinLeft = false;
        moveUp = false;
        //moveDown = false;
    }
    private void changeUp() {
        Debug.Log("Tap");
        moveUp = true;
        spinLeft = false;
        spinRight = false;
        //moveDown = false;
    }
    private void changeDown() {
        Debug.Log("Down");
        moveDown = true;
        moveUp = false;
        spinLeft = false;
        spinRight = false;
    }
	
    // Update is called once per frame
	void Update () 
    {
        Frame frame = controller.Frame();
        GestureList gestures = frame.Gestures();
        Hand hand = frame.Hands.Frontmost;


        if (hand.IsRight){
            for (int i = 0; i < gestures.Count; i++)
            {
                Gesture gesture = gestures[i];
                if (gesture.Type == Gesture.GestureType.TYPE_SWIPE || gesture.Type == Gesture.GestureType.TYPE_SCREEN_TAP)
                {
                    SwipeGesture Swipe = new SwipeGesture(gesture);
                    ScreenTapGesture screentap = new ScreenTapGesture(gesture);
                    Vector swipeDirection = Swipe.Direction;
                    Vector pokeDirection = screentap.Direction;
                    
                    if (swipeDirection.x < -0)
                    {
                        leftSpin();    
                    }
                    if (swipeDirection.x > 0) 
                    {
                        rightSpin();   
                    }
                    if (pokeDirection.z > 0)
                    {
                        changeUp();    
                    }

                    /*if (swipeDirection.y > 0)
                    {
                       changeUp();
                    }
                    if (swipeDirection.y < 0)
                    {
                        changeDown();
                    }*/
/**
                }
            }
        }
        if (spinLeft == true)
        {
            //blockOne.transform.Rotate(Vector3.up, 45 * Time.deltaTime);
            blockOne.transform.Rotate(Vector3.up, 45 ,0);
            spinLeft = false;
        }
        if (spinRight == true)
        {
            //blockOne.transform.Rotate(Vector3.up, -45 * Time.deltaTime);
            blockOne.transform.Rotate(Vector3.up, -45, 0);
            spinRight = false;
        }
        if (moveUp == true)
        {
            blockOne.transform.Rotate(Vector3.left, -45, 0);
            moveUp = false;
        }
        /*else 
         * if (moveDown == true)
        {
            //blockOne.transform.Translate(Vector3.down * Time.deltaTime, Space.World);
            blockOne.transform.Rotate(Vector3.left, -45, 0);
            moveDown = false;
        }
        */

    //}
//}
