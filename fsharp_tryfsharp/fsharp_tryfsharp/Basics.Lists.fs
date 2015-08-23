module Basics.Lists

let evens = [2;4;6;8]
let firstHundred = [0..100]
let doubled = List.map (fun x -> x * 2) firstHundred

let filtered = 
    List.map (fun x -> x * 2)
        (List.filter (fun x -> x % 2 = 0) firstHundred)

// pipes!
// converts this:
List.sum(
    List.map (fun x -> x * 2)
        (List.filter (fun x -> x % 2 = 0) firstHundred))
// to that:
[0..100]
|> List.filter (fun x -> x % 2 = 0)
|> List.map (fun x -> x * 2)
|> List.sum

//"Date,Open,High,Low,Close,Volume,Adj Close"
let stockData =
    [ 
      "2012-03-30,32.40,32.41,32.04,32.26,31749400,32.26";
      "2012-03-29,32.06,32.19,31.81,32.99,37038500,32.99";
      "2012-03-28,32.52,32.70,32.04,32.19,41344800,32.19";]

let splitComas (x:string) =
    x.Split([|','|]) //[||] = "to Array"!

stockData
    |> List.map splitComas
    |> List.maxBy (fun x -> abs(float x.[1] - float x.[4]))
    |> (fun x -> x.[0])
