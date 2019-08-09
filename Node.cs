using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

	public Vector3 worldPosition;
	public bool walk;
	public int gridX;
	public int gridY;

	public Node(bool checkWalk, Vector3 WorldPos, int gridPosX, int gridPosY)
	{
		walk = checkWalk;
		worldPosition = WorldPos;
		gridX = gridPosX;
		gridY = gridPosY;

	}
}
