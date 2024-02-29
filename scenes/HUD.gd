extends CanvasLayer

@export var coins = 0
@export var win = false

func _ready():
	$Coins.text = str(int(coins))
	pass

func _physics_process(delta):
	if coins >= 28:
		win = true

func _on_coin_coin_collected():
	coins += 1
	_ready()


func _on_coin_3_coin_collected():
	coins += 1
	_ready()

func _on_coin_4_coin_collected():
	coins += 1
	_ready()

func _on_coin_5_coin_collected():
	coins += 1
	_ready()

func _on_coin_6_coin_collected():
	coins += 1
	_ready()

func _on_coin_7_coin_collected():
	coins += 1
	_ready()

func _on_coin_8_coin_collected():
	coins += 1
	_ready()

func _on_coin_9_coin_collected():
	coins += 1
	_ready()

func _on_coin_10_coin_collected():
	coins += 1
	_ready()

func _on_coin_11_coin_collected():
	coins += 1
	_ready()

func _on_coin_12_coin_collected():
	coins += 1
	_ready()

func _on_coin_13_coin_collected():
	coins += 1
	_ready()

func _on_coin_14_coin_collected():
	coins += 1
	_ready()

func _on_coin_15_coin_collected():
	coins += 1
	_ready()

func _on_coin_16_coin_collected():
	coins += 1
	_ready()

func _on_coin_17_coin_collected():
	coins += 1
	_ready()

func _on_coin_18_coin_collected():
	coins += 1
	_ready()

func _on_coin_19_coin_collected():
	coins += 1
	_ready()

func _on_coin_20_coin_collected():
	coins += 1
	_ready()

func _on_coin_21_coin_collected():
	coins += 1
	_ready()

func _on_coin_22_coin_collected():
	coins += 1
	_ready()

func _on_coin_23_coin_collected():
	coins += 1
	_ready()

func _on_coin_24_coin_collected():
	coins += 1
	_ready()

func _on_coin_25_coin_collected():
	coins += 1
	_ready()

func _on_coin_26_coin_collected():
	coins += 1
	_ready()

func _on_coin_27_coin_collected():
	coins += 1
	_ready()

func _on_coin_28_coin_collected():
	coins += 1
	_ready()

func _on_coin_29_coin_collected():
	coins += 1
	_ready()

func _on_coin_30_coin_collected():
	coins += 1
	_ready()

func _on_coin_31_coin_collected():
	coins += 1
	_ready()

func _on_coin_32_coin_collected():
	coins += 1
	_ready()

func _on_coin_33_coin_collected():
	coins += 1
	_ready()

func _on_coin_34_coin_collected():
	coins += 1
	_ready()

func _on_coin_35_coin_collected():
	coins += 1
	_ready()

func _on_coin_36_coin_collected():
	coins += 1
	_ready()

func _on_coin_37_coin_collected():
	coins += 1
	_ready()

func _on_coin_38_coin_collected():
	coins += 1
	_ready()

func _on_coin_39_coin_collected():
	coins += 1
	_ready()

func _on_coin_40_coin_collected():
	coins += 1
	_ready()

func _on_coin_41_coin_collected():
	coins += 1
	_ready()

func _on_coin_42_coin_collected():
	coins += 1
	_ready()

func _on_coin_43_coin_collected():
	coins += 1
	_ready()

func _on_coin_44_coin_collected():
	coins += 1
	_ready()

func _on_coin_45_coin_collected():
	coins += 1
	_ready()

func _on_coin_46_coin_collected():
	coins += 1
	_ready()

func _on_coin_47_coin_collected():
	coins += 1
	_ready()

func _on_coin_48_coin_collected():
	coins += 1
	_ready()

func _on_coin_49_coin_collected():
	coins += 1
	_ready()

func _on_coin_50_coin_collected():
	coins += 1
	_ready()

func _on_coin_51_coin_collected():
	coins += 1
	_ready()
