using UnityEngine;
using System.Collections;

public class CircleGuardScript : LGuardScript
{
	protected override void OnEnded(){
		if (curX == 0 && curY == 0) {
			xMov *= -1;
			yMov *= -1;
			AdjustIncrements ();
		}
	}
}

