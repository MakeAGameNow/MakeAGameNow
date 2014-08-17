using UnityEngine;
using System.Collections;

public class MatchMaterialColor : MonoBehaviour
{
	public string colorPropertyName = "_Color";
	public string targetColorPropertyName = "_Color";
	public string targetTag;
	private Renderer target;

	void Start()
	{
		target = GameObject.FindGameObjectWithTag (targetTag).renderer;
	}
	
	void Update()
	{
		renderer.material.SetColor(colorPropertyName, target.material.GetColor(targetColorPropertyName));
	}
}
