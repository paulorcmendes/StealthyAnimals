using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerSmooth : MovePlayer
{
    public float speed = 5;
    protected override void Move()
    {
        
        if (gameStatePlayer.MyState == State.escaping)
        {
            Vector2 translation_left = Vector2.zero;
            Vector2 translation_right = Vector2.zero;
            Vector2 translation_up = Vector2.zero;
            Vector2 translation_down = Vector2.zero;
            if (Input.GetKey("a"))
            {
                translation_left = new Vector2(-1.0f, 0.0f);
            }
            if (Input.GetKey("d"))
            {
                translation_right = new Vector2(1.0f, 0.0f);
            }
            if (Input.GetKey("s"))
            {
                translation_down = new Vector2(0.0f, -1.0f);
            }
            if (Input.GetKey("w"))
            {
                translation_up = new Vector2(0.0f, 1.0f);
            }
            Vector3 translation = (translation_left+translation_right+translation_up+translation_down).normalized;
            if (CanMove(transform.position + translation))
            {
                //currentPosition += translation;
                transform.Translate(translation*Time.deltaTime*speed);
                haveIWon();
            }
        }
    }
}
