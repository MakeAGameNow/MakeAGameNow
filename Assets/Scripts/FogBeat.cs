using UnityEngine;
using System.Collections;

public class FogBeat : MonoBehaviour
{
	public int frequencyChannel = 32;
	public float amplitudeMultiplier = 1.0f;

	private float originalFogDensity;

	// Use this for initialization
	void Start ()
	{
		originalFogDensity = RenderSettings.fogDensity;
	}
	
	// Update is called once per frame
	void Update ()
	{
		RenderSettings.fogDensity = originalFogDensity + SpectrumData.Instance.data[frequencyChannel]*amplitudeMultiplier;
	}
}
