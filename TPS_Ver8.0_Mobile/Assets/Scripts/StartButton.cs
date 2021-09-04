using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{   
    //씬 매니저에서 게임씬을 로드합니다.
    public void ChangeToGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
