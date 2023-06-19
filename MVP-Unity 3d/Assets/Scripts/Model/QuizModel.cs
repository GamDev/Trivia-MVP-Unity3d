using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuizModel", menuName = "Game Dev/Quiz Model")]
public class QuizModel : ScriptableObject
{
    #region |  [ Fields ] |

    // This list contains all the questions with multiple options
    public List<QuizData> quizDatas = new List<QuizData>();
    // This event for Geting new Question. 
    public event Action<QuizData> getNextQuestionEvent;
    public event Action<int> totalQuestionEvent;

    #endregion

    #region  |  Mehtods  [ Call Backs ]  |

    #endregion

    #region  |  Mehtods  [ Public ]  |


    public void GetNextQuestion(int nextQ)
    {
        getNextQuestionEvent?.Invoke(quizDatas[nextQ]);
    }

    public void GetTotalQuestions()
    {
        totalQuestionEvent?.Invoke(quizDatas.Count);
    }

    #endregion

    #region  |  Mehtods  [ Private ]  |

    #endregion
}

[Serializable]
public class QuizData
{
    public string Question;
    public List<string> multipleOptions = new List<string>();
    public int correctAnswer;
   
}