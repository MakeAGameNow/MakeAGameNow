using UnityEngine;
using System.Collections;

public class RotateBasedOnInput : MonoBehaviour
{
	public float maxAngle = 30.0f;
	public float rotationRate = 30.0f;

	private Quaternion rightGoal = new Quaternion();
	private Quaternion leftGoal = new Quaternion();

	// Use this for initialization
	void Start ()
	{
		rightGoal.eulerAngles = new Vector3 (0.0f, 0.0f, maxAngle);
		leftGoal.eulerAngles = new Vector3 (0.0f, 0.0f, -maxAngle);
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Moving right, we rotate right
		if(Input.GetAxis("Horizontal") > 0.0f || PseudoInput.Instance.rightPressed)
		{
			transform.rotation = Quaternion.RotateTowards(transform.rotation,rightGoal,rotationRate*Time.deltaTime);
		}
		//Moving left, we rotate left
		else if(Input.GetAxis("Horizontal") < 0.0f || PseudoInput.Instance.leftPressed)
		{
			transform.rotation = Quaternion.RotateTowards(transform.rotation,leftGoal,rotationRate*Time.deltaTime);
		}
		//Not moving, rotate back to center
		else
		{
			transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(Vector3.zero),rotationRate*Time.deltaTime);
		}
	}
}
