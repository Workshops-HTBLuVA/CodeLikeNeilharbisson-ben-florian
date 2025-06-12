using UnityEngine;

public enum ColorOption
{
    Red,
    Green,
    Blue,
    Yellow,
    Orange,
    Violet,
    Cyan,
    White
}

[CreateAssetMenu(fileName = "NewColorSoundTask", menuName = "ColorSound/Task")]
public class ColorSoundTask : ScriptableObject
{
    public AudioClip targetSound;
    public ColorOption correctColor;
    public ColorOption[] options = new ColorOption[3];
}