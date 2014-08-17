using UnityEngine;
using System.Collections;

public class GibOnTrigger : MonoBehaviour
{
	public GameObject gib;
	public float scoreValue = 0.0f;
	public GameObject destroyTarget;

	void Start()
	{
		if(destroyTarget == null)
		{
			destroyTarget = gameObject;
		}
	}

	void OnTriggerEnter()
	{
		Instantiate(gib, transform.position, Quaternion.identity);
		GameManager.Instance.score += scoreValue;
		Destroy(destroyTarget);
	}
}
