EXTERNAL setParallaxSpeed(speed)
EXTERNAL playAnimation(target, animationName)
EXTERNAL playAnimationDelayed(target, animationName, delay)
EXTERNAL clearAllLines()
EXTERNAL autoPassLine(delay)
EXTERNAL waitForAnimationEnd()
EXTERNAL waitForSeconds(time)

~ setParallaxSpeed(7)

// Debug
//-> Debug_SkipIntro
//-> Debug_BeetleEncounter

// Release start
-> Day1

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
I’ll always remember her feathers shimmering…
The morning dew, like a million diamonds…
~ playAnimation("plover", "Plover_Run_Surprise")
~ playAnimationDelayed("plover", "Plover_Run", 1.0)
Wait! Does she even know my name?
Oh boy….
~ waitForSeconds(5.0)

Ok that’s it, I'm bored.
~ waitForSeconds(3.0)

Wait.<br/>Is that cloud looking at me? 
I swear it is!<br/>I’m sure it’s the boys. 
~ playAnimation("plover", "Plover_Run_Fast_B")
~ playAnimation("scene", "Scene_Plover_Forward")
~ setParallaxSpeed(7)
I knew they<br/>wouldn’t take my word!
~ waitForSeconds(3.0)
-> Day1.Beetle_Encounter

= Beetle_Encounter
~ playAnimation("scene", "Scene_Beetle_Entry")
~ waitForAnimationEnd()
~ playAnimation("plover", "Plover_Run")
~ waitForSeconds(2.0)
Hey you!
Hey you! #beetle
~ clearAllLines()
~ playAnimation("plover", "Plover_Eye_Top_R")
What’s that ball you are pushing?
Nothing #beetle

~ clearAllLines()
~ playAnimation("plover", "Plover_Eye_Bot_L")
What’s that smell?
What are you running from? #beetle

~ clearAllLines()
~ playAnimation("plover", "Plover_Eye_Top_R")
~ autoPassLine(0.4)
-Is that d…
You know running away is not a solution to anything right? #beetle
~ clearAllLines()
~ playAnimation("plover", "Plover_Run")
Unless there’s a fire i guess #beetle
Or like, #beetle
There’s a meteor or some giant tower falling #beetle
You know… #beetle

~ clearAllLines()
~ playAnimation("plover", "Plover_Eye_Top_R")
Actually, I’m “not” running “from” anything
~ playAnimation("plover", "Plover_Run")
If anything, <br/>I’m running “for” something
~ clearAllLines()
Who you’re banging? #beetle
~ playAnimation("plover", "Plover_Run_Surprise")
~ playAnimationDelayed("plover", "Plover_Run", 1.0)
What? No it’s not…
~ clearAllLines()
What’s her name? #beetle
No! I told you that’s not…
~ clearAllLines()
Oh I see, what’s his name then? #beetle
~ clearAllLines()
~ playAnimation("plover", "Plover_Eye_Top_R")
~ waitForSeconds(2.0)
Ok ok, It’s to impress a lady…<br/>Her name is not important
She probably won’t even remember me.
~ playAnimation("plover", "Plover_Eye_Bot_L")
I’m not much to be remembered for anyway
All the other plovers have smooth silky feathers
All the boys are builts like friggin frigates
~ playAnimation("plover", "Plover_Run_Cry")
I’m like a deflating dinghy
~ playAnimation("plover", "Plover_Run_Angry")
But i’ll prove them all i’m good at something
~ playAnimation("plover", "Plover_Run")
I’m no good flyer but I can run!
Why should it matters anyway
Noone is flying at the beach! 
They’re all running around like headless chicken

~ clearAllLines()
D-Wow, Everybody has to live with some shit, #beetle
Rolling it, polishing it,<br/>pushing it #beetle
But man.. That’s some baggage you’re carrying #beetle

~ clearAllLines()
~ playAnimation("plover", "Plover_Run_Cry")
Sorry
It’s ok. I know a thing or two about having to live with shit. #beetle
~ clearAllLines()
But you can’t let it<br/>drag you down. #beetle
You gotta roll with it. #beetle
~ playAnimation("plover", "Plover_Run")
I makes you stronger you know #beetle

~ clearAllLines()
~ playAnimation("plover", "Plover_Eye_Top_R")
-Wait…
~ autoPassLine(0.4)
is that actual dung you’re pushi…
    
Then, #beetle
~ clearAllLines()
~ playAnimation("plover", "Plover_Run")
when you sorted all that shit and kept it together for a while #beetle
That becomes an asset<br/>you know! #beetle
If shit ain’t worth shit,<br/>why pushing through #beetle
Why keep going? #beetle

~ clearAllLines()
~ waitForSeconds(2.0)
I’m not sure I understand
Oh I’m sure you do! Look,<br/>you’re running faster already #beetle
~ clearAllLines()
~ playAnimation("scene", "Scene_Beetle_Exit")
Can’t keep up.<br/>Go on, smash it! #beetle
Oh! I almost forgot<br/>the most important thing #beetle
When you see her,<br/>you gotta tell her… #beetle

~ clearAllLines()
-Tell her what?<br/>Damn, he’s too far
I can’t slow down,<br/>I will lose my pace.
~ playAnimation("plover", "Plover_Eye_Top_R")
What an insightful creature. 
~ playAnimation("plover", "Plover_Run_Surprise")
~ playAnimationDelayed("plover", "Plover_Run", 1.0)
Wait?..

-> End

=== End ===
TO BE CONTINUED
-> END

// Debug
=== Debug_SkipIntro ===
~ playAnimation("scene", "Scene_Skip_Intro")
ready?
-> Day1.Past_Title

=== Debug_BeetleEncounter ===
~ playAnimation("plover", "Plover_Run_Fast_B")
ready?
-> Day1.Beetle_Encounter