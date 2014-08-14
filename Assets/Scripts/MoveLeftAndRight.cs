﻿using UnityEngine;
using System.Collections;

public class MoveLeftAndRight : MonoBehaviour
{
	public float speed = 1.0f;
	public float dashSpeed = 2.0f;
	public float dashDuration = 1.0f;
	public float doubleTapSpeed = 0.5f;

	private float lastTap = 0.0f;
	private bool pressedLeftLast = false;
	private bool pressedRightLast = false;
	private bool buttonPressed = false;

	private static bool isDashing = false;
	private static float dashDirection = 1.0f;
	private static float t = 0.0f;

	// Use this for initialization
	void Start ()
	{
		if(isDashing)
		{
			StartCoroutine(Dash(dashSpeed*dashDirection));
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		//This moves our object left or right based on keyboardinput
		transform.position += Vector3.right*Input.GetAxis("Horizontal")*speed*Time.deltaTime;

		if(PseudoInput.Instance.leftPressed)
		{
			if(pressedLeftLast && !buttonPressed && lastTap <= doubleTapSpeed)
			{
				//Dash
				Debug.Log("DashLeft");
				t = 0.0f;
				dashDirection = -1.0f;
				StartCoroutine(Dash(dashSpeed*dashDirection));
				buttonPressed = true;
			}
			else if(!isDashing)
			{
				transform.position += Vector3.left*speed*Time.deltaTime;
				lastTap = 0.0f;
				pressedLeftLast = true;
				pressedRightLast = false;
				buttonPressed = true;
			}
		}
		if(PseudoInput.Instance.rightPressed)
		{
			if(pressedRightLast && !buttonPressed && lastTap <= doubleTapSpeed)
			{
				//Dash
				Debug.Log("DashRight");
				t = 0.0f;
				dashDirection = 1.0f;
				StartCoroutine(Dash(dashSpeed*dashDirection));
				buttonPressed = true;
			}
			else if(!isDashing)
			{
				transform.position += Vector3.right*speed*Time.deltaTime;
				lastTap = 0.0f;
				pressedRightLast = true;
				pressedLeftLast = false;
				buttonPressed = true;
			}
		}
		if(!PseudoInput.Instance.rightPressed && !PseudoInput.Instance.leftPressed)
		{
			buttonPressed = false;
		}
		lastTap += Time.deltaTime;

		t += Time.deltaTime;
	}

	IEnumerator Dash(float speed)
	{
		isDashing = true;

		while(t <= dashDuration)
		{
			transform.position += Vector3.right*speed*Time.deltaTime;
			yield return null;
		}
		isDashing = false;
	}
}
