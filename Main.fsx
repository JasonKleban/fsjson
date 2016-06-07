#load "ParserLibrary.fsx"
#load "JsonParser.fsx"
#load "JsonHelpers.fsx"
#load "ExampleData.fsx"
#load "Models.fsx"

open ParserLibrary
open JsonParser
open JsonHelpers
open ExampleData
open Models

type RequiredOrOptional<'a> =
    | Required of (JValue -> 'a js)
    | Optional of (JValue -> 'a js)

// type JsBuilder() =
//     member this.Bind(x, f) = 
//         match x with
//         | Required accessor ->
//             match accessor
//         | Undefined -> false
//         | Null -> true
//         | Value a -> f a
//     member this.Return(x) = 
//         match x with
//         | None -> Null
//         | Some a -> Value a
   
// let explore = new JsBuilder()

match run jValue example2 with
| Success (parsed, _) -> 
    let root = 
        match Root.read parsed with
        | Value r -> r
        | _ -> failwith "expected a root object"

    // here we have the model built with undefined differentiated from null
    
    //root.widget

    root
| Failure (label, error, _) -> failwith (sprintf "%s : %s" label error)