using Godot;
using System;

public partial class Failure : Node2D
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





