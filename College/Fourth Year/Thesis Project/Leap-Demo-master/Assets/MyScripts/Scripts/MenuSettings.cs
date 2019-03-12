using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuSettings : MonoBehaviour {
    public GameObject light;
    public Transform dropdown;


	
	// Update is called once per frame
	void Update () {
        if (dropdown.GetComponent<Dropdown>().value == 0)
        {
            light.GetComponent<Light>().shadows = LightShadows.Soft;
        }
        if (dropdown.GetComponent<Dropdown>().value == 1)
        {
            light.GetComponent<Light>().shadows = LightShadows.Hard;
        }
        if (dropdown.GetComponent<Dropdown>().value == 2)
        {
            light.GetComponent<Light>().shadows = LightShadows.None;
        }
    }

}
