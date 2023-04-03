using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{


    public bool isCanJudge = true;
    

    void Update()
    {

        if (transform.childCount==0)
        {
            if (isCanJudge)
            {
                isCanJudge = false;
                GameManager.Instance.JudgeWinOrLose();
            }
            

        }

    }



}
