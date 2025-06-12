using UnityEngine;

public static class ColorMapper
{
    public static Color GetColor(ColorOption option) 
    {
        switch (option)
        {
            case ColorOption.Red: return Color.red;
            case ColorOption.Green: return Color.green;
            case ColorOption.Blue: return Color.blue;
            case ColorOption.Yellow: return Color.yellow;
            case ColorOption.Orange: return new Color(1f, 0.5f, 0f);      // RGB Orange
            case ColorOption.Violet: return new Color(0.5f, 0f, 1f);     // RGB Violett
            case ColorOption.Cyan: return Color.cyan;
            case ColorOption.White: return Color.white;
            default: return Color.gray;
        }
    }
}
