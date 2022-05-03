extends RigidBody2D

onready var parent = get_parent()
onready var vpSize = parent.get_viewport_rect().size
onready var ballRadius = 5
const MAX_SPEED = 500
const BASE_SPEED = 250
const SPEED_INC = 25

onready var currSpeed = BASE_SPEED

func _ready():
    set_linear_velocity(Vector2(currSpeed, currSpeed))
    pass 


func _process(delta):
    check_wall_collision()
    set_linear_velocity(Vector2(currSpeed, currSpeed))
    pass
    
func check_wall_collision():
    if position.x + ballRadius <= 0:
        set_linear_velocity(linear_velocity * -1)
    elif position.x - ballRadius >= vpSize.x:
        set_linear_velocity(linear_velocity * -1)
    
    if position.y + ballRadius <= 0:
        set_linear_velocity(linear_velocity * -1)
    elif position.y - ballRadius >= vpSize.y:
        print_debug("DED")
    pass

func set_linear_velocity(lv : Vector2):
    linear_velocity = lv
    pass
