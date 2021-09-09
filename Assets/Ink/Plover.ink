EXTERNAL setParallaxSpeed(speed)
EXTERNAL setDayTime(dayTimeName) // either "day" or "night"
EXTERNAL playAnimation(target, animationName)
EXTERNAL playAnimationDelayed(target, animationName, delay)
EXTERNAL setHorizontalPosition(target, position)
EXTERNAL clearAllLines()
EXTERNAL autoPassLine(delay)
EXTERNAL waitForAnimationEnd(target)
EXTERNAL waitForSeconds(time)

// Default state
~ setDayTime("day")
~ setParallaxSpeed(7)

// Debug
//-> Day1.PastTitle
//-> Day1.BeetleEncounter
//-> Day1.EndOfDay
//-> Night1
//-> Night1.EndOfNight
//-> Day2
//-> Day2.SnakeEncounter
//-> Day2.AfterEncounter
//-> Night2
//-> Night2.EndOfNight
-> Day3

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
Wait!<br/>Does she even know my name?
Oh boy….
~ waitForSeconds(4.0)

Ok that’s it, I'm bored
~ waitForSeconds(2.0)

Wait.<br/>Is that cloud looking at me? 
I swear it is!<br/>I’m sure it’s the boys 
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
Unless there’s a fire I guess #beetle
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
She probably won’t even remember me
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
They’re all running around like headless chickens

~ clearAllLines()
Wow, Everybody has to live with some shit #beetle
Rolling it, polishing it,<br/>pushing it #beetle
But man… That’s some baggage you’re carrying #beetle

~ clearAllLines()
~ playAnimation("plover", "Plover_Run_Cry")
Sorry
It’s ok. I know a thing or two about having to live with shit #beetle
~ clearAllLines()
But you can’t let it<br/>drag you down #beetle
You gotta roll with it #beetle
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
I can’t slow down,<br/>I will lose my pace
~ playAnimation("plover", "Plover_Eye_Top_R")
~ waitForSeconds(1.5)
What an insightful creature 
~ waitForSeconds(1.5)
-> Day1.EndOfDay

= EndOfDay
~ setHorizontalPosition("plover", 2.5)
~ playAnimation("plover", "Plover_Run_Surprise")
~ playAnimationDelayed("plover", "Plover_Run", 1.0)
Wait?…
~ waitForSeconds(1.2)
~ clearAllLines()
~ playAnimation("scene", "Scene_ToNight1")
~ waitForAnimationEnd("scene")
-> Night1

=== Night1 ===
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
Cool breeze…
~ playAnimation("plover", "Plover_Idle_Shout_Shy")
Soothing crickets melody…
~ clearAllLines()
~ waitForSeconds(2.0)
~ playAnimation("plover", "Plover_Idle_Short")
Thanks pal! #crickets
~ clearAllLines()
~ playAnimation("plover", "Plover_Idle_Surprise")
~ playAnimationDelayed("plover", "Plover_Idle_Short", 0.6)
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
I wish she was by my side
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
~ setHorizontalPosition("plover", 2.5)
~ playAnimation("plover", "Plover_Run")
Here we go again
Second day, out of…
~ clearAllLines()
~ waitForSeconds(1.5)
~ playAnimation("plover", "Plover_Eye_Top_R")
Oh dang…
Why am I doing this again?
~ clearAllLines()
~ waitForSeconds(3.0)
~ playAnimation("plover", "Plover_Run")
I’m sooo tired! I had the strangest dream
~ playAnimation("plover", "Plover_Eye_Bot_L")
I was just a little plover<br/>straight out of the nest
~ playAnimation("plover", "Plover_Eye_Top_R")
Out to meet the others<br/>for the first time!
~ playAnimation("plover", "Plover_Eye_Bot_L")
Except…
I…
was wearing…
~ playAnimation("plover", "Plover_Run_Surprise")
~ playAnimationDelayed("plover", "Plover_Run", 1.0)
PANTS!!
~ playAnimation("plover", "Plover_Run_Cry")
They were all laughing…
I tried to run away<br/>but I tripped over
~ playAnimation("plover", "Plover_Run_Surprise")
~ playAnimationDelayed("plover", "Plover_Run_Sweaty", 1.0)
Because I also had SHOES!
Oh boy… What a night…
~ playAnimation("plover", "Plover_Run")
-> Day2.SnakeEncounter

