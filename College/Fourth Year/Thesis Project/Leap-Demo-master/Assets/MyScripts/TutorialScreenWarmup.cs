using UnityEngine;
using System.Collections;

public class TutorialScreenWarmup : MonoBehaviour {
    public Texture aTexture;
    public bool guiShow = true;
    void OnGUI()
    {
        
        float width = 780;
        float height = 400;
        
        if (guiShow == true) {
            Time.timeScale = 0;
            if (!aTexture)
            {
                Debug.LogError("Assign a Texture in the inspector.");
                return;
            }
            GUI.DrawTexture(new Rect((Screen.width / 2) - (width / 2), (Screen.height / 2) - (height / 2), width, height), aTexture, ScaleMode.StretchToFill, true, 10.0F);
        }
        
    }

    void Update() {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            Time.timeScale = 1;
            guiShow = false;
        }
    }

}
