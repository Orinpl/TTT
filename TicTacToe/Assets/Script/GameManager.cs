using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int PlayNum = 0;

    public Player playerCnt;

    public Player winner;

    public Mode Mode;

    public Checkerboard Checkerboard;

    public RoundMgr RoundMgr;

    public bool isWin;

    public bool isDraw;

    void Start()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }
        Instance = this;
        RoundMgr = new RoundMgr();
        winner = Player.None;
        playerCnt = Player.None;

        isWin = false;
        isDraw = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            print("wait to restart...");
            resetGame();
        }
    }

    public void startGame(Mode mode)
    {
        if(mode == Mode.VS)
        {
            RoundMgr.resetRound();
            playerCnt = RoundMgr.getCntPlayer();

        }
    }

    public void resetGame()
    {
        RoundMgr.resetRound();
        Checkerboard.resetGrides();
        isWin = false;
        isDraw = false;
        winner = Player.None;
    }

    public void exitGame()
    {

    }

    public void winGame(Player player)
    {
        isWin = true;
        isDraw = false;
        Debug.Log(player + "win!");
    }

    public void drawGame()
    {
        isDraw = true;
        isWin = false;
        Debug.Log("ºÍ¾Ö£¡");
    }

    public bool checkWin()
    {
        print("check win...");
        PieceType pieceType = Checkerboard.checkWin();
        if(pieceType == PieceType.O)
        {
            winGame(Player.P1);
            return true;
        }
        else if(pieceType == PieceType.X)
        {
            winGame(Player.P2);
            return true;
        }
        else
        {
            if(Checkerboard.isFull())
            {
                drawGame();
            }
            return false;
        }

    }

    public void nextRound()
    {
        checkWin();
        if (isWin)
        {
            //waitToRestart();
        }
        else if(isDraw)
        {
            //waitToRestart();
        }
        else
        {
            RoundMgr.nextRound();
            Debug.Log("Player:" + RoundMgr.getCntPlayer());
        }
    }

    //IEnumerator waitToRestart()
    //{
    //    yield return new WaitForSeconds(2);
    //}

    public void restartGame()
    {

    }
}