= SnakeEncounter
~ clearAllLines()
~ setHorizontalPosition("plover", 2.5)
~ playAnimation("plover", "Plover_Run")
SSssssS #snake
…
~ clearAllLines()
~ playAnimation("scene", "Scene_Snake_Entry")
~ autoPassLine(0.8)
SSssssSSSssss #snake
~ waitForSeconds(2.0)
~ playAnimation("plover", "Plover_Run_Surprise")
~ playAnimationDelayed("plover", "Plover_Run_Sweaty", 1.0)
HAAAA! What the…
SSorry… Didn’t mean to SStartle you. #snake
~ clearAllLines()
I thought I was chased by a cucumber
~ playAnimation("plover", "Plover_Run")
That’Ss not nice… #snake
~ clearAllLines()
I’m SSophie #snake
Nice SSneakers by the way #snake
~ playAnimation("plover", "Plover_Run_Surprise")
~ playAnimationDelayed("plover", "Plover_Run_Sweaty", 1.0)
-HAAAAA!
~ clearAllLines()
Why would you say<br/>something like that?
~ playAnimation("plover", "Plover_Run")
What’SS wrong? It’s because you’re SSuper Fast #snake
~ clearAllLines()
I thought you had like… #snake
Turbo running SShoes or SSomething #snake
~ clearAllLines()
Oh, Thanks 
~ playAnimation("plover", "Plover_Run_Happy")
I’m just powered by sheer plopping will!
…And that big shell<br/>I got for breakfast
~ playAnimation("plover", "Plover_Run")
You’re pretty fast too! 
SSophie<br/>The SSuper SStar SSnake! 
Wow Wow Wow!<br/>Are you making fun of me? #snake
~ clearAllLines()
Aren’t all snakes talking like…
You can’t be SSerious!<br/>Le Wow #snake
~ clearAllLines()
That’s a SSpeech impediment bozo! #snake
That’s SSo insensitive! #snake
Thanks for ruining my<br/>SSelf confidence and all #snake
~ clearAllLines()
~ playAnimation("plover", "Plover_Run_Anxious")
-Oh boy!! Sorry!!<br/>I’ve never met a snake before!
~ playAnimation("plover", "Plover_Run_Cry")
Classic me. I’m so sorry
How can I apologize?
I could eat you maybe? #snake
~ clearAllLines()
~ playAnimation("plover", "Plover_Run_Surprise")
~ playAnimationDelayed("plover", "Plover_Run_Sweaty", 1.0)
What?!!
Don’t worry, I already ate this month #snake
~ clearAllLines()
~ playAnimation("plover", "Plover_Run")
Huuuh. Lucky me?<br/>I guess…?
You can promise me<br/>one thing though #snake
~ clearAllLines()
Next time you meet SSomeone for the first time #snake
Don’t be a jerk! #snake
Bozo #snake


