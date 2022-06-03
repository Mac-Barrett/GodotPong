using System;
using Godot;

namespace main
{
    public class Paddle : StaticBody2D
    {
        public int vpSize { get; } = 600;
        public int paddleHeight { get; private set; } = 50;

        public float Speed { get; set; } = 15;

        public int score { get; set; }

        public Vector2 startPos { get; set; }

        public void ResetPosition()
        {
            Position = startPos;
        }

        public void SetFatPaddle()
        {
            paddleHeight *= 2;

            ColorRect Body = GetNode<ColorRect>("Body");
            Body.RectSize = new Vector2(Body.RectSize.x, Body.RectSize.y * 2);

            CollisionShape2D Collision = GetNode<CollisionShape2D>("Collision");
            Collision.Scale = new Vector2(1, 2);
            Collision.Position = new Vector2(0, 50);
        }
    }
}
