using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

public class DialogueParser : MonoBehaviour {

	List<DialogueLine> lines;
	List<Sprite> Images;

	struct DialogueLine {
		public string name;
		public string content;
		public int pose;

		public DialogueLine(string n, string c, int p){
			name = n;
			content = c;
			pose = p;
		}
	}

	// Use this for initialization
	void Start () {
		string file = "Dialogue";
		string sceneName = EditorSceneManager.GetActiveScene().name;
		sceneName = Regex.Replace (sceneName, "[^0-9]", "");
		file += sceneName + ".txt";

		lines = new List<DialogueLine> ();
		LoadDialogue (file);

		Images = new List<Sprite> ();
		LoadImages ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public string GetName (int lineNummber) {
		if (lineNummber < lines.Count)
			return lines [lineNummber].name;
		return "";
	}

	public string GetContent (int lineNumber) {
		if (lineNumber < lines.Count)
			return lines [lineNumber].content;
		return "";
	}

	public Sprite GetPose (int lineNumber) {
		if (lineNumber < lines.Count)
			return Images [lines [lineNumber].pose];
		return null;
	}

	void LoadDialogue(string filename) {
		string file = "Assets/Resources/" + filename;
		string line;
		StreamReader fileptr = new StreamReader (file);
		using (fileptr) {
			while ((line = fileptr.ReadLine ()) != null) {
				
				if (line != null) {
					string[] line_values = line.Split ('|');
					DialogueLine line_entry = new DialogueLine (line_values [0], line_values [1], int.Parse (line_values [2]));
					lines.Add (line_entry);
				}
			}
			fileptr.Close ();
		}
	}

	void LoadImages () {
		for (int i = 0; i < lines.Count; ++i) {
			string imageName = lines [i].name;
			Sprite image = (Sprite)Resources.Load (imageName, typeof(Sprite));
			if (!Images.Contains (image)) {
				Images.Add (image);
				Debug.Log (image);
			}
		}
	}
}
