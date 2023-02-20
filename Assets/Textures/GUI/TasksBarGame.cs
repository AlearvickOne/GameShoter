using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TasksBarGame : MonoBehaviour
{
    [SerializeField] TMP_Text[] _tasksText;

    private void Update()
    {
        TasksTextVisibleLevel();
    }

    void TasksTextVisibleLevel()
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 1:
                bool FindComplex = false;
                TaskCheck(FindComplex, 0, "Find the entrance to the complex");
                break;
            case 2:
                if (SaveParametersObjects._transformatorIsLight == false)
                    TaskCheck(SaveParametersObjects._transformatorIsLight, 0, "Turn on the light");
                else if(SaveParametersObjects._transformatorIsLight == true)
                {
                    TaskCheck(SaveParametersObjects._greenKey, 0, "Find Green Card");
                    TaskCheck(SaveParametersObjects._redKey, 1, "Find Red Card");
                    TaskCheck(SaveParametersObjects._blueKey, 2, "Find Blue Card");
                    TaskCheck(SaveParametersObjects._protivogas, 3, "Find Protivogas");
                }
                break;
        }

    }

    void TaskCheck(bool taskCondition,int taskNomber, string taskName)
    {
        if(taskCondition == false)
            _tasksText[taskNomber].text = $"{(taskNomber + 1)}. {taskName}";
        else if(taskCondition == true)
            _tasksText[taskNomber].color = Color.black;
    }
}
