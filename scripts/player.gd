extends CharacterBody2D

@export var speed = 300
@export var gravity = 40
@export var jump_force = 400

@onready var ap = $AnimationPlayer
@onready var sprite = $Sprite2D

var jump_max = 2
var jump_count = 0
var slide_max = 1
var slide_count = 0

func _physics_process(delta):
	if !is_on_floor():
		velocity.y += gravity
		if velocity.y > 1000:
			velocity.y = 1000
	
	if is_on_floor()&&jump_count != 0:
		jump_count = 0
			
	if Input.is_action_just_pressed("jump")&&jump_count < jump_max: # && is_on_floor():
		velocity.y = -jump_force
		jump_count += 1
	
	var horizontal_direction = Input.get_axis("move_left", "move_right")
	
	if horizontal_direction != 0:
		switch_direction(horizontal_direction)
	
	velocity.x = speed * 2 * horizontal_direction
	
	move_and_slide()
	
	update_animations(horizontal_direction)
	
func update_animations(horizontal_direction):
	if is_on_floor():
		if horizontal_direction == 0:
			ap.play("idle")
		elif Input.is_action_pressed("slide"):
			ap.play("slide")
		else:
			ap.play("run")
	else:
		if velocity.y < 0&&jump_count == 2:
			ap.play("double_jump")
		elif velocity.y < 0&&jump_count == 1:
			ap.play("jump")
		elif velocity.y > 0:
			ap.play("fall")
func switch_direction(horizontal_direction):
	sprite.flip_h = (horizontal_direction == - 1)
	sprite.position.x = horizontal_direction * 18

func set_speed(new_speed):
	speed = new_speed
