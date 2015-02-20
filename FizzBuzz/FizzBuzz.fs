module FizzBuzz
    let fizzBuzz = function 
        | n when (n % 3 = 0) && (n % 5 = 0) -> "FizzBuzz"
        | n when (n % 3 = 0)                -> "Fizz"
        | n when (n % 5 = 0)                -> "Buzz"
        | n                                 -> n.ToString()
    
    let executeFixxBuzz () = 
        [1..100]
            |> List.map fizzBuzz
            |> List.iter (fun s -> printfn "%s" s)