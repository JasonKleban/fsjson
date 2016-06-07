
let example2 = """{"widget": {
    "debug": "on",
    "window": {
        "title": "Sample Konfabulator Widget",
        "name": "main_window",
        "width": 500
    },
    "image": { 
        "src": "Images/Sun.png",
        "name": "sun1",
        "hOffset": 250,
        "vOffset": 250,
        "alignment": "center"
    },
    "text": {
        "data": "Click Here",
        "size": 36,
        "name": "text1",
        "hOffset": null,
        "vOffset": 100,
        "alignment": null,
        "onMouseUp": "sun1.opacity = (sun1.opacity / 100) * 90;"
    }
}}  """