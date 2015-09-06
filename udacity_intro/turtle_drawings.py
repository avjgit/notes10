import turtle

def draw_square():
	window = turtle.Screen()
	window.bgcolor("red")

	t = turtle.Turtle()
	t.shape("turtle")
	t.color("yellow")
	t.speed(1)

	for i in range(1,5):
		t.forward(100)
		t.right(90)

	window.exitonclick()

draw_square()