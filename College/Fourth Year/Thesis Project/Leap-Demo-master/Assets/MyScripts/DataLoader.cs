using UnityEngine;
using System.Collections;

public class DataLoader : MonoBehaviour {

	public string[] items;

	IEnumerator Start(){
		WWW itemsData = new WWW("http://localhost:8080/My_Game_DB/UsersData.php");
		yield return itemsData;
		string itemsDataString = itemsData.text;
		print (itemsDataString);
		items = itemsDataString.Split(';');
		print(GetDataValue(items[0], "Cost:"));
	}

	string GetDataValue(string data, string index){
		string value = data.Substring(data.IndexOf(index)+index.Length);
		if(value.Contains("|"))value = value.Remove(value.IndexOf("|"));
		return value;
	}


}
