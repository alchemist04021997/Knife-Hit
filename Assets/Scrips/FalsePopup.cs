using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FalsePopup : MonoBehaviour
{
    [SerializeField] Button restartButton, backButton, continueButton;
    private void Awake()
    {
        restartButton.onClick.AddListener(RestartButton);
        backButton.onClick.AddListener(BackButton);
        continueButton.onClick.AddListener(ContinueButton);
    }

    void RestartButton()
    {
        SystemManager.Instance.Stage = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
        gameObject.SetActive(false);
    }
    void BackButton()
    {
        SystemManager.Instance.Stage = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene("HomeScene");
        gameObject.SetActive(false);
    }
    void ContinueButton()
    {
        Action action = () =>
        {
            gameObject.SetActive(false);
            GameplayManager.Instance.OnContinue();
        };
        AdManager.ShowVideo(action, null, null);
    }
}
