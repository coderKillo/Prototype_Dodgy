using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private PlayerUI m_playerUI;

    [Header("Score")]
    [SerializeField] private int m_score = 5;

    static protected GameManager s_instance;
    static public GameManager instance { get { return s_instance; } }

    private void Awake()
    {
        s_instance = this;
    }

    private void Start()
    {
        m_playerUI.SetScore(m_score);
    }

    public void PlayerHit()
    {
        m_score--;
        m_playerUI.SetScore(m_score);
    }
}
