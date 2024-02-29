using Godot;
using System;

namespace MaxRush.Scripts;

public partial class CarEnemy : RigidBody2D
{
	// Called when the node enters the scene tree for the first time.
	private PathFollow2D _pathFollow2D;
	private AnimatedSprite2D _animatedSprite2D;
	private CollisionPolygon2D _collisionPolygon2D;

	private AudioStreamPlayer2D _AudioStreamPlayer2D;

	private AudioStreamPlayer _crush;

	private float _gravity;
	private Area2D _hitBox;

	private bool _isDead = false;

	private bool _onPath = false;

	[Export]
	private float _speed = 100;

	private float _prevProgress;
	
	public override void _Ready()
	{
		CollisionMask = 1;

		_gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
		_animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		_collisionPolygon2D = GetNode<CollisionPolygon2D>("CollisionPolygon2D");
		_hitBox = GetNode<Area2D>("HitBox");
		_animatedSprite2D.Play("Roaming");
		_AudioStreamPlayer2D = GetNode<AudioStreamPlayer2D>("AudioStreamPlayer2D");
		_AudioStreamPlayer2D.Playing = true;
		_crush = GetNode<AudioStreamPlayer>("Crush");
		_pathFollow2D = GetParentOrNull<PathFollow2D>();

		if (_pathFollow2D != null)
		{
			_pathFollow2D.ProgressRatio = 0.0f;
			_pathFollow2D.Loop = true;
			_pathFollow2D.Rotates = false;
			_onPath = true;
		}
		else
		{

		}
	}

	public override void _Process(double delta)
	{
		if (_onPath)
		{
			float progress = _pathFollow2D.Progress;
			_pathFollow2D.Progress += _speed * (float)delta;
			if (progress < _prevProgress)
			{
				_animatedSprite2D.FlipH = !_animatedSprite2D.FlipH;
			}
			_prevProgress = progress;
		}

	}

	public void OnBodyEntered(Node2D body)
	{
		if (body.Name == "player")
		{
			_AudioStreamPlayer2D.Playing = false;
			_crush.Playing = true;
			_animatedSprite2D.Play("Crushed");
			CollisionMask = 10;
			ZIndex = 10;
			_isDead = true;
			_onPath = false;
		};
	}

	public void OnScreenExited()
	{
		if (_isDead)
		{
			QueueFree();
		}
	}
}
