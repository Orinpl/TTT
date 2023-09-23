using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utility;

public class UI : MonoBehaviour
{
    public GameObject RoundInfo;
    public GameObject PlayerInfo;
    public GameObject WinInfo;
    public Button VSMode;
    public Button AIMode;
    public Button Restart;
    public Button Exit;
    public GameObject ModeInfo;

    void Start()
    {
        VSMode.onClick.AddListener(setVSMode);
        AIMode.onClick.AddListener(setAIMode);
        Restart.onClick.AddListener(restartGame);
        Exit.onClick.AddListener(exitGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setRoundInfo(int roundNum)
    {
        string info = "第 " + roundNum + "回合";
        RoundInfo.GetComponent<Text>().text = info;
    }

    public void setPlayerInfo(Player player)
    {
        string info = "";
        if (player != Player.None)
        {
            info = player + "落子";
        }
        PlayerInfo.GetComponent<Text>().text = info;
    }

    public void setWinInfo(Player player, bool isGaming)
    {
        string info = "";
        switch (player)
        {
            case Player.P1:
                info = "P1获胜!";
                break;
            case Player.P2:
                info = "P2获胜！";
                break;
            case Player.None:
                info = isGaming ? "游戏中" : "和局!";
                break;
            default:
                break;
        }
        WinInfo.GetComponent<Text>().text = info;
    }

    public void setModeInfo(Mode mode)
    {
        string info = mode == Mode.VS ? "对战模式" : "AI模式";
        ModeInfo.GetComponent<Text>().text = info;
    }

    public void setVSMode()
    {
        GameManager.Instance.changeMode(Mode.VS);
        GameManager.Instance.resetGame();
    }

    public void setAIMode()
    {
        GameManager.Instance.changeMode(Mode.Single);
        GameManager.Instance.resetGame();
    }

    public void restartGame()
    {
        GameManager.Instance.resetGame();
        GameManager.Instance.resetGame();
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
