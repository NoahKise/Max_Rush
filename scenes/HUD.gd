extends CanvasLayer

var coins = 0

func _ready():
	$Coins.text = String(coins)

func _physics_process(delta):
	if coins == 28:
		

func _on_coin_collected():
	coins = coins + 1
	_ready()
