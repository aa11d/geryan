extends Node3D

var used = false
var food = 10.0

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	food = randf_range(8.0, 12.0)


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	pass


func interact(who: Player):
	if used:
		return
	used = true
	$Bush/AnimationPlayer.play("gather")
	if who:
		who.food += food
	
