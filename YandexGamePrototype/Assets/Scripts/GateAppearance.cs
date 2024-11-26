using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum DeformationType
{
    Width,
    Height
}

public class GateApperaence : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;

    [SerializeField] Image topImage;
    [SerializeField] Image bodyImage;

    [SerializeField] Color colorPositive;
    [SerializeField] Color colorNegative;

    [SerializeField] GameObject expandLabel;
    [SerializeField] GameObject shrinkLabel;

    [SerializeField] GameObject upLabel;
    [SerializeField] GameObject downLabel;


    public void UpdateVisual(DeformationType deformationType, int value)
    {
        if(value > 0)
        {
            text.text = "+" + value.ToString();
            SetColor(colorPositive);
        }
        else if(value == 0)
        {
            text.text = value.ToString();
            SetColor(Color.gray);
        }
        else 
        {
            text.text = value.ToString();
            SetColor(colorNegative);
        }

        // Turn off all icons
        expandLabel.SetActive(false);
        shrinkLabel.SetActive(false);
        upLabel.SetActive(false);
        downLabel.SetActive(false);

        if(deformationType == DeformationType.Height)
        {
            if(value > 0) upLabel.SetActive(true);
            else if (value < 0) downLabel.SetActive(true);
        }
        else if(deformationType == DeformationType.Width)
        {
            if(value > 0) expandLabel.SetActive(true);
            else if(value < 0) shrinkLabel.SetActive(true);
        }
    }

    void SetColor(Color color)
    {
        topImage.color = color;
        bodyImage.color = new Color(color.r, color.g, color.b, 0.5f);
    }
}
