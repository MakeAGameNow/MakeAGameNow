using UnityEngine;
using System.Collections;

public class SpectrumData : MonoBehaviour
{
	public static SpectrumData Instance;

	public int samples = 64;
	public int channel = 0;
	public FFTWindow window;
	
	public float[] data;

	// Use this for initialization
	void Start ()
	{
		if(Instance != this)
		{
			if(Instance == null)
			{
				Instance = this;
			}
			else
			{
				Destroy(gameObject);
			}
		}
		data = new float[samples];
	}
	
	// Update is called once per frame
	void Update ()
	{
		AudioListener.GetSpectrumData(data, channel, window);
	}
}
