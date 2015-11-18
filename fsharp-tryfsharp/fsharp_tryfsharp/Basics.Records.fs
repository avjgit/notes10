module Basic.Records

// records
type Book = {
    Title: string;
    Author: string;
    Rating: float;
    ISBN: string
}

let aBook = {
    Title = "sample";
    Author = "king";
    Rating = 8.8;
    ISBN = "123123"
}

printfn "the books has %f rating" aBook.Rating

// aBook.Title <- "new one" //err

// new instance
let partTwo = {aBook with Title = "second part"}

printfn "now %s issued" partTwo.Title

// duplicate labels
type VHS =
  { Title: string;
    Author: string;
    Rating: string; // Videos use a different rating system.
    ISBN: string }

let theFSharpQuizBook = 
  { Title = "The F# Quiz Book";
    Author = "William Flash";
    // this results in error, as Rating from VHS taken
    // Rating = 5; 
    // this is ok
    Book.Rating = 5.1;
    ISBN = "1234123412" }

// optional types; ented with None or Some
type NewBook =
  { Name: string;
    AuthorName: string;
    Rating: int option; //<-
    ISBN: string }

let unratedEdition = 
  { Name = "Expert F#";
    AuthorName = "Don Syme, Adam Granicz, Antonio Cisternino";
    Rating = None;
    ISBN = "1590598504" }

let stingyReview = 
  { Name = "Expert F#";
    AuthorName = "Don Syme, Adam Granicz, Antonio Cisternino";
    Rating = Some 1;
    ISBN = "1590598504" }

let printRating book =
    match book.Rating with
    | Some rating ->
        printfn "%s has %d rating" book.Name rating
    | None ->
        printfn "%s is not rated" book.Name

printRating unratedEdition
printRating stingyReview   

// discriminated unions (enums?)
type PowerUp =
| FireFlower
| Mushroom 
| Star

let up = Star

match up with
| FireFlower -> printfn "hot one"
| Mushroom -> printfn "mush"
| Star -> printfn "shines"

// more complicated
type MushroomColor =
| Red
| Green
| Yellow

type NewPowerUp =
| FireFlower
| Mushroom of MushroomColor
| Star of int

let newup = Star 8

let handlePowerUp theUp =
    match theUp with
    | FireFlower -> printfn "hot one"
    | Mushroom color -> match color with
                        | Red -> printfn "red mush"
                        | Green -> printfn "a green one"
                        | Yellow -> printfn "yellow"
    | Star stars -> printfn "%d stars shining" stars

handlePowerUp newup