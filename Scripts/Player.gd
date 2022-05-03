extends RigidBody2D

const SPEED = 400

# Called when the node enters the scene tree for the first time.
func _ready():
    pass
    

# Physics
func _process(delta):
    get_input(delta)
    pass


func get_input(delta):
    var moveL : bool = false
    var moveR : bool = false
    if Input.is_key_pressed(KEY_A):
        linear_velocity.x = -SPEED
        moveL = true
    if Input.is_key_pressed(KEY_D):
        linear_velocity.x = SPEED
        moveR = true
    if not(moveL or moveR) or (moveL and moveR):
        linear_velocity.x = 0
    pass
