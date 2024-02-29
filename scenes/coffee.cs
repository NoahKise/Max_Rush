using Godot;
using System;

public partial class coffee : StaticBody2D
{
	public Timer delayTimer;
	public Node gdScriptNode;

	public override void _Ready()
	{
		gdScriptNode = GetNode("../player");
		delayTimer = GetNode<Timer>("CoffeeTimer");
	}
	
	private void _on_drank_body_entered(Node2D body)
	{
		if (body.Name == "player")
		{
			gdScriptNode.Call("set_speed", 650);
			delayTimer.Start();
			Vector2 newPosition = new Vector2(0, -10000); // Set your desired position here
			this.GlobalPosition = newPosition;
			
		}
	}
	private void _on_coffee_timer_timeout()
	{
		gdScriptNode.Call("set_speed", 400);
	}
}


