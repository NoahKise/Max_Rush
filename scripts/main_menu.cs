using Godot;
using System;

public partial class main_menu : Node2D
{
	private void _on_start_pressed()
	{
		GetTree().ChangeSceneToFile("res://scenes/LevelOne.tscn");
	}

	private void _on_quit_pressed()
	{
		GetTree().Quit();
	}

}

