#load "JsonParser.fsx"
#load "JsonHelpers.fsx"

open JsonParser
open JsonHelpers

type Window = {
    title : string js
    name : string js
    width : float js
    height : float js 
} with 
    static member read = function 
        | JObject values -> 
            Value {
                title = readString "title" values
                name = readString "name" values
                width = readNumber "width" values
                height = readNumber "height" values
            }
        | JNull -> Null
        | _ -> failwith "expected a Window"

type Image = {
    src : string js
    name : string js
    hOffset : float js
    vOffset : float js
    alignment : string js
} with 
    static member read = function 
        | JObject values -> 
            Value {
                src = readString "src" values
                name = readString "name" values
                hOffset = readNumber "hOffset" values
                vOffset = readNumber "vOffset" values
                alignment = readString "alignment" values
            }
        | JNull -> Null
        | _ -> failwith "expected an Image"

type Text = {
    data : string js
    size : float js
    style : string js
    name : string js
    hOffset : float js
    vOffset : float js
    alignment : string js
    onMouseUp : string js
} with 
    static member read = function 
        | JObject values -> 
            Value {
                data = readString "data" values
                size = readNumber "size" values
                style = readString "style" values
                name = readString "name" values
                hOffset = readNumber "hOffset" values
                vOffset = readNumber "vOffset" values
                alignment = readString "alignment" values
                onMouseUp = readString "onMouseUp" values
            }
        | JNull -> Null
        | _ -> failwith "expected a Text"

type Widget = {
    debug : string js
    window : Window js
    image : Image js
    text : Text js
} with 
    static member read = function 
        | JObject values -> 
            Value {
                debug = readString "debug" values
                window = readObject "window" Window.read values
                image = readObject "image" Image.read values
                text = readObject "text" Text.read values
            }
        | JNull -> Null
        | _ -> failwith "expected a Widget"

type Root = {
    widget : Widget js
} with 
    static member read = function 
        | JObject values -> 
            Value {
                widget = readObject "widget" Widget.read values
            }
        | JNull -> Null
        | _ -> failwith "expected a root object"