using UnityEngine;
using System.Collections;

public class AnimateTexture : MonoBehaviour
{
	public Vector2 speed = Vector2.one;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		renderer.material.mainTextureOffset += speed * Time.deltaTime;
	}
}
