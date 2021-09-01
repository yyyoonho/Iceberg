using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialButton : MonoBehaviour
{
    public GameObject tutorial;

    public void onClickTutorial()
    {
        tutorial.SetActive(true);
    }
}
