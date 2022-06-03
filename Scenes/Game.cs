using Godot;
using System;
using main;

public class Game : Node2D
{
    const int vpSize = 600;
    const int RESET_RIGHT = 1;
    const int RESET_LEFT = -1;

    Paddle p1;
    Paddle p2;
    Ball ball;

    const String HUD_PATH = "HUD/Score/";
    Label lbl_p1score;
    Label lbl_p2score;

    const int POINTS_TO_WIN = 5;
    static bool isTwoPlayer;

    public override void _Ready()
    {
        GD.Print(isTwoPlayer);
        lbl_p1score = GetNode<Label>($"{HUD_PATH}p1score");
        lbl_p2score = GetNode<Label>($"{HUD_PATH}p2score");

        ball = GetNode<Ball>("Ball");

        p1 = GetNode<Player>("Player1");
        Player p1cast = p1 as Player;
        p1cast.BindInputKeys((int)KeyList.W, (int)KeyList.S);
        p1.startPos = new Vector2(60, (vpSize / 2) - (p1.paddleHeight / 2));

        if (isTwoPlayer)
        {
            p2 =
                ResourceLoader.Load<PackedScene>("res://Objects/Player.tscn")
                .Instance<Paddle>();
            AddChild(p2);
            Player p2cast = p2 as Player;
            p2cast.BindInputKeys((int)KeyList.Up, (int)KeyList.Down);
        }
        else
        {
            p2 =
                ResourceLoader.Load<PackedScene>("res://Objects/CPU.tscn")
                .Instance<Paddle>();
            AddChild(p2);
            CPU p2cast = p2 as CPU;
            p2cast.setBall(ball);
        }
        p2.startPos = new Vector2(vpSize - 60, (vpSize / 2) - (p1.paddleHeight / 2));

        ResetPlayerPos();
    }

    public void initGameMode(bool twoplayer)
    {
        isTwoPlayer = twoplayer;
    }

    public override void _PhysicsProcess(float delta)
    {
        if (ball.Position.y < 0 || ball.Position.y > vpSize)
            ball.Velocity = new Vector2(ball.Velocity.x, ball.Velocity.y * -1);
        if (ball.Position.x < 0)
        {
            UpdateScore(p2, lbl_p2score);
            if (p2.score >= POINTS_TO_WIN)
                ShowGameOver(2);
            else
            {
                ball.Reset(RESET_RIGHT);
                ResetPlayerPos();
            }
        }
        else if (ball.Position.x > vpSize)
        {
            UpdateScore(p1, lbl_p1score);
            if (p1.score >= POINTS_TO_WIN)
                ShowGameOver(1);
            else
            {
                ball.Reset(RESET_LEFT);
                ResetPlayerPos();
            }
        }
    }

    private void UpdateScore(Paddle p, Label label)
    {
        p.score++;
        label.Text = p.score.ToString();
    }

    private void ShowGameOver(int winner)
    {
        GameOver gameOver =
            ResourceLoader.Load<PackedScene>("res://Scenes/GameOver.tscn")
            .Instance<GameOver>();

        GetTree().CurrentScene.AddChild(gameOver);
        gameOver.setMessage(winner);
        GetTree().Paused = true;
        ResetGame();
    }

    private void ResetGame()
    {
        ResetPlayerPos();
        p1.score = 0;
        lbl_p1score.Text = p1.score.ToString();

        p2.score = 0;
        lbl_p2score.Text = p2.score.ToString();

        Random r = new Random();
        int dir = r.Next(0, 1);
        dir = (dir == 0) ? RESET_LEFT : RESET_RIGHT;
        ball.Reset(dir);
    }

    private void ResetPlayerPos()
    {
        p1.ResetPosition();
        p2.ResetPosition();
    }
}
