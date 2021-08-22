// Stuff
EXTERNAL fadeScreen(beginColor, endColor, fadeTime)

// Objects
EXTERNAL spawnObject(objectType, objectName, side, layer)
EXTERNAL setObjectRelativeSpeed(objectName, relativeSpeed)
EXTERNAL waitUntilObjectPosition(objectName, position)
EXTERNAL waitUntilObjectOutOfScreen(objectName)

/*nop
~ fadeScreen(0xFFFFFFFF, 0xFFFFFF00, 1.0)
nop
~ spawnObject("title", "left", 2)
~ setObjectRelativeSpeed("title", -1.0)
~ waitUntilObjectPosition("title", 0.5)
//~ waitUntilObjectOutOfScreen("title")
nop*/
