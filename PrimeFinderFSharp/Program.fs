(*
 A program to find all prime integers between 1 and N.

 The basic algorithm works like this:
 for each number (num) from 2 to n:
     find the modulo of num and all the prime numbers less than the square root of n
     if none of the prime numbers modulo with num to equal zero, than num is prime
     else num is not prime
 this is possible because composite numbers can be seen as prime numbers multiplied together
 therefore we only need to divide by prime numbers to check for primality, because all non-prime 
 numbers can be factorized into prime numbers.
 this algorithm is effectively more efficient repeated division.

 Implementation notes:
 I have tried to use as many functional features/patterns as possible to make this not a straight port 
 of the c# version.
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