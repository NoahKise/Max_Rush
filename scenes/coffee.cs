using Godot;
using System;

public partial class coffee : StaticBody2D
{

	public override void _Ready()
	{
		gdScriptNode = GetNode("../player");
	}
	public Node gdScriptNode;
	private void _on_drank_body_entered(Node2D body)
	{
		if (body.Name == "player")
		{
			gdScriptNode.Call("set_speed", 450);
			QueueFree();
		}
	}
}

