using UnityEngine;
using System.Collections;

public class DisplayPreviousScore : MonoBehaviour
{
	private string label;
	
	// Use this for initialization
	void Start ()
	{
		TextMesh textMesh = GetComponent<TextMesh>();
		label = textMesh.text;
		textMesh.text = label + GameManager.Instance.previousScore;
	}
}
