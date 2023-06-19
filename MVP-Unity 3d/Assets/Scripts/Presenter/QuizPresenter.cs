using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizPresenter : MonoBehaviour
{
    #region |  [ Fields ] |

    public QuizModel quizModel;
    public QuizView quizView;
    #endregion

    #region  |  Mehtods  [ Call Backs ]  |


    void Start()
    {
        quizModel.getNextQuestionEvent += QuizModel_OnNextQuestion;
        quizModel.totalQuestionEvent += QuizModel_totalQuestionEvent;
    }

    private void QuizModel_totalQuestionEvent(int totalQuestion)
    {
        quizView.UpdateQuestionCount(totalQuestion);
    }

    private void QuizModel_OnNextQuestion(QuizData quizData)
    {
        quizView.UpdateNextQuestion(quizData);
    }


    #endregion

    #region  |  Mehtods  [ Public ]  |

    public void GetNextQuestion(int qestionNo)
    {
        quizModel.GetNextQuestion(qestionNo);
    }

    public void GetTotalQuestions()
    {
        quizModel.GetTotalQuestions();
    }


    #endregion

    #region  |  Mehtods  [ Private ]  |

    #endregion
}
