using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurvingProgressBar : MonoBehaviour
{
    public Image fillImage;
    public AncientTree tree;
    public void UpdateProgress()
    {
        fillImage.fillAmount = tree.CurrentPoint / tree.maxPoint;
    }
}
