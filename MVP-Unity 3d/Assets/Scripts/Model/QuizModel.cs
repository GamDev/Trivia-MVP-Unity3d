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
    public event Action<QuizData> GetQuestionEvent;
    // This Event is for questionAnswer. e.g whenever user choose any option this event will be called to update the totalcorrect
    public event Action<int> questionAnswerEvent;
    int totalCorrect;
    int currentQuestion;
    #endregion

    #region  |  Mehtods  [ Call Backs ]  |

    #endregion

    #region  |  Mehtods  [ Public ]  |

    public void Awake()
    {
        totalCorrect = 0;
        currentQuestion = 0;
    }

    public void GetNextQuestion()
    {
        GetQuestionEvent?.Invoke(quizDatas[currentQuestion]);
        currentQuestion++;
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