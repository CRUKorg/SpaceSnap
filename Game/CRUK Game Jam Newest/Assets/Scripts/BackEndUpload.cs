using UnityEngine;
using System.Collections.Generic;

public class BackEndUpload : MonoBehaviour {
	
		private static string URL;
		private static string suffix;
		private static WWWForm uploadData;
	// Use this for initialization
	void Start () {
		URL = "http://ec2-54-228-67-114.eu-west-1.compute.amazonaws.com/";
		suffix = "send.php?num=";
		Upload(1);
	}
	
	// Update is called once per frame
	void Update () {
	}
	public static void Upload(int level)
	{
		int length = 0;
		
		List<Vector2> list;
		List<string> slist = new List<string>();
		list = ShipDataTracker.positions;
		//list.Add(new Vector2(0.11f, 1.00f));
		//list.Add(new Vector2(0.11f, 1.00f));
		
		string s = "";
		
		foreach(Vector2 v in list)
		{
			s = "";
			s = v.x.ToString("0.000000") + " " +v.y.ToString("0.000000")+System.Environment.NewLine;
			slist.Add(s);
			Debug.Log(s);
			length+= s.Length;
		}
		Debug.Log ("LENGTH "+length);
		
		uploadData = new WWWForm();

		
		byte[] bytes = new byte[length];
		
		int i=0;
		foreach(string str in slist)
		{
			
			foreach (char c in str.ToCharArray())
			{
				bytes[i] = (byte)c;
				i++;
			}
		}
		Debug.Log(bytes.ToString());
		
		uploadData.AddBinaryData("file", bytes,"file.txt" );
		
		
		WWW www = new WWW(URL+suffix+level, uploadData);
		
		while (www.progress != 1)
		{
			if(www.isDone)
			{
				
			}
			else{
				Debug.Log("Uploading"+ www.progress.ToString("0.00"));
			}
		}
		
		if(www.error != null)
		{
			Debug.Log (www.error);
		}
		else{
			Debug.Log("Upload Complete");
			Debug.Log(www.text.ToString());
		}
	}

}
