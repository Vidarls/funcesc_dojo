module Ocr
    let segments = [(0,1,1);(1,0,2);(1,1,4);(1,2,8);(2,0,16);(2,1,32);(2,2,64)]
    
    let splitty (s:string) = 
        s.Split([|System.Environment.NewLine|], System.StringSplitOptions.RemoveEmptyEntries)
        |> Array.map (fun s -> s.ToCharArray())
            
    let toBit c = c <> ' '

    let toByte (data: char[][]) position = 
        let positionOffset = position * 3
        segments |> List.map (fun (line,offset,value) -> if data.[line].[offset + positionOffset] |> toBit then value else 0)
        |> List.reduce (fun acc elem -> acc ||| elem) 

    let toNumericString (values : Map<int,string>) b = 
        match values.TryFind(b) with
        | Some(value) -> value
        | None        -> "X"

    let train ()  = 
        let trainingSequence = """
 _     _  _     _  _  _  _  _ 
| |  | _| _||_||_ |_   ||_||_|
|_|  ||_  _|  | _||_|  ||_| _|
                           
""" 
        let chars = trainingSequence |> splitty
        let length = chars.[0].Length
        let numberOfDigits = length / 3
        [0..(numberOfDigits - 1)] 
        |> List.map (fun n -> (n |> toByte chars, n.ToString()))
        |> Map.ofList

    let decode s = 
        let values = train ()
        let chars = s |> splitty
        [0..((chars.[0].Length - 1) /3)] 
        |> List.map (fun n -> n |> toByte chars |> toNumericString values)
        |> List.reduce (fun acc elem -> acc + elem)