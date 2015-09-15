class Parent():
	def __init__(self, last_name, eye_color):
		print("Parent ctor called")
		self.last_name = last_name;
		self.eye_color = eye_color;

	def show_info(self):
		print("Last name is " + self.last_name)

class Child(Parent):
	def __init__(self, last_name, eye_color, number_of_toys):
		print("Child ctor called")
		Parent.__init__(self, last_name, eye_color)
		self.number_of_toys = number_of_toys

a_men = Parent("Mr. Smith", "blue")		
print a_men.last_name

a_son = Child("Smith Jr.", "blue", 5)
print a_son.last_name
print a_son.show_info()