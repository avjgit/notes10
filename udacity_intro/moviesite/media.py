import webbrowser

class Movie():
	"""the class for movies"""

	valid_ratings = ["G", "PG", "PG-13", "R"]

	def __init__ (self, title, storyline, poster_image_url, trailer_youtube_url):
		self.title = title
		self.storyline = storyline
		self.poster_image_url = poster_image_url
		self.trailer_youtube_url = trailer_youtube_url

	def show_trailer(self):
		webbrowser.open(self.trailer_youtube_url)