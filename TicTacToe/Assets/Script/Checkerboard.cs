using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class Checkerboard : MonoBehaviour
{
	public static Checkerboard Instance;
	public List<PieceType> grides;
    public List<Gride> checkerboardGrides;
	void Start()
	{
		if (Instance != null)
		{
			Destroy(this);
		}
		Instance = this;
        grides = new List<PieceType> ();
        //resetGrides();
        for(int i = 0; i < 9; i++)
        {
            grides.Add (PieceType.Empty);
            checkerboardGrides[i].Idx = i;
        }
    }

	public void resetGrides()
	{
		grides.Clear();
        foreach(Gride gride in checkerboardGrides)
        {
            gride.resetGride();
            grides.Add(PieceType.Empty);
        }
    }

	// Update is called once per frame
	void Update()
	{

	}

	public void registerGrides(Gride gride)
	{
        checkerboardGrides.Add(gride);

    }

    //public void resetCheckerboard()
    //{
    //    foreach (Gride gride in checkerboardGrides)
    //    {

    //    }
    //}

    public PieceType checkWin()
    {
        // 检查行
        for (int i = 0; i < 7; i += 3)
        {
            if (grides[i] != PieceType.Empty && grides[i] == grides[i + 1] && grides[i] == grides[i + 2])
            {
                return grides[i];
            }
        }

        // 检查列
        for (int i = 0; i < 3; i++)
        {
            if (grides[i] != PieceType.Empty && grides[i] == grides[i + 3] && grides[i] == grides[i + 6])
            {
                return grides[i];
            }
        }

        // 检查对角线
        if (grides[0] != PieceType.Empty && grides[0] == grides[4] && grides[0] == grides[8])
        {
            return grides[0];
        }
        if (grides[2] != PieceType.Empty && grides[2] == grides[4] && grides[2] == grides[6])
        {
            return grides[2];
        }

        // 没有胜利者
        return PieceType.Empty;
    }

    public bool isFull()
    {
        foreach(var gride in grides) 
        {
            if(gride == PieceType.Empty)
            {
                return false;
            }
        }
        return true;
    }

}
