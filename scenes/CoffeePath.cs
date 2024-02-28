using Godot;
using System;

public partial class CoffeePath : Sprite2D
{
	public start postion;
	private PathFollow2D pathFollow;
	[Export]
	public float speed = 25f;

	public override void _Ready()
	{
		pathFollow = GetParent<PathFollow2D>();
	}

	public override void _PhysicsProcess(double delta)
	{
		pathFollow.HOffset += (float)(speed * delta);
	}
}
