using UnityEngine;
using System.Collections;

public class DetectTouchesAndClicks : MonoBehaviour
{
	public LayerMask touchableLayers = -1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Detect objects clicked by mouse
		if(Input.GetMouseButton(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			RaycastHit hit;

			if(Physics.Raycast(ray, out hit, Mathf.Infinity, touchableLayers))
			{
				//Debug.Log("Object Name: " + hit.collider.name, hit.collider.gameObject);
				hit.collider.SendMessage("Touched", SendMessageOptions.DontRequireReceiver);
			}
		}

		//Detect objects touched by finger
		if(Input.touchCount > 0)
		{
			foreach(Touch touch in Input.touches)
			{
				Ray ray = Camera.main.ScreenPointToRay((Vector3)touch.position);
				
				RaycastHit hit;
				
				if(Physics.Raycast(ray, out hit, Mathf.Infinity, touchableLayers))
				{
					//Debug.Log("Object Name: " + hit.collider.name, hit.collider.gameObject);
					hit.collider.SendMessage("Touched", SendMessageOptions.DontRequireReceiver);
				}
			}
		}

	}
}
