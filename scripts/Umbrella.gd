extends StaticBody2D

func be_bounced_upon(bouncer):
	if bouncer.has_method("bounce"):
		bouncer.bounce()
		bouncer.jump_count = 1
