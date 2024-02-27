extends CharacterBody2D

@export var speed = 300
@export var gravity = 40
@export var jump_force = 400

@onready var ap = $AnimationPlayer
@onready var sprite = $Sprite2D
@onready var cshape = $CollisionShape2D
@onready var slideRaycast1 = $SlideRaycast1
@onready var slideRaycast2 = $SlideRaycast2

var standing_cshape = preload("res://resources/player_standing_cshape.tres")
var sliding_cshape = preload("res://resources/player_sliding_cshape.tres")

var jump_max = 2
var jump_count = 0
var slide_max = 1
var slide_count = 0
var is_sliding = false
var stuck_under_object = false

func _physics_process(delta):
	if !is_on_floor():
		velocity.y += gravity
		if velocity.y > 1000:
			velocity.y = 1000
	
	if is_on_floor() && jump_count != 0:
		jump_count = 0
			
	if Input.is_action_just_pressed("jump") && jump_count < jump_max && !stuck_under_object: #&& is_on_floor():
		stand()
		velocity.y = -jump_force
		jump_count += 1
		
	var horizontal_direction = Input.get_axis("move_left", "move_right")
	
	if Input.is_action_just_pressed("slide"):
		slide()
	elif Input.is_action_just_released("slide"):
		if above_empty():
			stand()
		else:
			if stuck_under_object != true:
				stuck_under_object = true
	
	if stuck_under_object && above_empty():
		if !Input.is_action_pressed("slide"):
			stand()
			stuck_under_object = false
	
	if horizontal_direction != 0:
		switch_direction(horizontal_direction)
	
	velocity.x = speed * 2 * horizontal_direction
	
	move_and_slide()
	
	update_animations(horizontal_direction)
	
func update_animations(horizontal_direction):
	if is_on_floor():
		if horizontal_direction == 0:
			if is_sliding:
				ap.play("duck")
			else:
				ap.play("idle")
		else:
			if is_sliding:
				ap.play("slide")
			else:
				ap.play("run")
	else:
		if velocity.y < 0 && jump_count == 2:
			ap.play("double_jump")
		elif velocity.y < 0  && jump_count == 1:
			ap.play("jump")
		elif velocity.y > 0:
			ap.play("fall")
func switch_direction(horizontal_direction):
	sprite.flip_h = (horizontal_direction == -1)
	sprite.position.x = horizontal_direction * 18
	
func slide():
	if is_sliding:
		return
	is_sliding = true
	cshape.shape = sliding_cshape
	cshape.position.y = -15
func stand():
	if is_sliding == false:
		return
	is_sliding = false
	cshape.shape = standing_cshape
	cshape.position.y = -26

func above_empty() -> bool:
	var result = !slideRaycast1.is_colliding() && !slideRaycast2.is_colliding()
	return result
