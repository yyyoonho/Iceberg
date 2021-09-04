using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBackButton : MonoBehaviour
{
    public GameObject tutorial;

    //튜토리얼 화면에서 Back버튼을 클릭 시 튜토리얼 화면이 종료됩니다.
    public void onClickBack()
    {
        tutorial.SetActive(false);
    }
}
