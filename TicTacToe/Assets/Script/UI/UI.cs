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
        string info = "�� " + roundNum + "�غ�";
        RoundInfo.GetComponent<Text>().text = info;
    }

    public void setPlayerInfo(Player player)
    {
        string info = "";
        if (player != Player.None)
        {
            info = player + "����";
        }
        PlayerInfo.GetComponent<Text>().text = info;
    }

    public void setWinInfo(Player player, bool isGaming)
    {
        string info = "";
        switch (player)
        {
            case Player.P1:
                info = "P1��ʤ!";
                break;
            case Player.P2:
                info = "P2��ʤ��";
                break;
            case Player.None:
                info = isGaming ? "��Ϸ��" : "�;�!";
                break;
            default:
                break;
        }
        WinInfo.GetComponent<Text>().text = info;
    }

    public void setModeInfo(Mode mode)
    {
        string info = mode == Mode.VS ? "��սģʽ" : "AIģʽ";
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
