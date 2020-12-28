using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectablesText : Singleton<CollectablesText>
{
    TextMeshProUGUI text;
    TextMeshProUGUI Text { get { return (text == null) ? text = GetComponentInChildren<TextMeshProUGUI>() : text; } }

    public void UpdateCollectionText(float number)
    {
        GameManager.Instance.skor += number;
        Text.SetText(GameManager.Instance.skor.ToString());
        BoostManager.Instance.Boost += number;
    }
}
