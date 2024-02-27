using Godot;
using System;

namespace PlatformerTutorial.Scripts;
public partial class Ladder : Area2D
{
	// Called when the node enters the scene tree for the first time.

	private Global _global;
	public override void _Ready()
	{
		_global = GetNode<Global>("/root/Global");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void OnBodyEntered(Node2D body)
	{
		if (body.Name == "Player")
		{
			_global.IsClimbing = true;
		}

	}

		public void OnBodyExited(Node2D body)
	{
		if (body.Name == "Player")
		{
			_global.IsClimbing = false;
		}

	}
}
