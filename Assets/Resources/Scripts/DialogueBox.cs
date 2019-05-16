using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBox : MonoBehaviour {

	DialogueParser parser;

	public string dialogue;
	public string name;
	public Sprite pose;
	int lineNum;

	public GUIStyle customStyle, customStyleName;

	// Use this for initialization
	void Start () {
		dialogue = "";
		parser = GameObject.Find ("Dialogue Parser Obj").GetComponent<DialogueParser> ();
		lineNum = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			ResetImages ();


			name = parser.GetName (lineNum);
			dialogue = parser.GetContent (lineNum);
			pose = parser.GetPose (lineNum);
			DisplayImages ();
			lineNum++;
		}
	}

	void ResetImages() {
		if (name != "") {
			GameObject Character = GameObject.Find (name);
			SpriteRenderer currSprite = Character.GetComponent<SpriteRenderer> ();
			currSprite.sprite = null;
		}
	}

	void DisplayImages() {
		if (name != "") {
			GameObject Character = GameObject.Find (name);
			SetSpritePositions (Character);
			SpriteRenderer currSprite = Character.GetComponent<SpriteRenderer> ();
			currSprite.sprite = pose;
		}
	}

	void SetSpritePositions (GameObject spriteObj) {
		spriteObj.transform.position = new Vector3 (6.93f, 0.95f, -2.82f);
		spriteObj.transform.localScale = new Vector3 (0.36f, 0.37f, 1);
	}

	void OnGUI() {
		dialogue = GUI.TextField (new Rect (0, 200, 900, 200), dialogue, customStyle);
		name = GUI.TextField (new Rect (0, 170, 100, 30), name, customStyleName);
	}
}
