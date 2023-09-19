using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkerboard : MonoBehaviour
{
	public static Checkerboard Instance;
	public List<Grid> grids;
	void Start()
	{
		if (Instance != null)
		{
			Destroy(this);
		}
		Instance = this;

	}

	// Update is called once per frame
	void Update()
	{

	}
}
