using UnityEngine;
using UnityEngine.UI;
using TMPro;
public enum ToneColors{
    White,
    Black,
    Red,
    Orange,
    Yellow,
    Green,
    Cyan,
    Blue,
    Violett
}

public class ColorTonePuzzle : MonoBehaviour
{
    private Color[] rgbColors;
    private float[] hueColors;
    [SerializeField] private HueToTone colorAndTone;
    [SerializeField] private Image colorImage;
    [SerializeField] private TMP_Text colorText;

    // Start is called before the first frame update
    private void Start()
    {

        rgbColors = new Color[9];
        hueColors = new float[9];

        rgbColors[0] = Color.white;
        rgbColors[1] = Color.black;
        rgbColors[2] = Color.red;
        rgbColors[3] = new Color32(255, 165, 0, 255);
        rgbColors[4] = Color.yellow;
        rgbColors[5] = Color.green;
        rgbColors[6] = Color.cyan;
        rgbColors[7] = Color.blue;
        rgbColors[8] = new Color(128, 0, 128, 255);

        PrintArray(rgbColors);
        ConvertRBGToHSV();
        for (int i = 0; i < hueColors.Length; i++)
        {
            Debug.Log(i + " - " + hueColors[i]);
        }

        PlayTone();
    }

    private ToneColors GetRandomColorCode()
    {
        var values = System.Enum.GetValues(typeof(ToneColors));
        int randomIndex = Random.Range(0, values.Length); // UnityEngine.Random
        return (ToneColors)values.GetValue(randomIndex);
    }

    public void PlayTone()
    {
        ToneColors toneColors = GetRandomColorCode();

        colorAndTone.hue = hueColors[(int)toneColors];
        colorImage.color = rgbColors[(int)toneColors];
        colorText.text = toneColors.ToString();
        colorAndTone.PlayTone(true);
    }

    private void PrintArray(Color[] colorArray) 
    {
        for (int i = 0; i < colorArray.Length; i++)
        {
            Debug.Log(colorArray[i]);
        }
    }

    private void ConvertRBGToHSV()
    {
        for (int i = 0; i < rgbColors.Length; i++)
        {
            float H, S, V;
            Color.RGBToHSV(rgbColors[i],out H,out S,out V);
            hueColors[i] = H * 360f;
        }
    }

}
