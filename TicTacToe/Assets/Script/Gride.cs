using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class Gride : MonoBehaviour
{
	// Start is called before the first frame update
	public Checkerboard Checkerboard;
	public PieceType pieceType;

	public Sprite XSprite;
	public Sprite OSprite;
	public Sprite EmptySprite;
	public GameObject GrideEdge;

	SpriteRenderer SpriteRenderer;

	public int PosX;
	public int PosY;

	void Start()
	{
		pieceType = PieceType.Empty;
		SpriteRenderer = GetComponent<SpriteRenderer>();
        updatePieceType(pieceType);
        GrideEdge.SetActive(false);
    }

	// Update is called once per frame
	void Update()
	{

	}

	public void setPieceType(PieceType pieceType)
	{
		this.pieceType = pieceType;
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
        setPieceType(PieceType.X);

    }
}
