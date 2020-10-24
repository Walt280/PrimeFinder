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

(* Function to print out the list of primes. *)
let rec printPrimeList list =
    match list with
    | head::tail -> 
        printfn "%d" head
        printPrimeList tail
    | [] -> ()

(* 
 Function to check if number is prime, based on a list of primes.
 numSqrt used to reduce amount of division done.
*)
let rec isPrime number numSqrt primeList = 
    match primeList with
    | head :: tail ->
        if numSqrt < head then
            true
        else if number % head = 0L then
            false
        else
            isPrime number numSqrt tail
    | [] -> true

(* Function to get a list of prime numbers. *)
let rec getPrimes current upperBound primeList =
    if current > upperBound then
        primeList
    else
        let sq = current |> double |> sqrt |> ceil |> int64
        let isCurrentPrime = isPrime current sq primeList
        match isCurrentPrime with
        | true -> getPrimes (current + 1L) upperBound (current::primeList)
        | false -> getPrimes (current + 1L) upperBound primeList

(* Function to read an int64 from stdin. *)
let rec readLongFromStdin() = 
    let v = Console.ReadLine()
    try
        let longVal =  v |> int64

        if longVal < 1L then
            printfn "Invalid integer: %d" longVal
            readLongFromStdin()
        else
            Some longVal
    with 
    | :? System.FormatException -> 
        printfn "Invalid input: \"%s\"" v
        readLongFromStdin()
    | _ -> None

[<EntryPoint>]
let main argv =
    printfn "This is a program to find all primes from 1 to N."
    printfn "Please enter a number: "
    let value = readLongFromStdin()
    match value with
    | Some n ->
        let primeList = getPrimes 2L n []
        printfn "The prime numbers between 1 and %d are:" n
        primeList |> List.rev |> printPrimeList
        0
    | None ->
        printfn "An error has occured."
        -1
