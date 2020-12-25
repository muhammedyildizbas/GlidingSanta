using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectablesText : Singleton<CollectablesText>
{
    Text text;
    Text Text { get { return (text == null) ? text = GetComponent<Text>() : text; } }


    int score = 0;

    public void UpdateCollectionText(int number)
    {
        score += number;
        Text.text = "Score: " + score;

    }
}
