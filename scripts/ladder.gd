extends Area2D

func _on_body_entered(body):
	if body.name == "player":
		body.is_climbing = true


func _on_body_exited(body):
	if body.name == "player":
		body.is_climbing = false
		if body.last_button_pressed != "none":
			body.jump_count = 1
			
		body.last_button_pressed = "none"
