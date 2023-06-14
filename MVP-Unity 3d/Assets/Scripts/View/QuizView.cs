using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class QuizView : MonoBehaviour
{
    public Text questionTxt;
    public Text[] optionsTxt;
    public List<Transform> optionsTransforms = new List<Transform>();
    public QuizPresenter presenter;
    QuizData quizData;

    void Start()
    {
        DisplayQuestionUI();
        presenter.GetNextQuestion();
    }


    public void UpdateNextQuestion(QuizData quizData)
    {
        this.quizData = quizData;
        questionTxt.text = quizData.Question;
        int i = 0;
        foreach (string optionStr in quizData.multipleOptions)
        {
            optionsTxt[i].text = optionStr;
            i++;
        }
    }

    public void DisplayQuestionUI()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(questionTxt.transform.parent.transform.DOMoveX(0f, 0.5f).From(-1000f).SetEase(Ease.InSine))
           .PrependInterval(.5f)
           .Append(optionsTransforms[0].DOScale(1, 0.3f).From(0f).SetEase(Ease.OutBack))
           .Append(optionsTransforms[1].DOScale(1, 0.3f).From(0f).SetEase(Ease.OutBack))
           .Append(optionsTransforms[2].DOScale(1, 0.3f).From(0f).SetEase(Ease.OutBack))
           .Append(optionsTransforms[3].DOScale(1, 0.3f).From(0f).SetEase(Ease.OutBack));
    }

    public void OnOptionButtonClicked(int optNo)
    {
        if (this.quizData.correctAnswer == optNo)
        {
            Debug.Log(" Correct Question");
        }
        else
        {
            Debug.Log(" False");
        }
    }
}
