using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectablesText : Singleton<CollectablesText>
{
    Text text;
    Text Text { get { return (text == null) ? text = GetComponent<Text>() : text; } }




    public void UpdateCollectionText(int number)
    {
        number += number;
        Text.text = "Stars: " + number;

    }
}
