using Godot;
using System;

public partial class TimerNode : Node2D
{
	public Label label;
	public Timer timer;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		label = GetNode<Label>("TimeLeft");
		timer = GetNode<Timer>("GameTime");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		label.Text = timer.TimeLeft.ToString("F1");
	}
	
	private void _on_game_time_timeout()
	{
		GetTree().ChangeSceneToFile("res://scenes/LevelComplete.tscn");
	}
	
}

