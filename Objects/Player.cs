using Godot;
using System;
using main;

public class Player : Paddle
{
    public int upInput { get; set; }
    public int downInput { get; set; }

    public override void _Ready()
    {
        Position = startPos;
    }

    public override void _PhysicsProcess(float delta)
    {
        GetMoveInput(delta);
    }

    public void BindInputKeys(int UP, int DOWN)
    {
        upInput = UP;
        downInput = DOWN;
    }

    private void GetMoveInput(float delta)
    {
        bool up = false;
        bool down = false;
        if (Input.IsPhysicalKeyPressed(upInput))
            up = true;
        if (Input.IsPhysicalKeyPressed(downInput))
            down = true;

        if (up && !down)
        {
            Position = new Vector2(Position.x, Position.y - Speed);
            if (Position.y <= 0)
                Position = new Vector2(Position.x, 0);
        }
        else if (down && !up)
        {
            Position = new Vector2(Position.x, Position.y + Speed);
            if (Position.y >= vpSize - paddleHeight)
                Position = new Vector2(Position.x, vpSize - paddleHeight);
        }
        return;
    }
}
