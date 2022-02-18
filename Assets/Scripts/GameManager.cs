using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private PlayerUI m_playerUI;

    [Header("Score")]
    [SerializeField] private int m_maxScore = 5;

    [Header("Player")]
    [SerializeField] private Transform m_playerPrefab;
    [SerializeField] private Transform m_startPos;
    [SerializeField] private CinemachineVirtualCamera m_camera;

    private int m_score;
    private Transform m_player;

    static protected GameManager s_instance;
    static public GameManager instance { get { return s_instance; } }

    private void Awake()
    {
        s_instance = this;
    }

    private void Start()
    {
        StartLevel();
    }

    public void PlayerHit()
    {
        m_score--;
        m_playerUI.SetScore(m_score.ToString());

        if (m_score <= 0)
        {
            PlayerDied();
        }
    }

    public void PlayerDied()
    {
        Destroy(m_player.gameObject);
        StartLevel();
    }

    public void StartLevel()
    {
        m_score = m_maxScore;
        m_playerUI.SetScore(m_score.ToString());

        m_player = GameObject.Instantiate(m_playerPrefab, m_startPos.position, Quaternion.identity);

        m_camera.Follow = m_player;
    }

    public void LevelFinished()
    {
        m_playerUI.SetScore("YOU WON!");
    }
}
