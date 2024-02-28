extends StaticBody2D

@onready var splash = $Splash

func be_bounced_upon(bouncer):
	if bouncer.has_method("bounce"):
		bouncer.bounce()
		splash.play()
		bouncer.jump_count = 1
