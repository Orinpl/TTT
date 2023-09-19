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

	SpriteRenderer SpriteRenderer;

	public int PosX;
	public int PosY;

	void Start()
	{
		pieceType = Utility.PieceType.Empty;
		SpriteRenderer = GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void setPieceType(PieceType pieceType)
	{
		this.pieceType = pieceType;
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
	}
}
