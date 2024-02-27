using Godot;
using System;

public partial class Bus : Node
{
	private AnimatedSprite2D _busSprite;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_busSprite = GetNode<AnimatedSprite2D>("BusSprite");
	}

	
	public void OnBodyEntered(Node2D body)
	{
		if (body.Name == "player")
		{
			_busSprite.Play("Open");
		}
	}

	public void OnBodyExited(Node2D body)
	{
		_busSprite.Play("Idle");
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
