module Program

       

[<EntryPoint>]
let main argv = 
    printfn "%s" (Ocr.decode(Tests.``one through nine``)) 
    System.Console.ReadLine() |> ignore
    0 
