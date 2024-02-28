extends CharacterBody2D

@export var speed = 400
@export var gravity = 40
@export var jump_force = 600
@export var is_climbing = false

@onready var ap = $AnimationPlayer
@onready var sprite = $Sprite2D
@onready var cshape = $CollisionShape2D
@onready var slideRaycast1 = $SlideRaycast1
@onready var slideRaycast2 = $SlideRaycast2
@onready var bounce_raycasts = $BounceRaycasts
@onready var jumpSound = $JumpSound
@onready var slideSound = $SlideSound
@onready var music = $Music

var standing_cshape = preload("res://resources/player_standing_cshape.tres")
var sliding_cshape = preload("res://resources/player_sliding_cshape.tres")

var jump_max = 2
@export var jump_count = 0
var slide_max = 1
var slide_count = 0
var is_sliding = false
var stuck_under_object = false
@export var last_button_pressed = "none"

const BOUNCE_VELOCITY = -800 

# Called when the node enters the scene tree for the first time.
func _ready():
	music.play()

func _physics_process(delta):
	if is_climbing == false:
		velocity.y += gravity
		if velocity.y > 1000:
			velocity.y = 1000
	elif is_climbing == true:
		velocity.y += gravity
		if Input.is_action_pressed("climb"):
			velocity.y = -speed / 2
			last_button_pressed = "up"
		elif Input.is_action_pressed("slide"):
			velocity.y = speed / 2
			last_button_pressed = "down"
		elif last_button_pressed != "none":
			velocity.y = 0
	
	if is_on_floor()&&jump_count != 0:
		jump_count = 0

		
	if is_climbing == true && last_button_pressed != "none":
		jump_count = 0
	
	if Input.is_action_just_pressed("jump") && jump_count < jump_max && !stuck_under_object: #&& is_on_floor():
		jumpSound.play()
		stand()
		velocity.y = -jump_force
		jump_count += 1
		
	var horizontal_direction = Input.get_axis("move_left", "move_right")
	
	if Input.is_action_just_pressed("slide") && is_climbing == false:
		slideSound.play()
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
	
	velocity.x = speed * horizontal_direction

	_check_bounce(delta)

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
	elif is_climbing == true && last_button_pressed != "none":
		if velocity.y == 0:
			ap.play("climb_idle")
		else:
			ap.play("climb")
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

func slide():
	if is_sliding:
		return
	is_sliding = true
	if is_climbing == false:
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

func _check_bounce(delta):
	if velocity.y > 0:
		for raycast in bounce_raycasts.get_children():
			raycast.target_position = Vector2.DOWN * velocity * delta + Vector2.DOWN
			raycast.force_raycast_update()
			if raycast.is_colliding() && raycast.get_collision_normal() == Vector2.UP:
				velocity.y = (raycast.get_collision_point() - raycast.global_position - Vector2.DOWN).y / delta
				raycast.get_collider().entity.call_deferred("be_bounced_upon", self)
				break

func bounce(bounce_velocity = BOUNCE_VELOCITY):
	velocity.y = bounce_velocity


func set_speed(new_speed):
	speed = new_speed
