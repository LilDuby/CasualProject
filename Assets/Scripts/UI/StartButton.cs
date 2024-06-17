using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{

    public GameObject scoreUI;
    public GameObject coinUI;
    private void Awake()
    {
        Time.timeScale = 0f;
    }

    public void OnStart()
    {
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
        this.gameObject.SetActive(false);
        scoreUI.SetActive(true);
        coinUI.SetActive(true);
    }

    public void OnReStart()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("mainScene");
    }
}
