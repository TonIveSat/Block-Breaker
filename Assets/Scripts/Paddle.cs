using UnityEngine;
using System.Collections;
using System;

public class Paddle : MonoBehaviour {

    public bool AutoPlay;

    private Ball ball;

	// Use this for initialization
	void Start ()
    {
        ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (AutoPlay)
        {
            MoveWithBall();
        }
        else
        {
            MoveWithMouse();
        }
    }

    private void MoveWithBall()
    {
        var ballPos = new Vector2(ball.transform.position.x, transform.position.y);
        ballPos.x = Mathf.Clamp(ballPos.x, 0.77f, 15.23f);
        this.transform.position = ballPos;
    }

    void MoveWithMouse()
    {
        Vector3 paddlePos = new Vector3(8, this.transform.position.y, 0f);
        var MousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
        paddlePos.x = Mathf.Clamp(MousePosInBlocks, 0.77f, 15.23f);
        this.transform.position = paddlePos;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        print("Paddle Trigger");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        print("Paddle Collision");
    }
}
