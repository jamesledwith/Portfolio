using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{


    public int speed;
    public float rotate = 100.0f;
  

    void Update()
    {
        if (Input.GetKey("w"))
        {
            gameObject.transform.position += transform.forward * Time.deltaTime * speed;
        }
        if (Input.GetKey("a"))
        {
            gameObject.transform.Rotate(0, Time.deltaTime * -rotate, 0);
        }
        if (Input.GetKey("d"))
        {
            gameObject.transform.Rotate(0, Time.deltaTime * rotate, 0);
        }
        if (Input.GetKey("s"))
        {
            gameObject.transform.position -= transform.forward * Time.deltaTime * speed;
        }
    }
}