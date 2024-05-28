using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class Question
{
    public string text;
    public string[] Answers;
    [Range(0, 3)]
    public byte CorrectIndex;
}

public class GameController : MonoBehaviour
{
    [SerializeField] private TMP_Text _qText;
    [Header("Answers")]
    [SerializeField] private Button[] _ansButtons;
    private TMP_Text[] _ansButtonsText;

    [Header("tips")]
    [SerializeField] private Button _tipOne;
    [SerializeField] private Button _tipTwo;
    [SerializeField] private Button _tipThree;

    [Header("Questions")]
    [SerializeField] private Question[] _questions;

    [Header("Test")]
    [SerializeField] private byte _currentIndex = 0;

    public void Awake()
    {
        var lenght = _ansButtons.Length;
        _ansButtonsText = new TMP_Text[lenght];
        for (int i = 0; i < lenght; i++)
        {
            _ansButtonsText[i] = _ansButtons[i].GetComponentInChildren<TMP_Text>();
        }
    }

    private void SetQuestion()
    {
        var currentQuestions = _questions[_currentIndex];
        _qText.text = currentQuestions.text;
        for (var i = 0; i < _ansButtons.Length; i++)
        {
            var text = currentQuestions.Answers[i];
            switch (i)
            {
                case 0:
                    text = $"A: {text}";
                    break;
                case 1:
                    text = $"B: {text}";
                    break;
                case 2:
                    text = $"C: {text}";
                    break;
                case 3:
                    text = $"D: {text}";
                    break;
            }
            _ansButtonsText[i].text = text;
        }
    }
    private void EndGame()
    {
        _qText.text = "END!!!";
        for (var i = 0; i < _ansButtons.Length; i++)
        {
            _ansButtons[i].gameObject.SetActive(false);
        }
        _tipOne.gameObject.SetActive(false);
        _tipTwo.GetComponentInChildren<TMP_Text>().text = "GO!!!";
        _tipThree.gameObject.SetActive(false);
        _tipTwo.onClick.RemoveAllListeners();
        _tipTwo.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().name));
    }
    private void OnButtonClick(byte index)
    {
        var correctIndex = _questions[_currentIndex].CorrectIndex;
        if(index == correctIndex)
        {
            _currentIndex++;
            if (_currentIndex >= _questions.Length)
            {
                EndGame();
            }
            else
            {
                SetQuestion();
            }
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    private void Start()
    {
        SetQuestion();

        for(byte i=0; i < _ansButtons.Length; i++)
        {
            var index = i;
            _ansButtons[i].onClick.AddListener(() => OnButtonClick(index));
        }
    }
}
