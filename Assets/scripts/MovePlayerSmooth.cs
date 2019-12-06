using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerSmooth : MovePlayer
{
    public float speed = 5;

    protected override void Move()
    {
        KeyBoardMove();
        //MouseMove();
        DragMove();
    }
    private void KeyBoardMove()
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
            Vector3 translation = (translation_left + translation_right + translation_up + translation_down).normalized * Time.deltaTime * speed;
            //Vector3 offset3 = offset;
            if (CanMove(transform.position + translation))
            {
                //currentPosition += translation;
                transform.Translate(translation);

                //haveIWon(transform.position);
            }
        }
    }
    private void MouseMove()
    {
        if (Input.GetMouseButton(0) && gameStatePlayer.MyState == State.escaping)
        {

            Vector3 translation = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized * Time.deltaTime * speed * 2;
            translation.z = 0f;
            if (CanMove(transform.position + translation))
            {
                //currentPosition += translation;
                transform.Translate(translation);

                //haveIWon(transform.position);
            }
            Debug.Log(translation);

        }
    }

    private void DragMove()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && gameStatePlayer.MyState == State.escaping)
        {
            // Get movement of the finger since last frame
            Vector3 translation = Input.GetTouch(0).deltaPosition.normalized * Time.deltaTime*speed;
            translation.z = 0f;
            // Move object across X plane
            if (CanMove(transform.position + translation))
            {
                //currentPosition += translation;
                transform.Translate(translation);

                //haveIWon(transform.position);
            }
            Debug.Log(translation);
        }

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Guard"))
        {
            Debug.Log("cap");
            gameStatePlayer.capturePlayer();
        }
        if (coll.gameObject.CompareTag("Exit"))
        {
            gameStatePlayer.freePlayer();
            Debug.Log("win");
        }
    }
}
