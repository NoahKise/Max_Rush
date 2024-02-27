using Godot;
using System;

public partial class dog : CharacterBody2D
{
	public const float Speed = 100.0f;
	public const float JumpVelocity = -400.0f;
	public float Gravity;
	public CharacterBody2D Player;
	public bool Chase = false;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
		GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("Idle");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Vector2 velocity = Velocity;
		if (Chase == true)
		{
			GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("Walk");
			Player = GetNode<CharacterBody2D>("../Player");
			Vector2 direction = (Player.Position - Position).Normalized();
			if (direction.X > 0)
			{
				GetNode<AnimatedSprite2D>("AnimatedSprite2D").FlipH = false;
			}
			else
			{
				GetNode<AnimatedSprite2D>("AnimatedSprite2D").FlipH = true;
			}
			velocity.X = direction.X * Speed;
		}
		else
		{
			GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("Idle");
			velocity.X = 0;
		}
		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity.Y += Gravity * (float)delta;
		}
		Velocity = velocity;
		MoveAndSlide();

	}

	private void _on_player_detection_body_entered(Node2D body)
	{
		if (body.Name == "Player")
		{
			Player = GetNode<CharacterBody2D>("../Player");
			Chase = true;
			GD.Print(Player.GlobalPosition);
		}
	}
	private void _on_player_detection_body_exited(Node2D body)
	{
		if (body.Name == "Player")
		{
			Player = GetNode<CharacterBody2D>("../Player");
			Chase = false;
			// Replace with function body.
		}
	}
}
