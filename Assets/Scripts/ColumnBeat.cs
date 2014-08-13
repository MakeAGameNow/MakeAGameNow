using UnityEngine;
using System.Collections;

public class ColumnBeat : MonoBehaviour
{
	public int frequencyChannel = 32;
	public float amplitudeMultiplier = 1.0f;

	public bool randomizeFrequencyChannel = false;

	private Vector3 originalScale;

	// Use this for initialization
	void Start ()
	{
		originalScale = transform.localScale;
		if(randomizeFrequencyChannel)
		{
			frequencyChannel = Random.Range(0,SpectrumData.Instance.samples);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 newScale = transform.localScale;
		newScale.y = originalScale.y + SpectrumData.Instance.data[frequencyChannel] * amplitudeMultiplier;
		transform.localScale = newScale;
	}
}
