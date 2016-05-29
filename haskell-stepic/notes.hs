module Test where
	import Data.Char
	--------------------------------------------- 1.2 Functions
	sayHi = putStrLn "Hi there world"
	sumOfSquares a b = a^2 + b^2
	lenVec3 x y z =  sqrt (x^2 + y^2 + z^2)
	condTest x = if x > 0 then 1 else (-1)
	sign1 x = if x > 0 then 1 else (if x < 0 then (-1) else 0)
	sign2 x = if x >= 0 then (if x > 0 then 1 else 0) else (-1)
	max5 x = max 5 x
	max5' = max 5
	discount limit proc sum = if sum >= limit then sum*(100-proc)/100 else sum
	standardDiscount = discount 1000 5
	--------------------------------------------- 1.3 Operators
	maxInside a b = a `max` b
	operatorPrefixed a b = (+) a b
	--declaring new operator (*+*) 
	infixl 6 *+*
	--and defining as sum of squares
	--usage: 3 *+* 4 -> 25 
	a *+* b = a^2 + b^2
	infixl 6 |-|
	x |-| y = if x-y>0 then x-y else -(x-y)
	--------------------------------------------- 1.4 Base types
	test = isDigit '7'
	-- tuples: can be of misc. types: (3, True); fst, snd
	-- lists: should be of same type: [1, 3, 8]
	str = 'H' : "ello" -- ":" means "add to head"; calling "str" will output "Hello"
	str2 = str ++ " there" -- concatenation
	--------------------------------------------- 1.5 Recursion
	factorial n = if n == 0 then 1 else n * factorial'(n-1)

	factorial' 0 = 1
	factorial' n = n * factorial (n-1)

	factorial'' 0 = 1
	factorial'' n = if n < 0 then error "arg must be >= 0" else n * factorial'' (n-1)

	factorial''' 0 = 1
	factorial''' n | n < 0 = error "arg must be >= 0" 
				   | n > 0 = n * factorial''' (n-1)

	factorial4 :: Integer -> Integer
	factorial4 n | n == 0 = 1
				 | n > 0 = n * factorial4 (n-1)
				 | otherwise = error "arg must be >= 0" 

	factorial5 n | n >= 0 = helper 1 n
				 | otherwise = error "arg must be >= 0" 

	helper acc 0 = acc
	helper acc n = helper (acc*n) (n-1)
	--------------------------------------------- 1.6 Bindings
	--------------------------------------------- 2.1 Polymorphism
	import Data.Function

	multSecond = g `on` h

	g = (*)

	h tuple = snd tuple
