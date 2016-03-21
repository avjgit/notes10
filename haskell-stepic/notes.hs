module Test where
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
	maxInside a b = a `max` b
	operatorPrefixed a b = (+) a b
	--declaring new operator (*+*) 
	infixl 6 *+*
	--and defining as sum of squares
	--usage: 3 *+* 4 -> 25 
	a *+* b = a^2 + b^2
	infixl 6 |-|
	x |-| y = if x-y>0 then x-y else -(x-y)