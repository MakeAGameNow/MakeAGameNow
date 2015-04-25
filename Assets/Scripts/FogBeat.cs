using UnityEngine;
using System.Collections;

public class FogBeat : MonoBehaviour
{
	public int samples = 64;
	public int channel = 0;
	public int frequencyChannel = 32;
	public float amplitudeMultiplier = 1.0f;
	public FFTWindow window;

	private float originalFogDensity;

	// Use this for initialization
	void Start ()
	{
		originalFogDensity = RenderSettings.fogDensity;
	}
	
	// Update is called once per frame
	void Update ()
	{
		float[] data = new float[samples];
		AudioListener.GetSpectrumData (data, channel, window);
		RenderSettings.fogDensity = originalFogDensity + data[frequencyChannel]*amplitudeMultiplier;
	}
}