~ playAnimation("plover", "Plover_Eye_Bot_L")
You can be sure<br/>I'll remember that!
~ clearAllLines()
SSo, Where are you going in such a hurry? #snake
~ playAnimation("plover", "Plover_Run_Angry")
Out to face my DESTINY!
~ clearAllLines()
OoooK… That’s the SSpirit…<br/>I guess #snake
~ clearAllLines()
~ playAnimation("plover", "Plover_Run_Sweaty")
I actually made a stupid bet
I thought I had<br/>something to prove
That I ought to do something to be remembered for
~ playAnimation("plover", "Plover_Run_Anxious")
But I know<br/>that was pretty stupid
Now I'm actually eager<br/>to reach the colony
~ playAnimation("plover", "Plover_Run_Blush")
To just be myself<br/>and simply ask her out
I SSee #snake
~ clearAllLines()
~ playAnimation("plover", "Plover_Run")
If “being yourself” meant you were a jerk to me #snake
I got SSerious doubts about<br/>the whole SShebang #snake
I’m hopeless am I?
~ clearAllLines()
I don’t know what’s the deal<br/>in Plover town #snake
But in SSnake City<br/>you gotta be respectful #snake
That’s like. “THE” basic rule #snake
Then you gotta be<br/>SStraight in your SShoes #snake
Isn’t that like, a lizard<br/>rule or something?
~ clearAllLines()
HuSSh! #snake
That’s a figure of SSpeech #snake
You gotta do what<br/>you’re doing for yourself #snake
Not to Impresss<br/>Nor to SSeduce #snake
Have many birds done<br/>what you’re doing? #snake
~ playAnimation("plover", "Plover_Eye_Top_R")
I don’t think so
~ clearAllLines()
Exactly! SSo don’t Ssay<br/>that’s SStupid #snake
~ playAnimation("plover", "Plover_Run")
You’re making history #snake
If you come to enjoy the run<br/>for the run’s SSake #snake
Then people will respect you #snake
And that’s ace in SSnake city #snake

~ clearAllLines()
~ playAnimation("plover", "Plover_Run_Happy")
That’s so inspirational!
I’m so pumped up
~ clearAllLines()
~ waitForSeconds(1.0)
~ playAnimation("plover", "Plover_Run")
~ waitForSeconds(1.0)
I SShould have SStoped earlier #snake
I’m starting to get hungry #snake
~ playAnimation("plover", "Plover_Run_Surprise")
~ playAnimationDelayed("plover", "Plover_Run_Sweaty", 1.0)
~ clearAllLines()
HAAAA!
~ playAnimation("scene", "Scene_Snake_Exit")
You’d be full of lactic acid anyway #snake
~ clearAllLines()
GodSSpeed! #snake
Bozo #snake
~ clearAllLines()
~ waitForSeconds(2.5)
-> Day2.AfterEncounter

= AfterEncounter
~ setHorizontalPosition("plover", 4.0)
~ playAnimation("plover", "Plover_Run_Happy")
Wow snakes are so rad! 
I can’t wait to tell the boys about it
~ playAnimation("plover", "Plover_Run_Anxious")
No! Right… I shouldn't brag
~ playAnimation("plover", "Plover_Run")
~ waitForSeconds(2.0)
What time is it anyway?
~ clearAllLines()
~ waitForSeconds(0.7)
~ playAnimation("plover", "Plover_Run_Look_Up")
~ waitForSeconds(1.3)
~ playAnimation("plover", "Plover_Run")
~ waitForSeconds(0.5)
Like I know…
~ clearAllLines()
~ waitForSeconds(1.2)
~ playAnimation("scene", "Scene_ToNight2")
~ waitForAnimationEnd("scene")
-> Night2

=== Night2 ===
~ setParallaxSpeed(0)
~ setDayTime("night")
~ setHorizontalPosition("plover", 2.5)
~ playAnimation("plover", "Plover_Idle_Jumping")
I can’t believe I met<br/>an actual snake
~ playAnimation("plover", "Plover_Idle_Long")
She was pretty good<br/>at running too!
~ playAnimation("plover", "Plover_Idle_Short")
Wait!
~ playAnimation("plover", "Plover_Idle_Thinking")
~ waitForSeconds(2.0)
How could she be<br/>like running…
…but without feet
~ playAnimation("plover", "Plover_Idle_Surprise")
~ playAnimationDelayed("plover", "Plover_Idle_Short", 0.4)
Wait!
I think they do<br/>have feet actually
Like thousand super tiny ones
~ waitForSeconds(2.0)
~ playAnimation("plover", "Plover_Idle_Thinking")
But what about worms then?
~ waitForSeconds(2.0)
~ playAnimation("plover", "Plover_Idle_MindFuck")
My head hurts
-> EndOfNight

