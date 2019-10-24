using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
	public Transform mainMenu, optionsMenu;
    private string forms;



    public static String GetTimestamp(DateTime value)
    {
        return value.ToString("ddMMyyyy HHmmss");
        //return value.ToString("dd/MM/yyyy HH:mm:ss");
    }

    public void LoadScene(string name){
        SceneManager.LoadScene("finalDemo1");
	}

    public void Logout(string name)
    {
        String timeStamp = GetTimestamp(DateTime.Now);
        forms = (timeStamp + Environment.NewLine + Login.Username);
        System.IO.File.WriteAllText(@"D:\Login\" + timeStamp + ".txt", forms);
        SceneManager.LoadScene("Login Menu");
    }
    
	public void QuitGame(){
		Application.Quit();
	}
	public void OptionsMenu(bool clicked){
		if (clicked == true){
			optionsMenu.gameObject.SetActive(clicked);
			mainMenu.gameObject.SetActive(false);
		} else {
			optionsMenu.gameObject.SetActive(clicked);
			mainMenu.gameObject.SetActive(true);
		}
	}


}
