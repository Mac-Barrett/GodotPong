using System;
using Godot;
using main;

public class CPU : Paddle
{
    public Ball ball;

    public float topEdge { get { return Position.y; } }
    public float bottomEdge { get { return Position.x - paddleHeight; } }

    public void setBall(Ball theball)
    {
        ball = theball;
    }

    public override void _Ready()
    {
        Position = startPos;
    }

    public override void _PhysicsProcess(float delta)
    {
        MatchBallPosition();
    }

    private void MatchBallPosition()
    {
        if (ball.Position.y > topEdge + 5)
        {
            Position = new Vector2(Position.x, Position.y + 5);
            if (Position.y >= vpSize - paddleHeight)
                Position = new Vector2(Position.x, vpSize - paddleHeight);
        }
        else if (ball.Position.y < bottomEdge - 5)
        {
            Position = new Vector2(Position.x, Position.y - 5);
            if (Position.y <= 0)
                Position = new Vector2(Position.x, 0);
        }
    }
}


