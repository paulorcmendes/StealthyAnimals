using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LGuardScript : GuardMovement{
	private Vector2 vecIncr;
	protected override void Move ()
	{
		OnEnded ();
		vecIncr = Vector2.zero;
		if (yFirst) {
			if (!MoveY ())
				MoveX ();
		} else {
			if (!MoveX ())
				MoveY ();
		}
		transform.position = currentPosition + offset;
	}
	protected override bool MoveX ()
	{
		if (curX != 0) {
			vecIncr = new Vector2 ((float)-xIncr, 0f);
			if (CanMove (currentPosition + vecIncr)) {
				curX += xIncr;
				currentPosition += vecIncr;
			} else {
				xMov -= curX;
				curX = 0;
				return false;
			}
			return true;
		}
		return false;
	}
	protected override bool MoveY (){
		if (curY != 0) {
			vecIncr = new Vector2 (0f, (float)-yIncr);
			if (CanMove (currentPosition + vecIncr)) {
				curY += yIncr;
				currentPosition += vecIncr;
			} else {
				yMov -= curY;
				curY = 0;
				return false;
			}
			return true;
		}
		return false;
	}
	protected virtual void OnEnded(){
		if (curX == 0 && curY == 0) {
			xMov *= -1;
			yMov *= -1;
			yFirst = !yFirst;
			AdjustIncrements ();
		}
	}
}
