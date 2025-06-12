using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "ColorSoundMapping", menuName = "Audio/Color Sound Mapping")]
public class ColorSoundMapping : ScriptableObject
{
    [System.Serializable]
    public struct ColorSoundEntry
    {
        public ToneColors colorCode;
        public AudioClip clip;
    }

    public ColorSoundEntry[] colorSoundEntries;
}
