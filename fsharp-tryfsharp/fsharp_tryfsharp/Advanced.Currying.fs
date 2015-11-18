module Advanced.Currying

let add x y = x + y
printfn "%d" (add 3 4)
// val add : x:int -> y:int -> int, which can be read as 
// "add is a function that, given an integer, 
// returns a function which given an integer returns an integer"
// proof:

let savedAddTen x = add 10 x
printfn "%d" (savedAddTen 2)

let curried = add 5
printfn "%d" (curried 7)
// led to same 12!

// specialized filters
let searchEven = Seq.filter(fun x -> x % 2 = 0)

printfn "there are %d even numbers from 1 to 100"
    ([1 .. 100] |> searchEven |> Seq.length )

printfn "there are %d even numbers from 1 to 1000"
    ([1 .. 1000] |> searchEven |> Seq.length )

// sub function
let sub x y = x - y
// imagine we need to use to fix subtracted
// trick: swap arguments
let swapargs f x y = f y x
// now, can use it:
let dec = swapargs sub 1
printfn "before 10 there is %d" (dec 10)   

