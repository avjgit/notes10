import media
import fresh_tomatoes

terminator = media.Movie("Terminator", "Arnold going places", "http://cdn.emgn.com/wp-content/uploads/2015/07/JyTCM.jpg", "https://www.youtube.com/watch?v=c4Jo8QoOTQ4")

print media.Movie.valid_ratings
print media.Movie.__doc__
print media.Movie.__name__
print media.Movie.__module__

#print terminator.story
#terminator.show_trailer()
#movies = [terminator]
#fresh_tomatoes.open_movies_page(movies)