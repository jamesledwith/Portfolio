using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour {
	public GameObject username;
	public GameObject password;
	public static string Username;
	private string Password;
	private String[] Lines;
	private string DecryptedPass;
    private string sPass;
    private string forms;



    public static String GetTimestamp(DateTime value)
    {
        return value.ToString("ddMMyyyyHHmmss");
        //return value.ToString("dd/MM/yyyy HH:mm:ss");
    }
	public void LoginButton()
    {
		bool UN = false; //username
		bool PW = false; //password
		
        if (Username != "")
        {
            if (System.IO.File.Exists(@"D:\UnityUsers\" + Username + ".txt"))
            {
				UN = true;
                Lines = System.IO.File.ReadAllLines(@"D:\UnityUsers\" + Username + ".txt");
			} 
            else 
            {
				Debug.LogWarning("Username Invaild");
			}
		} 
        else 
        {
			Debug.LogWarning("Username Field Empty");
		}
		if (Password != "")
        {
            //Decrypt password
            
            
            //check if passwords match
            if (System.IO.File.Exists(@"D:\UnityUsers\" + Password + ".txt"))
            {
                int i = 1;
                foreach (char c in Lines[2])
                {
                    i++;
                    char psword = c;
                    sPass += psword.ToString();
                }
                if (Password == sPass)
                {
                    PW = true;
                }
                else
                {
                    Debug.LogWarning("Password Is invalid");
                }
                PW = true;
            }
            else
            {
                Debug.LogWarning("Password Is invalid");
            }
        
        } 
        else 
        {
			Debug.LogWarning("Password Field Empty");
		}


		if (UN == true && PW == true)
        {
            String timeStamp = GetTimestamp(DateTime.Now);
			username.GetComponent<InputField>().text = "";
			password.GetComponent<InputField>().text = "";

            //forms = (Username + Environment.NewLine + Email + Environment.NewLine + Password);
           // System.IO.File.WriteAllText(@"D:\UnityUsers\" + Username + ".txt", forms);

            forms = (timeStamp  + Environment.NewLine + Username);
            System.IO.File.WriteAllText(@"D:\Login\" + timeStamp + ".txt",forms);
			
			print ("Login Sucessful");
            SceneManager.LoadScene("Start Menu");
		}
	}
	// Update is called once per frame
	void Update () 
    {
        // move through form with tab
		if (Input.GetKeyDown(KeyCode.Tab))
        {
			if (username.GetComponent<InputField>().isFocused){
				password.GetComponent<InputField>().Select();
			}
		}
        // login
		if (Input.GetKeyDown(KeyCode.Return))
        {
			if (Password != ""&&Password != "")
            {
				LoginButton();
			}
		}
		Username = username.GetComponent<InputField>().text;
		Password = password.GetComponent<InputField>().text;	
	}
}





/*//Decrypt password
            if (System.IO.File.Exists(@"D:\UnityUsers\" + Username + ".txt"))
            {
                int i = 1;
                foreach(char c in Lines[2])
                {
                    i++;
                    char Decrypted = (char)(c / i);
                    DecryptedPass += Decrypted.ToString();
                }
                if (Password == DecryptedPass)
                {
                    PW = true;
                } 
                else 
                {
                    Debug.LogWarning("Password Is invalid");
                }
            } 
            else 
            {
                Debug.LogWarning("Password Is invalid");
            }*/