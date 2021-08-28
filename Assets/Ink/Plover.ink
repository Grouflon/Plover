EXTERNAL setParallaxSpeed(speed)
EXTERNAL playAnimation(target, animationName)
EXTERNAL playAnimationDelayed(target, animationName, delay)
EXTERNAL waitForAnimationEnd()
EXTERNAL waitForSeconds(time)

~ setParallaxSpeed(7)

// Debug
-> Debug_Skip_Intro

// Release start
-> Day1

=== Debug_Skip_Intro ===
~ playAnimation("scene", "Scene_Skip_Intro")
ready?
-> Day1.Past_Title

=== Day1 ===
~ playAnimation("scene", "Scene_Intro")
~ waitForAnimationEnd()
Press any key or button
~ playAnimation("scene", "Scene_Plover_Entry")
~ waitForAnimationEnd()
-> Day1.Past_Title

= Past_Title
~ playAnimation("plover", "Plover_Run_Fast_B")
Oh boy oh boy!
Why am I even doing this?
~ setParallaxSpeed(5)
~ playAnimation("plover", "Plover_Run")
~ playAnimation("scene", "Scene_Plover_Back")
~ waitForSeconds(3.0)

What do I have to prove?
Will she even be there like she promised? 
~ waitForSeconds(2.0)

How will they even know if <br/>I cheated on the way?
It’s not like they’d leave boys along the way to check on me
~ waitForSeconds(2.0)

~ playAnimation("plover", "Plover_Run_Love")
I’ll always remember her feathers shimmering...
The morning dew, like a million diamonds…
~ playAnimation("plover", "Plover_Run_Surprise")
~ playAnimationDelayed("plover", "Plover_Run", 1.0)
Wait! Does she even know my name?
Oh boy….
~ waitForSeconds(1.5)

Ok that’s it, I'm bored.
~ waitForSeconds(4.0)

Wait. Is that cloud looking at me? 
I swear it is! I’m sure it’s the boys. 
~ playAnimation("plover", "Plover_Run_Fast_B")
~ playAnimation("scene", "Scene_Plover_Forward")
~ setParallaxSpeed(7)
I knew they wouldn’t take my word!
-> End

=== End ===
-> END
