using System;
using Godot;

namespace main
{
    public class Paddle : StaticBody2D
    {
        public int vpSize { get; } = 600;
        public int paddleHeight { get; } = 50;

        public float Speed { get; } = 15;

        public int score { get; set; }

        public Vector2 startPos { get; set; }

        public void ResetPosition()
        {
            Position = startPos;
        }
    }
}
