module Tests
open Xunit
open FsUnit.Xunit
        let eight = """
 _ 
|_|
|_|

"""
        let ``one through nine`` = """
    _  _     _  _  _  _  _ 
  | _| _||_||_ |_   ||_||_|
  ||_  _|  | _||_|  ||_| _|
                           
                """

        [<Fact>]
        let public ``Can decode single digit`` () =
            eight |> Ocr.decode |> should equal "8"
        
        [<Fact>]
        let public ``Can decode 1 through 9`` () =  
           ``one through nine`` |> Ocr.decode |> should equal "123456789"


