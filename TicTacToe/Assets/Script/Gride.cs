using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class Gride : MonoBehaviour
{
	// Start is called before the first frame update
	//public Checkerboard Checkerboard;
	public PieceType curPieceType;

	public Sprite XSprite;
	public Sprite OSprite;
	public Sprite EmptySprite;
	public GameObject GrideEdge;

	SpriteRenderer SpriteRenderer;

	public int PosX;
	public int PosY;
	public int Idx;

	void Start()
	{
		curPieceType = PieceType.Empty;
		SpriteRenderer = GetComponent<SpriteRenderer>();
        updatePieceType(curPieceType);
        GrideEdge.SetActive(false);
    }

	// Update is called once per frame
	void Update()
	{

	}

    public void resetGride()
    {
		setPieceType(PieceType.Empty);
        
    }

    public void setPieceType(PieceType pieceType)
	{
		this.curPieceType = pieceType;
        updatePieceType(pieceType);

    }

	public void updatePieceType(PieceType pieceTyp)
	{
		if(pieceTyp==PieceType.O)
        {
			SpriteRenderer.sprite = OSprite;

		}
		else if(pieceTyp==PieceType.X)
		{
			SpriteRenderer.sprite = XSprite;
		}
		else
		{
			SpriteRenderer.sprite = EmptySprite;
		}
    }

	public void onPoint()
	{
		GrideEdge.SetActive(true);
	}

	public void onExit()
	{
        GrideEdge.SetActive(false);
    }
	public void onClick()
	{
		PieceType pieceTyp = getCurClickPieceType();
		if(curPieceType!=PieceType.Empty)
			return;
        setPieceType(pieceTyp);
        Checkerboard.Instance.grides[Idx] = pieceTyp;
        GameManager.Instance.nextRound();
    }

	public PieceType getCurClickPieceType()
	{
		Player curPlayer = GameManager.Instance.RoundMgr.getCntPlayer();
		if(curPlayer==Player.P1)
		{
			return PieceType.O;
		}
		else if(curPlayer==Player.P2)
		{
			return PieceType.X;
		}
		else
		{
			return PieceType.Empty;
		}
    }
}
