using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_scoreText;

    public void SetScore(string score)
    {
        m_scoreText.text = score;
    }
}
