using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorButton : MonoBehaviour
{
    ColorOption buttonColor;
    ManagerV1 manager;

    private void Awake()
    {
        manager = FindAnyObjectByType<ManagerV1>();
    }

    public void SetButtonColor(ColorOption btnColor)
    {
        buttonColor = btnColor;
        gameObject.GetComponent<Image>().color = ColorMapper.GetColor(btnColor);
    }

    public void OnClick()
    {
        manager.OnColorButtonPressed(buttonColor);
    }
}
