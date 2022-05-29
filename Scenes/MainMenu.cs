using Godot;
using System;

public class MainMenu : ColorRect
{
    const bool TWO_PLAYER = true;
    const bool ONE_PLAYER = false;

    private void _on_1_Player_pressed()
    {
        LoadGame(ONE_PLAYER);
    }

    private void _on_2_Player_pressed()
    {
        LoadGame(TWO_PLAYER);
    }

    private void LoadGame(bool mode)
    {
        // Load game scene
        Game game =
            ResourceLoader.Load<PackedScene>("res://Scenes/Game.tscn")
            .Instance<Game>();

        // Edit & Re-pack scene
        game.initGameMode(mode);
        PackedScene gameps = new PackedScene();
        gameps.Pack(game);

        // Change scene
        GetTree().ChangeSceneTo(gameps);
    }
}
