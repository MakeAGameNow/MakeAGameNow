using UnityEngine;
using System.Collections;

public class DestroyUnderZValue : MonoBehaviour
{
	public float destroyValue = 0.0f;

	// Update is called once per frame
	void Update ()
	{
		if(transform.position.z <= destroyValue)
		{
			Destroy(gameObject);
		}
	}
}
