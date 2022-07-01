using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStartScreen : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _aboutButton;
    [SerializeField] private CanvasGroup _imageInfo;

    private CanvasGroup _startGameGroup;

    private void OnEnable()
    {
        _startButton.onClick.AddListener(OnStartButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
        _aboutButton.onClick.AddListener(OnAboutButtonClick);
    }


    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(OnStartButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
        _aboutButton.onClick.RemoveListener(OnAboutButtonClick);
    }

    private void Start()
    {
        _startGameGroup = GetComponent<CanvasGroup>();
        Time.timeScale = 0f;
        _startGameGroup.alpha = 1.0f;

    }

    private void OnStartButtonClick()
    {
        Debug.Log("Start button click");
        Time.timeScale = 1.0f;
        _startGameGroup.gameObject.SetActive(false);
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
    }
    private void OnAboutButtonClick()
    {
        if (_imageInfo.alpha == 0f)
            _imageInfo.alpha = 1.0f;
        else
            _imageInfo.alpha = 0f;
    }

}
