using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class AI : MonoBehaviour
{
    // Start is called before the first frame update

    public static AI Instance;

    public Player AIPlayer;

    public PieceType AIPieceType { get { return AIPlayer == Player.P1 ? PieceType.O : PieceType.X; } }
    public PieceType PlayerPieceType { get { return AIPlayer == Player.P1 ? PieceType.X : PieceType.O; } }

    void Start()
    {
        if(Instance!=null)
        {
            Destroy(Instance);
        }
        Instance = this;
        AIPlayer = Player.P2;
    }

    public int getNextPoint()
    {

        PieceType[] grides = Checkerboard.Instance.grides.ToArray();

        // 极小化极大算法
        int bestScore = int.MinValue;
        int bestMove = -1;
        for (int i = 0; i < grides.Length; i++)
        {
            if (grides[i] == PieceType.Empty)
            {
                grides[i] = AIPieceType;
                int alpha = int.MinValue;
                int beta = int.MaxValue;
                int score = Minimax(grides, 0, PlayerPieceType, alpha, beta);
                //print("idx:"+i+" score:"+score);
                grides[i] = PieceType.Empty;
                if (score > bestScore)
                {
                    bestScore = score;
                    bestMove = i;
                }
            }
        }

        return bestMove;
    }

    // 极小化极大算法
    private int Minimax(PieceType[] grides, int depth, PieceType aiWinType, int alpha, int beta)
    {
        PieceType winner = Checkerboard.Instance.checkWin(grides);
        if (winner != PieceType.Empty)
        {
            return (winner == AIPieceType) ? 1 : -1;
        }

        bool isFull = Checkerboard.Instance.isFull(grides);
        if (isFull&&winner == PieceType.Empty)
        {
            return 0;
        }

        if (aiWinType == AIPieceType)
        {
            int bestScore = int.MinValue;
            for (int i = 0; i < grides.Length; i++)
            {
                if (grides[i] == PieceType.Empty)
                {
                    grides[i] = AIPieceType;
                    int score = Minimax(grides, depth + 1, PlayerPieceType, alpha, beta);
                    grides[i] = PieceType.Empty;
                    bestScore = Mathf.Max(bestScore, score);
                    alpha = Mathf.Max(alpha, score);
                    //剪枝
                    if (beta <= alpha)
                    {
                        break;
                    }
                }
            }
            return bestScore;
        }
        else
        {
            int bestScore = int.MaxValue;
            for (int i = 0; i < grides.Length; i++)
            {
                if (grides[i] == PieceType.Empty)
                {
                    grides[i] = PlayerPieceType; 
                    int score = Minimax(grides, depth + 1, AIPieceType, alpha, beta);
                    grides[i] = PieceType.Empty;
                    bestScore = Mathf.Min(bestScore, score);
                    beta = Mathf.Min(beta, score);
                    //剪枝
                    if (beta <= alpha)
                    {
                        break;
                    }
                }
            }
            return bestScore;
        }


    }
}
