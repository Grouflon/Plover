EXTERNAL setParallaxSpeed(speed)
EXTERNAL setDayTime(dayTimeName) // either "day" or "night"
EXTERNAL playAnimation(target, animationName)
EXTERNAL playAnimationDelayed(target, animationName, delay)
EXTERNAL setHorizontalPosition(target, position)
EXTERNAL clearAllLines()
EXTERNAL autoPassLine(delay)
EXTERNAL waitForAnimationEnd(target)
EXTERNAL waitForSeconds(time)

~ setDayTime("day")
~ setParallaxSpeed(7)

// Debug
//-> Day1.PastTitle
//-> Day1.BeetleEncounter
//-> Day1.EndOfDay
//-> Night1.AfterTransition
//-> Night1.EndOfNight
//-> Day2

// Release start
-> Day1

=== Day1 ===
~ playAnimation("scene", "Scene_Intro")
~ waitForAnimationEnd("scene")
Press any key or button
~ playAnimation("scene", "Scene_Plover_Entry")
~ waitForAnimationEnd("scene")
-> Day1.PastTitle

= PastTitle
~ setHorizontalPosition("plover", 2.5)
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
~ waitForSeconds(4.0)

Ok that’s it, I'm bored.
~ waitForSeconds(2.0)

Wait.<br/>Is that cloud looking at me? 
I swear it is!<br/>I’m sure it’s the boys. 
~ playAnimation("plover", "Plover_Run_Fast_B")
~ playAnimation("scene", "Scene_Plover_Forward")
~ setParallaxSpeed(7)
I knew they<br/>wouldn’t take my word!
~ waitForSeconds(3.0)
-> Day1.BeetleEncounter

= BeetleEncounter
~ setParallaxSpeed(7)
~ setHorizontalPosition("plover", 2.5)
~ playAnimation("plover", "Plover_Run_Fast_B")
~ playAnimation("scene", "Scene_Beetle_Entry")
~ waitForAnimationEnd("scene")
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
But I’ll prove them all I’m good at something
~ playAnimation("plover", "Plover_Run")
I’m no good flyer but I can run!
Why should it matters anyway
No one is flying at the beach! 
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
~ waitForSeconds(1.0)
-Tell her what?<br/>Damn, he’s too far
I can’t slow down,<br/>I will lose my pace.
~ playAnimation("plover", "Plover_Eye_Top_R")
What an insightful creature. 
~ playAnimation("plover", "Plover_Run_Surprise")
~ playAnimationDelayed("plover", "Plover_Run", 1.0)
~ waitForSeconds(1.5)
-> Day1.EndOfDay

= EndOfDay
~ setHorizontalPosition("plover", 2.5)
~ playAnimation("plover", "Plover_Run")
Wait?…
~ waitForSeconds(1.2)
-> Night1

=== Night1 ===
~ clearAllLines()
~ playAnimation("scene", "Scene_ToNight1")
~ waitForAnimationEnd("scene")
-> Night1.AfterTransition

= AfterTransition
~ setParallaxSpeed(0)
~ setDayTime("night")
~ setHorizontalPosition("plover", 2.5)
~ playAnimation("plover", "Plover_Idle_Long")
Oh boy what a day!
~ waitForSeconds(0.5)
~ playAnimation("plover", "Plover_Idle_Poop")
~ playAnimationDelayed("plover", "Plover_Idle_Short", 2.0)
~ waitForSeconds(4.0)
~ playAnimation("plover", "Plover_Idle_Stargazing")
I never realized how beautiful night sky can be
Cool breeze..
~ playAnimation("plover", "Plover_Idle_Shout_Shy")
Soothing crickets melody…
~ clearAllLines()
~ waitForSeconds(2.0)
~ playAnimation("plover", "Plover_Idle_Short")
Thanks pal! #crickets
~ clearAllLines()
~ playAnimation("plover", "Plover_Idle_Surprise")
~ playAnimationDelayed("plover", "Plover_Idle_Short", 0.4)
What?! 
~ playAnimation("plover", "Plover_Idle_Stargazing")
Glimmering stars…
~ playAnimation("plover", "Plover_Idle_Long")
~ waitForSeconds(2.5)
-> EndOfNight

= EndOfNight
~ setParallaxSpeed(0)
~ setDayTime("night")
~ setHorizontalPosition("plover", 2.5)
~ playAnimation("plover", "Plover_Idle_Romantic")
I wish she was by my side.
~ clearAllLines()
~ playAnimation("plover", "Plover_Idle_Long")
~ waitForSeconds(2.5)
~ playAnimation("plover", "Plover_Idle_GoingSleep")
~ waitForAnimationEnd("plover")
~ playAnimation("plover", "Plover_Idle_Sleep")
~ waitForSeconds(1.5)
~ playAnimation("scene", "Scene_ToDay2")
~ waitForAnimationEnd("scene")
-> Day2

=== Day2 ===
~ setParallaxSpeed(7)
~ setDayTime("day")
~ setHorizontalPosition("plover", 2.5)
~ playAnimation("plover", "Plover_Run")
Here we go again.
Second day, out of… Oh dang…
~ playAnimation("plover", "Plover_Eye_Top_R")
~ clearAllLines()
~ waitForSeconds(1.0)
Why am I doing this again?
~ clearAllLines()
~ waitForSeconds(3.0)
~ playAnimation("plover", "Plover_Run")
I’m sooo tired! I had the strangest dream
~ playAnimation("plover", "Plover_Eye_Bot_L")
I was just a little plover<br/>straight out of the nest
~ playAnimation("plover", "Plover_Eye_Top_R")
Out to meet the others for the first time!
~ playAnimation("plover", "Plover_Eye_Bot_L")
Except…
I…
was wearing…
~ playAnimation("plover", "Plover_Run_Surprise")
~ playAnimationDelayed("plover", "Plover_Run", 1.0)
PANTS!!
~ playAnimation("plover", "Plover_Run_Cry")
They were all laughing…
I tried to run away but I tripped over.
~ playAnimation("plover", "Plover_Run_Surprise")
~ playAnimationDelayed("plover", "Plover_Run_Sweaty", 1.0)
Because I also had SHOES!
Oh boy.. What a night.. 
~ playAnimation("plover", "Plover_Run")

-> End


=== End ===
TO BE CONTINUED
-> END
