using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class BackEndInterface2 : MonoBehaviour {
	
	private string URL,suffix;
	private WWW www;
	private byte[] buffer;
	int readingAt;
	/// <summary>
	/// Level == cromosome number
	/// must be between 1 and 12
	/// </summary>
	public int level;
	
	public static List<Vector2> positions;
	
	// Use this for initialization
	void Start () {
		URL = "http://ec2-54-228-67-114.eu-west-1.compute.amazonaws.com/";
		suffix = "get.php?num=";
		www =  new WWW(URL+suffix+level.ToString());
		readingAt=0;
		positions = new List<Vector2>();
	}
	
	// Update is called once per frame
	void Update () {
	
		if(www.progress == 1)
		{
			if(www.isDone)
			{
				buffer = www.bytes;
				while(readingAt < buffer.Length-1)
				{
					positions.Add(getLine());
				}
				//Debug.Log("positions size"+ positions.Count);
				Application.LoadLevel("DevScene_Blair");
			}
		}
			
		
		
		else{
			float prog  = www.progress;
			string output = "loading " + prog.ToString("0.00");
			Debug.Log(output);
		}
		
	}
	
	Vector2 getLine()
	{
		string line = "";
		while ((char)buffer[readingAt] != '\n')
		{
			line += (char)buffer[readingAt];
			readingAt++;
		}
		readingAt++;
		
		string [] split = line.Split(new char [] {' ', ',', ':', '\t' });

		float x, y;
		float.TryParse(split[0],out x);
		float.TryParse(split[1],out y);
		return new Vector2(y,x);
	}
}
