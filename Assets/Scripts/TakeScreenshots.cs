using UnityEngine;
using System.Collections;

public class TakeScreenshots : MonoBehaviour
{
	private int screenNumber = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.P))
		{
			Application.CaptureScreenshot("Screenshot" + System.DateTime.Now.ToString("yyMMdd H.mm.ss") + ".png",3);
		}
	}
}
