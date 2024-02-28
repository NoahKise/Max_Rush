using Godot;
using System;

public partial class CoffeePath : Sprite2D
{
	private Vector2 StartPosition;
	private PathFollow2D pathFollow;
	[Export]
	public float speed = 15f;
	public int ticker;

	public override void _Ready()
	{
		pathFollow = GetParent<PathFollow2D>();
		StartPosition = GlobalPosition;
		ticker = 1;
		//GD.Print(StartPosition);
	}

	public override void _PhysicsProcess(double delta)
	{
		if (ticker % 2 != 0 )
		{
			pathFollow.HOffset += (float)(speed * delta);
		}
		else 
		{
			pathFollow.HOffset -= (float)(speed * delta);
		}
		
		if (pathFollow.HOffset == 5 || pathFollow.HOffset == -5)
		{
			ticker++;
		}
		
		
		 
	}
}
