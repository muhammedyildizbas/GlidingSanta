using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI GameOverScoreText;

    private void OnEnable()
    {
        GameOverScoreText.SetText(GameManager.Instance.skor.ToString());
    }
}
