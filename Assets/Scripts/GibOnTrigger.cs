using UnityEngine;
using System.Collections;

public class GibOnTrigger : MonoBehaviour
{
	public GameObject gib;
	public float scoreValue = 0.0f;

	void OnTriggerEnter()
	{
		Instantiate(gib, transform.position, Quaternion.identity);
		GameManager.Instance.score += scoreValue;
		Destroy(gameObject);
	}
}