= EndOfNight
~ setParallaxSpeed(0)
~ setDayTime("night")
~ setHorizontalPosition("plover", 2.5)
~ playAnimation("plover", "Plover_Idle_Short")
And I’m hungry now
~ clearAllLines()
~ waitForSeconds(2.0)
~ playAnimation("plover", "Plover_Idle_Poop")
~ waitForAnimationEnd("plover")
~ playAnimation("plover", "Plover_Idle_GoingSleep")
~ waitForAnimationEnd("plover")
~ playAnimation("plover", "Plover_Idle_Sleep")
~ waitForSeconds(1.5)
~ playAnimation("scene", "Scene_ToDay2")
~ waitForAnimationEnd("scene")

-> Day3

=== Day3 ===
~ setHorizontalPosition("plover", 2.5)
~ playAnimation("plover", "Plover_Run")
Humph…
~ playAnimation("plover", "Plover_Run_Cry")
So tired...
This coast is endless
~ playAnimation("plover", "Plover_Run_Surprise")
Wait!
~ playAnimation("plover", "Plover_Run")
Am I even going<br/>in the right direction?
I could have hitchhiked on Sophie’s back?
~ playAnimation("plover", "Plover_Run_Sweaty")
She would probably<br/>have eaten me though
~ playAnimation("plover", "Plover_Run")
~ clearAllLines()
~ waitForSeconds(2.0)
~ playAnimation("plover", "Plover_Run_Poop")
~ waitForSeconds(0.8)
~ playAnimation("plover", "Plover_Run_Surprise")
~ waitForSeconds(0.4)
~ playAnimation("plover", "Plover_Run_Look_Up")
Wait! What the..! 
Did a bird<br/>actually poop on me?!
~ playAnimation("plover", "Plover_Run_Cry")
Eww! Gross!!
Imagine If the boys were to see me like this
~ clearAllLines()
~ playAnimation("plover", "Plover_Run")
~ waitForSeconds(4.0)
Hey Plover boy! #boys1
~ clearAllLines()
~ playAnimation("plover", "Plover_Run_Surprise")
~ playAnimationDelayed("plover", "Plover_Run", 0.4)

The stress makes me hallucinate
~ clearAllLines()
~ waitForSeconds(4.0)

Birdy bird! #boys1
~ clearAllLines()
~ playAnimation("plover", "Plover_Run_Surprise")
~ playAnimationDelayed("plover", "Plover_Run_Cry", 0.4)
That’s it, I’m starting to lose it
Am I dying?
Is that you Dove? 
Was I a good plover?
~ clearAllLines()

