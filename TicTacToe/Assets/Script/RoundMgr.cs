using System.Collections;
using System.Collections.Generic;
using Utility;

public class RoundMgr
{
    public int roundCnt { get; private set; }
    public Player playerCnt { get ; private set; }

    public RoundMgr()
    {
        resetRound();
    }

    public void resetRound()
    {
        roundCnt = 0;
        playerCnt = Player.P1;
    }

    public void nextRound()
    {
        roundCnt++;
        playerCnt = getNextPlayer(playerCnt);

    }

    public Player getNextPlayer(Player cntPlayer)
    {
        if (cntPlayer == Player.P1) 
        {
            return Player.P2;
        }
        else
        {
            return Player.P1;
        }
    }

    public Player getCntPlayer()
    {
        return playerCnt;
    }

    public int getCntRound()
    {
        return roundCnt;
    }

}
