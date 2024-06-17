using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private float curPosZ;
    private float score;
    public TextMeshProUGUI scorText;
    public TextMeshProUGUI coinText;

    public ObjectPool objectPool { get; private set; }
    public ParticleSystem EffectParticle;

    public bool gameOver;
    public GameObject gameOverUI;

    private void Awake()
    {
        gameOver = false;
        objectPool = GetComponent<ObjectPool>();
        if (instance != null) Destroy(gameObject);
        instance = this;
        EffectParticle = GameObject.FindGameObjectWithTag("Particle").GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (gameOver)
        {
            Cursor.lockState = CursorLockMode.None;
            gameOverUI.SetActive(true);
            Invoke("GameOver", 0.5f);
        }
        curPosZ = PlayerManager.Instance.Player.transform.position.z;
        if(score <= curPosZ) score = curPosZ;
        scorText.text = $"{Mathf.Floor(score)}";
        coinText.text = $"{PlayerManager.Instance.Player.coin}";
    }

    void GameOver()
    {
        Time.timeScale = 0f;
    }
}
