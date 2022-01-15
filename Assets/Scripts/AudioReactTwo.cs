using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioReactTwo : MonoBehaviour
{
    public Light myLight;
    public float volumeMultiplier = 50000f;
    public float volumeDecrease = 100f;
    public float bassThreshold = 0.1f;

    void Update()
    {
        //Debug.Log(myLight.intensity);
        float[] spectrum = new float[64];

        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);
        
        for (int i = 1; i < spectrum.Length - 1; i++)
        {
            //Debug.Log(spectrum[i]);
            if (spectrum[i] > bassThreshold)
            {
                
                //myLight.intensity = spectrum[i] * volumeMultiplier;
                myLight.intensity = 10000 + spectrum[i] * volumeMultiplier;
            } else if (spectrum[i] < bassThreshold && myLight.intensity > 0)
            {
                myLight.intensity -= Time.deltaTime + volumeDecrease;
            }
        }
    }
}