Over here you dinghy! #boys1
~ clearAllLines()
~ playAnimation("plover", "Plover_Run_Surprise")
~ playAnimationDelayed("plover", "Plover_Run_Look_Up", 0.6)
HAAAA!
~ playAnimation("plover", "Plover_Run_Surprise") 
~ playAnimationDelayed("plover", "Plover_Run_Cry", 0.5)
The boys!
~ clearAllLines() 
~ waitForSeconds(1.5)
Nice feathers! #boys1
What product are you using #boys1
~ clearAllLines()
~ playAnimation("plover", "Plover_Run_Angry")
-Wait! Did YOU poop on me?!
~ playAnimation("plover", "Plover_Run")
I don’t see<br/>what you’re talking about #boys1
~ clearAllLines()
~ waitForSeconds(2.0)
~ playAnimation("plover", "Plover_Run_Look_Up")
~ playAnimationDelayed("plover", "Plover_Run_", 0.1)
Haven’t you<br/>sprained an ankle already? #boys1
You know<br/>everyone’s getting ready #boys1
Migration party is tonight #boys1
And DinghyDung will miss it! #boys1
Hahaha! #boys1
~ clearAllLines()
~ playAnimation("plover", "Plover_Run_Surprise")
~ playAnimationDelayed("plover", "Plover_Eye_Top_R", 0.6)
Wait!<br/>How come you’re here then
What? #boys1
~ clearAllLines()
~ playAnimation("plover", "Plover_Eye_Bot_L")
-Yhea, If i’m so far away
How come you’re flying here
~ playAnimation("plover", "Plover_Run_Surprise")
~ playAnimationDelayed("plover", "Plover_Run_Fast_B", 0.6)
I must be getting close actually
~ clearAllLines()
Wait! No! #boys1
You’re like, super far away #boys1
And you’re like<br/>completely off course #boys1
Yhea! #boys1
~ clearAllLines()
~ waitForSeconds(1.0)
And hmmm.<br/>A Crow spotted you #boys1
Yhea, That’s how we found you #boys1
~ clearAllLines() 
No way that’s the truth!
~ playAnimation("plover", "Plover_Run_Happy")
I actually made it!
~ playAnimation("plover", "Plover_Run_Fast_A")
That wasn’t too long actually
~ clearAllLines() 	
No! you’re completely off #boys1
Beside, #boys1
~ clearAllLines() 
~ waitForSeconds(1.0) 
Running was pretty pointless #boys1
You know she’s not gonna roll with you #boys1
~ clearAllLines() 
~ waitForSeconds(1.0)
Yhea! #boys1
You’re still little DinghyDung #boys1
~ clearAllLines()
~ waitForSeconds(2.0)
I know what you’re doing
~ waitForSeconds(1.5)
But I don’t care
~ playAnimation("plover", "Plover_Run_Happy")
~ playAnimationDelayed("plover", "Plover_Run", 0.3)
What? #boys1
~ clearAllLines() 
~ playAnimation("plover", "Plover_Eye_Bot_L")
Running’s pretty rad!
It clears your head, you know…
~ playAnimation("plover", "Plover_Eye_Top_R")
Guys I think he got a sunstroke #boys1
~ clearAllLines() 
~ waitForSeconds(1.0)
~ playAnimation("plover", "Plover_Eye_Bot_L")
SShedding all the baby fluff
Naw, Just a regular stroke #boys1
Dude, don’t joke about that #boys1
~ clearAllLines() 
~ waitForSeconds(1.0)
Rolling only with the essential
~ clearAllLines()
~ playAnimation("plover", "Plover_Eye_Bot_L")
And the sky, the stars
~ clearAllLines()
~ waitForSeconds(1.0)
~ playAnimation("plover", "Plover_Run_Happy")
The birds and the breeze
~ playAnimation("plover", "Plover_Eye_Bot_L")
~ clearAllLines()
~ waitForSeconds(1.0)
~ playAnimationDelayed("plover", "Plover_Eye_Top_R", 1.5)
I’m friend with a snake<br/>you know
~ playAnimation("plover", "Plover_Run_Fast_A")
Ok you’re right, he lost it #boys1
~ clearAllLines()
I think i’m gonna run alone<br/>for a bit now
~ clearAllLines()
~ waitForSeconds(2.0)
~ playAnimation("plover", "Plover_Run_Look_Up")
~ playAnimationDelayed("plover", "Plover_Run_Fast_C", 1.5)
Bye guys!
Wait! #boys1
~ clearAllLines()
~ waitForSeconds(2.0)
Dang! He left #boys1
Don’t you think<br/>we should have told him? #boys1
Told him what? #boys1
~ clearAllLines()
~ waitForSeconds(2.0)
That she was waiting for him? #boys1
~ clearAllLines()





-> End


=== End ===
~ playAnimation("scene", "Scene_EndTitle")
~ waitForAnimationEnd("scene")
~ waitForSeconds(2.0)
This game was made for AGBIC 2021 by<br/>Rémi Bismuth and Nicolas Millot #end
~ waitForSeconds(0.5)
Thank you for playing #end
~ clearAllLines()
~ playAnimation("scene", "Scene_FadeAndRestart")
-> END
