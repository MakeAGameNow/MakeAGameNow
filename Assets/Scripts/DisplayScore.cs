using UnityEngine;
using System.Collections;

public class DisplayScore : MonoBehaviour
{
	private string label;
	private TextMesh textMesh;
	
	// Use this for initialization
	void Start ()
	{
		textMesh = GetComponent<TextMesh>();
		label = textMesh.text;
	}
	
	void Update()
	{
		textMesh.text = label + (int)GameManager.Instance.score;
	}
}
