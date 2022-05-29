using Godot;
using System;

public class GameOver : CenterContainer
{
    Label txt;

    public override void _Ready()
    {
        txt = GetNode<Label>("VBox/Label");
    }

    public void setMessage(int winner)
    {
        txt.Text = "Game Over!\n Player "+winner+" wins!";
    }

    private void _on_Play_Again_pressed()
    {
        GD.Print("HERE");
        GetTree().Paused = false;
        GetTree().CurrentScene.RemoveChild(this);
    }


    private void _on_Main_Menu_pressed()
    {
        GD.Print("HERE");
        GetTree().ChangeScene("res://Scenes/MainMenu.tscn");
    }


    private void _on_Quit_pressed()
    {
        GetTree().Quit();
    }
}
