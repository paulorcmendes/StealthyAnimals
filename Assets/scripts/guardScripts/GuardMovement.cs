using UnityEngine;
using System.Collections;

public abstract class GuardMovement : MatrixMovement
{
	public int xMov;
	public int yMov;
	public bool yFirst;
	public float timeDelay;

	private float lastMov = 0f;
	protected int xIncr;
	protected int yIncr;
	protected int curX;
	protected int curY;

	// Use this for initialization
	protected override void ChildStart()
	{
		AdjustIncrements ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		UpdatePosition ();
	}
	void UpdatePosition(){
		float currentTime = Time.time;
		if (currentTime > lastMov + timeDelay) {
			lastMov = currentTime;
			Move ();
		}
	}

	protected void AdjustIncrements(){
		curX = xMov;
		curY = yMov;
		if (xMov > 0) {
			xIncr = -1;
		} else {
			xIncr = 1;
		}
		if (yMov > 0) {
			yIncr = -1;
		}else{
			yIncr = 1;
		}
	}
	protected abstract void Move();
	protected abstract bool MoveX();
	protected abstract bool MoveY();
}