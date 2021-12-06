using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeManager : MonoBehaviour
{
    [SerializeField] Button playButton;

    private void Awake()
    {
        playButton.onClick.AddListener(OnPlayButton);
    }

    void OnPlayButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
    }
}
