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
        quizModel.GetQuestionEvent += QuizModel_OnChange;
    }

    private void QuizModel_OnChange(QuizData quizData)
    {
        quizView.UpdateNextQuestion(quizData);
    }


    #endregion

    #region  |  Mehtods  [ Public ]  |

    public void GetNextQuestion()
    {
        quizModel.GetNextQuestion();
    }
  


    #endregion

    #region  |  Mehtods  [ Private ]  |

    #endregion
}
