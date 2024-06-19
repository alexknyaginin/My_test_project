using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
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
    public Texture Image;
}

public class GameController : MonoBehaviour
{
    [SerializeField] private MenuController menuController;
    [SerializeField] private TMP_Text _qText;
    [SerializeField] private RawImage _imgTexture;
    [Header("Answers")]
    [SerializeField] private Button[] _ansButtons;
    private TMP_Text[] _ansButtonsText;
    private bool makeMistake = false;
    private string _qTextmakeMistake;

    [Header("tips")]
    [SerializeField] private Button _tipOne;
    [SerializeField] private Button _tipTwo;
    [SerializeField] private Button _tipThree;
    [Range(0, 100)][SerializeField] private byte _callPercent = 100;

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
        _imgTexture.texture = currentQuestions.Image;
        for (var i = 0; i < _ansButtons.Length; i++)
        {
            var text = currentQuestions.Answers[i];
            switch (i)
            {
                case 0:
                    text = $"{text}";
                    break;
                case 1:
                    text = $"{text}";
                    break;
                case 2:
                    text = $"{text}";
                    break;
                case 3:
                    text = $"{text}";
                    break;
            }
            _ansButtonsText[i].text = text;
            _ansButtons[i].gameObject.SetActive(true);
        }
    }
     private void OnButtonClick(byte index)
    {
        var correctIndex = _questions[_currentIndex].CorrectIndex;
        if(index == correctIndex)
        {
            _currentIndex++;
            if (_currentIndex >= _questions.Length)
            {
                menuController.ShowWin();
            }
            else
            {
                SetQuestion();
                makeMistake = false;
            }
        }
        else
        {
            if (makeMistake)
            {
                _qText.text = $"Попробуйте еще раз \n {_qTextmakeMistake}";
                _ansButtons[index].gameObject.SetActive(false);
                makeMistake = false;
            }
            else
            {
                menuController.ShowLoose();
            }
        }
    }

    private int GetRandomInt(int left, int right)
    {
        var ms = DateTime.Now.Millisecond;
        var rand = new System.Random(ms);
        return rand.Next(left, right);
    }
    private void Start()
    {
        SetQuestion();
        menuController.ShowGame();
        for(byte i = 0; i < _ansButtons.Length; i++)
        {
            var index = i;
            _ansButtons[i].onClick.AddListener(() => OnButtonClick(index));
        }
        _tipOne.onClick.AddListener(() => 
        {
            var buttonsList = new List<Button>();

            var correctIndex = _questions[_currentIndex].CorrectIndex;
            for (var i = 0; i < _ansButtons.Length; i++)
            {
                if (i == correctIndex)
                {
                    continue;
                }
                buttonsList.Add(_ansButtons[i]);
            }
            var randomNumber = GetRandomInt(0, buttonsList.Count);
            buttonsList.Remove(buttonsList[randomNumber]);
            buttonsList.ForEach((action) => action.gameObject.SetActive(false));
            _tipOne.enabled = false;
        });
        _tipTwo.onClick.AddListener(() => 
        {
            var currentQuestions = _questions[_currentIndex];
            var correctIndex = _questions[_currentIndex].CorrectIndex;
<<<<<<< Updated upstream
            var answerStr = currentQuestions.Answers[correctIndex];                    
            /*switch (answerInt)
=======
<<<<<<< Updated upstream
            var answerInt = randomNumber <= _callPercent? correctIndex : GetRandomInt(0, 3);
            var answerStr = "";
            switch (answerInt)
>>>>>>> Stashed changes
            {
                case 0 : answerStr = "A";
                    break;
                case 1 : answerStr = "B";
                    break;
                case 2 : answerStr = "C";
                    break;
                case 3 : answerStr = "D";
                    break;
<<<<<<< Updated upstream
            }*/
            _qText.text = $"Правильный ответ: {answerStr}";
=======
            }
            _qText.text = $"Думаю это {answerStr}";
=======
            var answerStr = currentQuestions.Answers[correctIndex];                    
            _qText.text = $"Правильный ответ: {answerStr}";
>>>>>>> Stashed changes
>>>>>>> Stashed changes
            _tipTwo.enabled = false;
        });
        _tipThree.onClick.AddListener(() => 
        {
            _qTextmakeMistake = _qText.text;
            _qText.text = $"Вы использовали право на ошибку";
            makeMistake = true;
            _tipThree.enabled = false;
        });
    }
}
