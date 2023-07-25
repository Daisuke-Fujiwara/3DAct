using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public void StartGame()
    {
        Initiate.Fade("GameScene", Color.black, 1.0f);
    }

    public void ExitGame()
    {
       Application.Quit();//ゲームプレイ終了
    }
}
