using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour {

	public bool[,] edges;
	public Vector2[,] nodes;
	public int ySize;
	public int xSize;
	public Vector2 firstNodePos;
	public int offset;
	public GameObject grids;
	public GameObject gridPrefab;

	// Use this for initialization
	void Start () {

		offset = 2;

		xSize = 10;
		ySize = 6;

		nodes = new Vector2[xSize, ySize];
		edges = new bool[xSize, ySize];

		firstNodePos = new Vector2 (-10, 4);

		grids = new GameObject ();
		Vector3 gridsPos = grids.transform.position;
		gridsPos.z = 10;
		grids.transform.position = gridsPos;

		// Mock Stage, it should take information from Stage object
		for (int i = 0; i < xSize; i++) {
			for (int j = 0; j < ySize; j++) {
				nodes [i,j] = new Vector2 (firstNodePos.x + i * offset, firstNodePos.y - j * offset);
				if (gridPrefab) {
					var grid = Instantiate (gridPrefab, grids.transform);
					grid.transform.localPosition = nodes [i, j];
				} else {
					Debug.LogError("No grid prefab found");
				}
				Debug.Log (nodes [i, j].ToString ());
				edges [i, j] = true;
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
