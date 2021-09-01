using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBackButton : MonoBehaviour
{
    public GameObject tutorial;

    public void onClickBack()
    {
        tutorial.SetActive(false);
    }
}
