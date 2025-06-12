using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{

    [SerializeField] private HueToTone colorAndTone;
    [SerializeField] private Image colorImage;
    [SerializeField] private TMP_Text colorText;
    private Color[] rgbColors;

    public static SoundManager Instance { get; private set; }

    [SerializeField] private ColorSoundMapping colorSoundMapping;
    private Dictionary<ToneColors, AudioClip> colorToClip;

    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        BuildDictionary();

        rgbColors = new Color[9];

        rgbColors[0] = Color.white;
        rgbColors[1] = Color.black;
        rgbColors[2] = Color.red;
        rgbColors[3] = new Color32(255, 165, 0, 255);
        rgbColors[4] = Color.yellow;
        rgbColors[5] = Color.green;
        rgbColors[6] = Color.cyan;
        rgbColors[7] = Color.blue;
        rgbColors[8] = new Color(128, 0, 128, 255);
    }

    private void BuildDictionary()
    {
        colorToClip = new Dictionary<ToneColors, AudioClip>();
        foreach (var entry in colorSoundMapping.colorSoundEntries)
        {
            if (!colorToClip.ContainsKey(entry.colorCode))
            {
                colorToClip.Add(entry.colorCode, entry.clip);
            }
        }
    }

    private ToneColors GetRandomColorCode()
    {
        var values = System.Enum.GetValues(typeof(ToneColors));
        int randomIndex = Random.Range(0, values.Length); // UnityEngine.Random
        return (ToneColors)values.GetValue(randomIndex);
    }

    public void SetupToneColorScene()
    {
        audioSource.Stop();
        ToneColors colorCode = GetRandomColorCode();
        colorImage.color = rgbColors[(int)colorCode];
        colorText.text = colorCode.ToString();

        if (colorCode == ToneColors.Black) return;
        PlayColor(colorCode);
    }

    public void PlayColor(ToneColors colorCode)
    {
        
        if (colorToClip.TryGetValue(colorCode, out var clip))
        {
            audioSource.clip = clip;
            audioSource.loop = true;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning($"No clip assigned for color {colorCode}");
        }
    }

    public void LoadToneScene()
    {
        SceneManager.LoadScene("ToneGameV1");
    }
}
