using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoiseBar : MonoBehaviour
{
    private Prisoner prisoner;
    [SerializeField] Image mask;
    float originalSize;

    private void Start()
    {
        prisoner = FindObjectOfType<Prisoner>();
        originalSize = mask.rectTransform.rect.width;
    }
    // Update is called once per frame
    void Update()
    {
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize + prisoner.noiseLevel);
    }
}
