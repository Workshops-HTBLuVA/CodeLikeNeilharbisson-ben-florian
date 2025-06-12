using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class HueToTone : MonoBehaviour
{
    [Range(0f, 1f)]
    public float hue = 0.5f; // z. B. vom ColorPicker oder zufällig

    private AudioSource audioSource;
    private float frequency;
    private float sampleRate = 48000f;
    private float phase;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.loop = true;
        audioSource.spatialBlend = 0;
        audioSource.clip = AudioClip.Create("Sine", (int)sampleRate, 1, (int)sampleRate, true, OnAudioRead);
        //audioSource.Play();
    }

    public void PlayTone(bool playTone)
    {
        if (playTone) { audioSource.Play(); }
        else { audioSource.Stop(); }
    }

    private void Update()
    {
        frequency = MapHueToFrequency(hue);
    }

    private void OnAudioRead(float[] data)
    {
        int harmonics = 25; // mehr Oberwellen! (z. B. 25 statt 3)

        for (int i = 0; i < data.Length; i++)
        {
            float sample = 0f;
            float baseIncrement = 2f * Mathf.PI * frequency / sampleRate;

            // Summe aller ungeraden Oberwellen
            for (int h = 1; h <= harmonics; h += 2)
            {
                sample += (1f / h) * Mathf.Sin(h * phase);
            }

            // Normalisieren
            sample *= 0.7f;

            data[i] = sample;

            phase += baseIncrement;
            if (phase > 2f * Mathf.PI) phase -= 2f * Mathf.PI;
        }
    }

    private float MapHueToFrequency(float h)
    {
        return Mathf.Lerp(220f, 880f, h);
    }
}
