using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDemo : MonoBehaviour 
{
	public LineFactory lineDraw;

	private Vector2 start;
	private Line drawnLine;

	void Update () 
	{
		if (Input.GetMouseButtonDown (0)) {
			var pos = Camera.main.ScreenToWorldPoint (Input.mousePosition); // Start line drawing
			drawnLine = lineDraw.GetLine (pos, pos, 0.02f, Color.white);
		} else if (Input.GetMouseButtonUp (0)) {
			drawnLine = null; // End line drawing
		}

		if (drawnLine != null) {
			drawnLine.end = Camera.main.ScreenToWorldPoint (Input.mousePosition); // Update line end
		}
	}
}
