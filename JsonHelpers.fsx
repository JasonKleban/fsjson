#load "JsonParser.fsx"

open JsonParser

type 'a js =
    | Undefined
    | Null
    | Value of 'a

let readString field (values : Map<string, JValue>) = 
    match values.TryFind field with 
    | Some (JString t) -> Value t 
    // | Some (JNumber t) -> Value ... to string
    | Some (JNull) -> Null
    | _ -> Undefined

let readNumber field (values : Map<string, JValue>) = 
    match values.TryFind field with 
    | Some (JNumber t) -> Value t 
    // | Some (JString t) -> Value ... parse
    | Some (JNull) -> Null
    | _ -> Undefined

let readBoolean field (values : Map<string, JValue>) = 
    match values.TryFind field with 
    | Some (JBool t) -> Value t 
    | Some (JNull) -> Null
    | _ -> Undefined

let readObject<'a> field (read : JValue -> 'a js) (values : Map<string, JValue>) = 
    match values.TryFind field with 
    | Some x -> read x
    | _ -> Undefined

let readArray field (values : Map<string, JValue>) = 
    match values.TryFind field with 
    | Some (JObject t) -> Value t 
    | Some (JNull) -> Null
    | _ -> Undefined