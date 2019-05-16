using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public class Open_Scene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadScene() {
		string buttonName = this.name;
		string buttonNumber = Regex.Replace (buttonName, "[^0-9]", "");
		int levelNumber = int.Parse (buttonNumber);
		Debug.Log (levelNumber);

		SceneManager.LoadScene ("Scene " + levelNumber.ToString ());
	}
}
