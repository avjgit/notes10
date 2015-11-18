﻿module Basics.Functions

let add x y = x + y 
//add 3 4 //This expression should have type 'unit', but has type 'int'. Use 'ignore' to discard the result of the expression, or 'let' to bind the result to a name.	
let res = add 3 4
//printfn res //The type 'int' is not compatible with the type 'Printf.TextWriterFormat<'a>'	
//printfn res.ToString() //Successive arguments should be separated by spaces or tupled, and arguments involving function or method applications should be parenthesized	
//printfn (res.ToString()) //The type 'string' is not compatible with the type 'Printf.TextWriterFormat<'a>'
printfn "%s" (res.ToString()) //only now!

// type annotations
// error FS0072: Lookup on object of indeterminate type based on information prior to this program point. 
// A type annotation may be needed prior to this program point to constrain the type of the object. 
// This may allow the lookup to be resolved.
let toGeek (text: string) = 
    text.Replace('o', '0').Replace('t', '7')

printfn "%s" (toGeek "asdfoot")

let rec factorial n =
    if n < 2 then 1
    else n * factorial(n - 1)

factorial 30

// functions inside
let quadruple x =
    let double x =
        x * x

    double(double(x))

quadruple 4

// higher order function
// function as an argument to another function!
let karlTest test =
    test "Karl"

let isItKarl x =
    if x = "Karl" then
        "it is Karl"
    else
        "it is not Karl"

karlTest isItKarl

// lambda (= anonymous function = just a function without a name)
let addAsLambda = (fun x y -> x + y)
add 2 33

let twoTest test =
    test 2

twoTest (fun x -> x < 0)
