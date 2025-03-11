extends CharacterBody3D
class_name Player


const ACCEL = 7.0
const JUMP_VELOCITY = 4.5
const SENSITIVITY = 0.05

var speed = 6.0
var sprinting = false:
	set(x):
		sprinting = x
		speed = 10.0 if x else 6.0

var interact_with = null

var food = 100.0:
	set(x):
		food = clamp(x, 0, 100)
		$CanvasLayer/Food_Bar.value = food
var hp = 100.0:
	set(x):
		hp = clamp(x, 0, 100)
		$CanvasLayer/HP_Bar.value = hp
		$CanvasLayer/Blood.modulate = lerp(Color(1, 1, 1, 1), Color(1, 1, 1, 0), hp/100)
		if hp <= 0.1:
			dead = true
var dead = false:
	set(x):
		if x == true and dead == false:
			dead = x
			kill()
	
func _physics_process(delta: float) -> void:
	if not is_on_floor():
		velocity += get_gravity() * delta

	if Input.is_action_just_pressed("jump") and is_on_floor():
		velocity.y = JUMP_VELOCITY

	var input_dir := Input.get_vector("left", "right", "up", "down")
	var direction := (transform.basis * Vector3(input_dir.x, 0, input_dir.y)).normalized()
	velocity.x = lerp(velocity.x,direction.x * speed, ACCEL*delta)
	velocity.z = lerp(velocity.z,direction.z * speed, ACCEL*delta)

	sprinting = Input.is_action_pressed("sprint")
	$Camera.fov = lerp($Camera.fov, 82.0 if sprinting and velocity.length() > 6 else 75.0, ACCEL*delta)
	
	move_and_slide()
	
func _process(delta: float) -> void:
	interact_check()
	food -= 1.25*delta if sprinting else 0.5*delta
	hp -= 10.0*delta

func interact_check():
	if not $Camera/RayCast3D.is_colliding():
		interact_with = null
		return
	if $Camera/RayCast3D.get_collider().has_method("interact") or $Camera/RayCast3D.get_collider().is_in_group("interact"):
		interact_with = $Camera/RayCast3D.get_collider().get_parent().get_parent()
	else:
		interact_with = null

func _unhandled_input(event: InputEvent) -> void:
	if event is InputEventMouseMotion and Input.mouse_mode == Input.MOUSE_MODE_CAPTURED:
		rotation_degrees.y -= event.relative.x * SENSITIVITY
		$Camera.rotation_degrees.x -= event.relative.y * SENSITIVITY
		$Camera.rotation_degrees.x = clamp($Camera.rotation_degrees.x, -89, 89)
	if event is InputEventMouseButton:
		Input.mouse_mode = Input.MOUSE_MODE_CAPTURED
	if event.is_action_pressed("ui_cancel"):
		Input.mouse_mode = Input.MOUSE_MODE_VISIBLE
	if event.is_action_pressed("interact"):
		if interact_with:
			interact_with.interact(self)

func kill():
	$AnimationPlayer.play("dead")
	set_physics_process(false)
	set_process(false)
