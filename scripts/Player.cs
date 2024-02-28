using Godot;
using System;

namespace PlatformerTutorial.Scripts;
public partial class Player : CharacterBody2D
{
	[Export]
	private float _speed = 100.0f;
	[Export]
	private float _gravity = 200.0f;

	[Export]
	private float _jumpHeight = -100.0f;



	private AnimatedSprite2D _animatedSprite;

	private CollisionShape2D _collisionShape2d;

	private Global _global;

	public override void _Ready()
	{
		_animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		_global = GetNode<Global>("/root/Global");
	}


  public override void _PhysicsProcess(double delta)
  {
			Vector2 velocity = Velocity;

			velocity.Y +=  _gravity * (float)delta;
				
			float direction = Input.GetActionStrength("ui_right") - Input.GetActionStrength("ui_left");
			velocity.X = direction * _speed;
			Velocity = velocity;
			MoveAndSlide();
			if (!_global.IsAttacking || !_global.IsClimbing)
			{
				PlayerAnimations();
			}
      base._PhysicsProcess(delta);
  }

    public void PlayerAnimations()
	{
// left
		if (Input.IsActionPressed("ui_left") || Input.IsActionJustReleased("ui_jump"))
		{
			_animatedSprite.FlipH = true;
			_animatedSprite.Play("Run");
			Vector2 vector = _collisionShape2d.Position;
			vector.X = 7.5f;
			_collisionShape2d.Position = vector;
		}

// right
		if (Input.IsActionPressed("ui_right") || Input.IsActionJustReleased("ui_jump"))
		{
			_animatedSprite.FlipH = false;
			_animatedSprite.Play("Run");
			Vector2 vector = _collisionShape2d.Position;
			vector.X = -7.5f;
			_collisionShape2d.Position = vector;
		}

// idle
		if (!Input.IsAnythingPressed())
		{
			_animatedSprite.Play("Idle");
		}


	}

    public override void _Input(InputEvent @event)
    {
				if (@event.IsActionPressed("ui_attack"))
				{
					_global.IsAttacking = true;
					_animatedSprite.Play("Attack");

				};
				if (@event.IsActionPressed("ui_jump") && IsOnFloor())
				{
					Vector2 velocity = Velocity;
					velocity.Y = _jumpHeight;
					Velocity = velocity;
					_animatedSprite.Play("Jump");
				}
				if (_global.IsClimbing)
				{
					if (Input.IsActionPressed("ui_up"))
					{
						_animatedSprite.Play("Climb");
						_gravity = 100.0f;
						Vector2 velocity = Velocity;
						velocity.Y = -200;
						Velocity = velocity;
					}
				}
				else
				{
					_gravity = 200.0f;
					_global.IsClimbing = false;
				}

        base._Input(@event);
    }

	public void OnAnimatedSprite2dAnimationFinished()
	{
		_global.IsAttacking = false;
		_global.IsClimbing = false;
	}
}
