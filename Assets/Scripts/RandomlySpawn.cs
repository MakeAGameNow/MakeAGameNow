using UnityEngine;
using System.Collections;

public class RandomlySpawn : MonoBehaviour
{
	public GameObject thingie;
	public float minHorizontal = -10.0f;
	public float maxHorizontal = 10.0f;
	public float minVertical = -10.0f;
	public float maxVertical = 10.0f;

	public float minSpawnTime = 1.0f;
	public float maxSpawnTime = 1.0f;

	public float spawnsPerSpeedUnit = 0.1f;

	// Use this for initialization
	void Start ()
	{
		Invoke ("SpawnNow", Random.Range(minSpawnTime, maxSpawnTime));
	}
	
	void SpawnNow()
	{
		for(int i = (int)(spawnsPerSpeedUnit*GameManager.Instance.gameSpeed); i > 0; i--)
		{
			Instantiate(thingie, transform.position + new Vector3(Random.Range(minHorizontal,maxHorizontal),Random.Range(minVertical,maxVertical)), Quaternion.identity);
		}
		Invoke ("SpawnNow", Random.Range(minSpawnTime, maxSpawnTime));
	}
}
