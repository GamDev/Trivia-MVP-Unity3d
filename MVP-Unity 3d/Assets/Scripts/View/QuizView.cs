using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class QuizView : MonoBehaviour
{
    public Text questionTxt;
    public Text[] optionsTxt;
    public Sprite correctImage;
    public Sprite wrongImage;
    public Image[] resultImages;
    public List<Transform> optionsTransforms = new List<Transform>();
    public QuizPresenter presenter;
    QuizData quizData;
    int currentQuestionNo = 0;
    void Start()
    {
        DisplayQuestionUI();
        presenter.GetNextQuestion(currentQuestionNo);
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
    public void HideQuestionUI()
    {
        Sequence mySequence = DOTween.Sequence();

        mySequence.Append(optionsTransforms[3].DOScale(0, 0.3f).SetEase(Ease.OutBack))
           .Append(optionsTransforms[2].DOScale(0, 0.3f).SetEase(Ease.OutBack))
           .Append(optionsTransforms[1].DOScale(0, 0.3f).SetEase(Ease.OutBack))
           .Append(optionsTransforms[0].DOScale(0, 0.3f).SetEase(Ease.OutBack))
           .PrependInterval(.5f)
           .Append(questionTxt.transform.parent.transform.DOMoveX(-1000f, 0.5f).From(0f).SetEase(Ease.InSine));
        ReScaleResultImages();
        DOVirtual.DelayedCall(1.5f, DisplayNextQuestion);
    }

    public void OnOptionButtonClicked(int optNo)
    {
        if (this.quizData.correctAnswer == optNo)
        {
            resultImages[optNo].sprite = correctImage;
            resultImages[optNo].transform.DOScale(1f, 0.5f).SetEase(Ease.OutBack);
            Debug.Log(" Correct Question");
        }
        else
        {
            resultImages[optNo].sprite = wrongImage;
            resultImages[optNo].transform.DOScale(1f, 0.5f).SetEase(Ease.OutBack);
            resultImages[this.quizData.correctAnswer].sprite = correctImage;
            resultImages[this.quizData.correctAnswer].transform.DOScale(1f, 0.5f).SetEase(Ease.OutBack);

            Debug.Log(" False");
        }
        DOVirtual.DelayedCall(1.5f, HideQuestionUI);
        currentQuestionNo++;
    }
    public void DisplayNextQuestion()
    {
        DisplayQuestionUI();
        presenter.GetNextQuestion(currentQuestionNo);
    }
     public void ReScaleResultImages()
    {
        foreach(Image img in resultImages)
        {
            img.transform.DOScale(0f, 0f);
        }
    }
}
