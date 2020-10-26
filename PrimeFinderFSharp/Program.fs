(*
 A program to find all prime integers between 1 and N.

 The basic algorithm works like this:
 for each number (num) from 2 to n:
    find the smallest number in the list and remove it; this is a prime number
    remove all numbers in the list divisible by that smallest prime number
*)

open System

(* 
 Function to filter a list of numbers for prime numbers. 
 Input list numList must start at 2 and be monotonically increasing.
 Basically input must be [2..n].
*)
let rec findPrimes numList primeList =
    match numList with
    | head::tail ->
        let newList = List.filter (fun x -> x % head <> 0L) tail
        findPrimes newList (head::primeList)
    | [] -> List.rev primeList

(* Function to read an int64 from stdin. *)
let rec readLongFromStdin() = 
    let v = Console.ReadLine()
    try
        let longVal =  v |> int64

        if longVal < 2L then
            printfn "Invalid integer: %d" longVal
            readLongFromStdin()
        else
            longVal
    with 
    | _ -> 
        printfn "Invalid input: \"%s\"" v
        readLongFromStdin()

[<EntryPoint>]
let main argv =
    printfn "This is a program to find all primes from 1 to N."
    printfn "Please enter a number: "
    let value = readLongFromStdin()
    //let primeList = getPrimes 2L value []
    let primeList = findPrimes [2L..value] []
    printfn "The prime numbers between 1 and %d are:" value
    List.iter (fun x -> printfn "%d" x) primeList
    0