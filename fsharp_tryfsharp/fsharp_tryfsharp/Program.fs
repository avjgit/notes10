let lucky = 3 + 4
let unlucky = lucky + 6

let someval = "original"
//let someval = "new" //err: Program.fs(5,5): error FS0037: Duplicate definition of value 'someval'

let mutable modval = "old"
modval <- "new"
System.Console.WriteLine("now value is " + modval)

//"With F#, you get the readability benefits of a dynamic language 
//with the robustness of a statically typed language."
let anInt = 3
let aFloat = 3.14
let aStrgin = "hi there"

printfn "hi hi hi"
printfn "the answer is %d" 42
//printfn "the answer is %d" "really?"
