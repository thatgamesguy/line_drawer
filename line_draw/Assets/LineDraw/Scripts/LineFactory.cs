using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineFactory : MonoBehaviour
{
	public GameObject linePrefab;

	public int numToPool = 50;

	private Line[] pooledLines;
	private int currentIndex = 0;

	void Start ()
	{
		pooledLines = new Line[numToPool];
		
		for (int i = 0; i < numToPool; i++) {
			var line = Instantiate (linePrefab);
			line.SetActive (false);
			line.transform.SetParent (transform);
			pooledLines[i] = line.GetComponent<Line> ();
		}
	}

	public Line GetLine (Vector2 start, Vector2 end, float width, Color color)
	{
		var line = pooledLines [currentIndex];
		
		line.Initialise (start, end, width, color);
		line.gameObject.SetActive (true);

		currentIndex = (currentIndex + 1) % pooledLines.Length;

		return line;

	}

}
