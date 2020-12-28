using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostUI : MonoBehaviour
{
    public Slider fill;
    public RectTransform rocket;

    private void Start()
    {
        fill.maxValue = BoostManager.Instance.maxBoost;
        fill.value = BoostManager.Instance.Boost;
    }

    private void Update()
    {
        fill.value = BoostManager.Instance.Boost;
        rocket.anchoredPosition = new Vector2(11f, -200f + (530f * (fill.value / fill.maxValue)));
    }
}
