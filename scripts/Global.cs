using Godot;
using System;

namespace PlatformerTutorial.Scripts;
public partial class Global : Node
{

	public bool IsAttacking { get; set; }
	public bool IsClimbing { get; set; }
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		IsAttacking = false;
		IsClimbing = false;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
