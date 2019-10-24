using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Text.RegularExpressions;

public class Register: MonoBehaviour {
	public GameObject username;
	public GameObject email;
	public GameObject password;
	public GameObject confPassword;
	private string Username;
	private string Email;
	private string Password;
	private string ConfPassword;
	private string form;
	private bool EmailValid = false;
	private string[] Characters = {"a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z",
								   "A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z",
								   "1","2","3","4","5","6","7","8","9","0","_","-"};


	public void RegisterButton(){
		bool UN = false;  //Username
		bool EM = false;  //Email
		bool PW = false;  //Password
		bool CPW = false; //Confirm Password

        //Check Email
		if (Username != ""){
            if (!System.IO.File.Exists(@"D:\UnityUsers\" + Username + ".txt"))
            {
				UN = true;
			} 
            else 
            {
				Debug.LogWarning("Username Taken");
			}
		} 
        else 
        {
			Debug.LogWarning("Username field Empty");
		}
		if (Email != "")
        {
			EmailValidation();
			if (EmailValid)
            {
				if(Email.Contains("@"))
                {
		   			if(Email.Contains("."))
                    {
						EM = true;
					} else {
						Debug.LogWarning("Email is Incorrect");
					}
				} else 
                {
					Debug.LogWarning("Email is Incorrect");
				}
			} else 
            {
				Debug.LogWarning("Email is Incorrect");
			}
		} else 
        {
			Debug.LogWarning("Email Field Empty");
		}

        //Check Password Validility
		if (Password != "")
        {
			if(Password.Length > 3)
            {
				PW = true;
			} 
            else 
            {
				Debug.LogWarning("Password Must Be atleast 4 Characters long");
			}
		} 
        else 
        {
			Debug.LogWarning("Password Field Empty");
		}
		if (ConfPassword != "")
        {
			if (ConfPassword == Password)
            {
				CPW = true;
			} 
            else 
            {
				Debug.LogWarning("Passwords Do Not Match");
			}
		} 
        else 
        {
			Debug.LogWarning("Confirm Password Field Empty");
		}

        
		if (UN==true && EM==true && PW==true && CPW==true)
        {
            //Encrypt password
            
            
            
            //put information to text file
			form = (Username+Environment.NewLine+Email+Environment.NewLine+Password);
            System.IO.File.WriteAllText(@"D:\UnityUsers\" + Username + ".txt", form);

            //clear user input fields
            username.GetComponent<InputField>().text = "";
			email.GetComponent<InputField>().text = "";
			password.GetComponent<InputField>().text = "";
			confPassword.GetComponent<InputField>().text = "";
			
            print ("Registration Complete");
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Tab)){
			if (username.GetComponent<InputField>().isFocused){
				email.GetComponent<InputField>().Select();
			}
			if (email.GetComponent<InputField>().isFocused){
				password.GetComponent<InputField>().Select();
			}
			if (password.GetComponent<InputField>().isFocused){
				confPassword.GetComponent<InputField>().Select();
			}
		}
		if (Input.GetKeyDown(KeyCode.Return)){
			if (Password != ""&&Email != ""&&Password != ""&&ConfPassword != ""){
				RegisterButton();
			}
		}
		Username = username.GetComponent<InputField>().text;
		Email = email.GetComponent<InputField>().text;
		Password = password.GetComponent<InputField>().text;
		ConfPassword = confPassword.GetComponent<InputField>().text;
	}

	void EmailValidation()
    {
		bool SW = false; //starts with
		bool EW = false; //ends with

		for(int i = 0; i<Characters.Length; i++)
        {
			if (Email.StartsWith(Characters[i]))
            {
				SW = true;
			}
		}
		for(int i = 0; i<Characters.Length; i++)
        {
			if (Email.EndsWith(Characters[i]))
            {
				EW = true;
			}
		}
		if(SW == true && EW == true)
        {
			EmailValid = true;
		} else 
        {
			EmailValid = false;
		}
	}
}














/*//Encrypt password
           bool Clear = true;
           int i = 1;
           foreach(char c in Password)
           {
               if (Clear)
               {
                   Password = "";
                   Clear = false;
               }
               i++;
               char Encrypted = (char)(c * i); //encrypt letters 
               Password += Encrypted.ToString();
           }
           */