using Godot;
using System.Collections;

public class MainMenu : ColorRect
{
    const bool TWO_PLAYER = true;
    const bool ONE_PLAYER = false;
    const string PATH_TO_CKBTNS = "CCon/VBoxCon/Control/CCon/HBoxCon";

    private void _on_1_Player_pressed()
    {
        LoadGame(ONE_PLAYER);
    }

    private void _on_2_Player_pressed()
    {
        LoadGame(TWO_PLAYER);
    }

    private void LoadGame(bool isTwoPlayer)
    {
        // Load game scene
        Game game =
            ResourceLoader.Load<PackedScene>("res://Scenes/Game.tscn")
            .Instance<Game>();

        // Grab Mode data from check buttons
        BitArray modes = new BitArray(4);
        modes.Set(0, isTwoPlayer);
        modes.Set(1, GetNode<CheckButton>($"{PATH_TO_CKBTNS}/Fat Paddles").Pressed);
        modes.Set(2, GetNode<CheckButton>($"{PATH_TO_CKBTNS}/Fast Ball").Pressed);
        modes.Set(3, GetNode<CheckButton>($"{PATH_TO_CKBTNS}/CPU Hard").Pressed);

        // Load, initialize, pack & switch scenes
        GD.Print(modes.ToString());
        game.initGameModes(modes);
        PackedScene gameps = new PackedScene();
        gameps.Pack(game);
        GetTree().ChangeSceneTo(gameps);
    }
}
