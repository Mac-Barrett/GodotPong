using Godot;
using System;

public class Ball : Area2D
{
    const int ballSize = 0;
    const int vpSize = 600;

    const float baseSpeed = 100;
    private float currSpeed = baseSpeed;
    const float speedInc = 10;
    const float maxSpeed = 500;

    public Vector2 Velocity { get; set; }

    private Vector2 startPos = new Vector2(vpSize / 2, vpSize / 2);

    private Random r = new Random();

    public override void _Ready()
    {
        Velocity = new Vector2(
            GetRandomDirection() * baseSpeed,
            GetRandomDirection() * baseSpeed);
    }

    public override void _PhysicsProcess(float delta)
    {
        Position += new Vector2(Velocity.x * delta, Velocity.y * delta);
    }

    private void _on_Ball_body_entered(object body)
    {
        currSpeed = Math.Min(currSpeed + speedInc, maxSpeed);

        float xVel = currSpeed;
        xVel = (Velocity.x < 0) ? xVel : xVel * -1;
        float yVel = currSpeed;
        yVel = (Velocity.y < 0) ? yVel * -1 : yVel;

        Velocity = new Vector2(xVel, yVel);
    }

    public void Reset(int xDir) // false ball moves left | true ball moves right
    {
        Position = startPos;
        currSpeed = baseSpeed;
        Velocity = new Vector2(xDir * baseSpeed, GetRandomDirection() * baseSpeed);
    }

    private int GetRandomDirection()
    {
        int dir = r.Next(0, 1);
        return (dir == 0) ? -1 : 1;
    }
}
