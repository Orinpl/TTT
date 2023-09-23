using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class AI : MonoBehaviour
{
    // Start is called before the first frame update

    public static AI Instance;

    void Start()
    {
        if(Instance!=null)
        {
            Destroy(Instance);
        }
        Instance = this;

    }

    public int getNextPoint()
    {
        List<PieceType> grides = new List<PieceType>();
        foreach(PieceType pieceType in GameManager.Instance.Checkerboard.grides)
        {
            grides.Add(pieceType);
        }

        // 极小化极大算法
        int bestScore = int.MinValue;
        int bestMove = -1;
        for (int i = 0; i < grides.Count; i++)
        {
            if (grides[i] == PieceType.Empty)
            {
                grides[i] = PieceType.O;
                int score = Minimax(grides, 0, false, int.MinValue, int.MaxValue);
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
    private int Minimax(List<PieceType> grides, int depth, bool isMaximizingPlayer, int alpha, int beta)
    {
        PieceType winner = Checkerboard.Instance.checkWin();
        if (winner != PieceType.Empty)
        {
            return (winner == PieceType.O) ? 1 : -1;
        }

        if (GameManager.Instance.isDraw)
        {
            return 0;
        }

        if (isMaximizingPlayer)
        {
            int bestScore = int.MinValue;
            for (int i = 0; i < grides.Count; i++)
            {
                if (grides[i] == PieceType.Empty)
                {
                    grides[i] = PieceType.O;
                    int score = Minimax(grides, depth + 1, false, alpha, beta);
                    grides[i] = PieceType.Empty;
                    bestScore = Mathf.Max(bestScore, score);
                    alpha = Mathf.Max(alpha, score);
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
            for (int i = 0; i < grides.Count; i++)
            {
                if (grides[i] == PieceType.Empty)
                {
                    grides[i] = PieceType.X;
                    int score = Minimax(grides, depth + 1, true, alpha, beta);
                    grides[i] = PieceType.Empty;
                    bestScore = Mathf.Min(bestScore, score);
                    beta = Mathf.Min(beta, score);
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
