using Godot;
using System;

public partial class LevelComplete : Node2D
{
	
	private void _on_play_again_pressed()
	{
		GetTree().ChangeSceneToFile("res://scenes/LevelOne.tscn");
	}
	
	private void _on_quit_pressed()
	{
		GetTree().Quit();
	}
}






