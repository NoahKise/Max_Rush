//using Godot;
//
//public partial class Player : CharacterBody2D
//{
	//// Exported properties from the GDScript
	//[Export]
	//public float Speed { get; set; } = 300;
//
	//[Export]
	//public float Gravity { get; set; } = 40;
//
	//[Export]
	//public float JumpForce { get; set; } = 400;
//
	//// Other variables
	//private int jumpMax = 2;
	//private int jumpCount = 0;
	//private int slideMax = 1;
	//private int slideCount = 0;
//
	//// Other nodes
	//private AnimationPlayer ap;
	//private Sprite2D sprite;
//
	//public override void _Ready()
	//{
		//ap = GetNode<AnimationPlayer>("AnimationPlayer");
		//sprite = GetNode<Sprite2D>("Sprite2D");
	//}
//
	//public override void _PhysicsProcess(double delta)
	//{
		//Vector2 velocity = Velocity;
		//if (!IsOnFloor())
		//{
			//velocity += new Vector2(0, Gravity);
			//if (velocity.Y > 1000)
			//{
				//velocity.Y = 1000;
			//}
		//}
//
		//if (IsOnFloor() && jumpCount != 0)
		//{
			//jumpCount = 0;
		//}
//
		//if (Input.IsActionJustPressed("jump") && jumpCount < jumpMax)
		//{
			//velocity.Y = -JumpForce;
			//jumpCount += 1;
		//}
//
		//var horizontalDirection = Input.GetActionStrength("move_right") - Input.GetActionStrength("move_left");
//
		//if (horizontalDirection != 0)
		//{
			//SwitchDirection(horizontalDirection);
		//}
//
		//velocity.X = Speed * 2 * horizontalDirection;
//
		//MoveAndSlide();
//
		//UpdateAnimations(horizontalDirection);
	//}
//
	//private void UpdateAnimations(float horizontalDirection)
	//{
		//if (IsOnFloor())
		//{
			//if (horizontalDirection == 0)
			//{
				//ap.Play("idle");
			//}
			//else if (Input.IsActionPressed("slide"))
			//{
				//ap.Play("slide");
			//}
			//else
			//{
				//ap.Play("run");
			//}
		//}
		//else
		//{
			//if (Velocity.Y < 0 && jumpCount == 2)
			//{
				//ap.Play("double_jump");
			//}
			//else if (Velocity.Y < 0 && jumpCount == 1)
			//{
				//ap.Play("jump");
			//}
			//else if (Velocity.Y > 0)
			//{
				//ap.Play("fall");
			//}
		//}
	//}
//
	//private void SwitchDirection(float horizontalDirection)
	//{
		//sprite.FlipH = horizontalDirection == -1;
		////sprite.Position.X = horizontalDirection * 18;
	//}
//}
