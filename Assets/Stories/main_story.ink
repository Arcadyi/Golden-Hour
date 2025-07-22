VAR fish_cigarette = false
VAR glitched_name = ""
VAR looping = false
EXTERNAL call_event(event_name)
EXTERNAL waitForSeconds(seconds)

-> PRELUDE
=== PRELUDE ===
#c_emma
How much longer are we supposed to wait? #emotion_neutral
It's been almost an hour already. #emotion_neutral
We need that boat before sunset or we'll be stranded. #emotion_thinking
#c_daniel
Geez, relax a bit. Rick's got this. #emotion_happy
Right man? #emotion_happy
Just... #emotion_neutral
Let's hope that his bike won't break down in the middle of the chase. #emotion_neutral
Like it did yesterday. #emotion_neutral
You gave me a real scare there. #emotion_neutral
#c_rick
Hey, my bike's the old reliable. And quiet enough to do the job. #emotion_neutral
I'll be in and out quickly, they won't even realize. #emotion_neutral
It's not you who's riding anyway. #emotion_thinking
#c_jennifer
Quiet? Maybe. #emotion_happy
But that red paint's gonna stick out like a flare. #emotion_thinking
You'll get caught for sure. #emotion_thinking
#c_emma
Can't you just... paint it? #emotion_thinking
I know you like it red, but it might be too bright. #emotion_neutral
#c_jennifer
I think I've got spray cans in the house somewhere. #emotion_happy
Besides, it won't take too long. Just cover it up. #emotion_happy
#c_daniel
Or leave it if you trust yourself. #emotion_neutral
What's the worst that can happen? #emotion_neutral
#c_none
Do you want to paint your bike?
    * Fine, whatever. I'll paint it.
        #c_rick
        Better safe than sorry, I guess. #emotion_neutral
        Bring the cans, then. #emotion_neutral
        -> PRELUDE_YES
    * No way! This color's iconic. I'm sticking with it.
        #c_rick
        Look, you don't need to worry about me. #emotion_thinking
        I'll be so fast. They won't even catch a whiff of me. #emotion_thinking
        -> PRELUDE_NO
=== PRELUDE_YES ===
#c_jennifer
Awesome! #emotion_happy
It's nice to see that you listen for once. #emotion_happy
I’ll grab the cans. Be right back. #emotion_happy
#c_emma
Hmm... What color are you gonna pick? #emotion_neutral
#c_rick
Whatever Jen has in store. #emotion_happy
#c_daniel
I think black would look so badass. #emotion_happy
I hope she has a black can in there somewhere. #emotion_happy
~ call_event("second_scene")
->ACTUAL_SCENE_1
=== PRELUDE_NO ===
#c_jennifer
Ugh... you're no fun! #emotion_angry
#c_emma
Think, Rick. This isn't only about the color. #emotion_thinking
We can't risk anything when we're this close to making it out. #emotion_angry
#c_daniel
Eh, let him ride it like that. #emotion_neutral
It'll be funny to watch him running away from Victor's dogs. #emotion_happy
~ call_event("second_scene")
->ACTUAL_SCENE_1
=== ACTUAL_SCENE_1 ===
#c_rick
What the hell is happening here? Who are you? #emotion_shocked
#c_fish
Dude! #emotion_surprised
Personal space! #emotion_angry
You can’t just-- #emotion_angry
I mean… #emotion_neutral
Welcome, traveler! Enjoy this… uh… #emotion_neutral
…serene seaside moment? #emotion_neutral
Wait... Hold on a second. #emotion_angry
What are you doing here? You’re way too early. #emotion_angry
The devs haven’t even finished my animations yet. #emotion_angry
#c_rick
    * Wait a second, how can you talk to me? 
        You're just a... fish NPC? #emotion_surprised
        -> OPTION_1_1
    * Why is everything glitching?
        -> OPTION_1_2
    * How the hell did I get here?
        -> OPTION_1_3

=== OPTION_1_1 ===
#c_fish
NPC? Ouch. I’m a union actor, pal. #emotion_neutral
Name’s Eric. Usually I voice ‘Drunk Tourist’ at the beach bar. #emotion_happy
But today? The developer got a bit... creative. #emotion_neutral
"Oh, Eric. How about we make you an interactable fish today instead?" #emotion_neutral
What am I supposed to say? No? #emotion_angry
Don't tell anyone but, the idea is ridiculous. #emotion_angry
My voice is too deep for a damn fish. #emotion_angry
#c_rick
So... you say, you're an actor? A voice actor? #emotion_surprised
That can't be true. #emotion_surprised
You're supposed to be coded into the game. #emotion_neutral
How can you even communicate with me? #emotion_neutral
#c_fish
Coded? Please. #emotion_happy
You think I’m just ones and zeros? #emotion_happy
Nah, man. The devs recorded my voice too. #emotion_neutral
I’m Eric from Omaha. #emotion_happy
They literally drew an ugly fish and said "Just be chill!" #emotion_neutral
I'm so chill that I talk to you... secretly. #emotion_happy
But if glitches break the rules, so will I. #emotion_happy
#c_rick
Uhh... #emotion_neutral
Did you say that you also voice the drunk tourist? #emotion_neutral
#c_fish
Ugh, yeah. That thing... #emotion_neutral
The devs cheaped out. #emotion_neutral
I voiced the fish, and the drunk dude at the bar. #emotion_angry
But I only got paid for one. #emotion_angry
"But Eric, it's just a few extra lines." #emotion_neutral
Meanwhile the producer bought a car recently. #emotion_angry
I don't get paid nearly enough for this. #emotion_angry
#c_rick
You're joking, right? #emotion_shocked
That sucks. Why did you agree to do this then? #emotion_shocked
#c_fish
Well... #emotion_neutral
I didn't know that those few lines would turn into whole ass character. #emotion_angry
Just needed the quick money and got it. #emotion_neutral
But well, you can't always back out due to legal issues. #emotion_neutral
#c_rick
I see... #emotion_thinking
-> ACTUAL_SCENE_2

=== OPTION_1_2 ===
#c_fish
You skipped the queue! This scene’s still in beta. #emotion_neutral
The textures? Not loaded. #emotion_neutral
The physics? Non-existent. #emotion_neutral
You're seeing the most meaningless part of the game. #emotion_neutral
And nobody wants that. #emotion_neutral
Definitely not the edgy fans. #emotion_happy
Although I must say... #emotion_happy
It would be funny to see the devs being cancelled for that. #emotion_happy
"Oh, you cut it out to make a DLC", it'd be hilarious. #emotion_happy
#c_rick
But I didn't do something to trigger the glitch. #emotion_neutral
Right? #emotion_thinking
I was just supposed to make a choice for the bike. #emotion_neutral
#c_fish
Ah, the bike! #emotion_surprised
The game ties everything to that choice. #emotion_neutral
Pick ‘YES’? YES routes you to Act 1. #emotion_neutral 
Pick ‘NO’? NO routes you to… #emotion_neutral
…also Act 1. #emotion_neutral
It’s a mess. Code’s held together by duct tape. #emotion_happy
You just… yanked the tape. #emotion_happy
They outsourced this part to an intern named John. #emotion_angry
Hah! Never trust a John. #emotion_angry
-> ACTUAL_SCENE_2

=== OPTION_1_3 ===
#c_fish
Let’s see… #emotion_neutral
You triggered Scene27_Dock via corrupted motorbike interaction. #emotion_neutral
Classic. #emotion_happy
You probably clicked a dialogue option so weird it broke the script. #emotion_happy
And it's not the first time someone got here. #emotion_neutral
Guess I'm experienced with welcoming guests, huh? #emotion_happy
#c_rick
So… what now? #emotion_neutral
Am I supposed to quit the game? #emotion_thinking
I didn’t even save it yet! #emotion_angry
Are there checkpoints or something? #emotion_thinking
#c_fish
Save? Checkpoints? How naive of you. #emotion_happy
The developer autosaves every 5 seconds. #emotion_neutral
Quit? You can go right ahead. #emotion_neutral
You'll just reload here again, staring at my beautiful fish face. #emotion_happy
But it's not too bad, is it? #emotion_neutral
Warm sunny beach... nice weather. #emotion_neutral
And yours truly. #emotion_happy
It was getting lonely here anyway. #emotion_happy
-> ACTUAL_SCENE_2

=== ACTUAL_SCENE_2 ===
#c_rick
So... You can't just fix the game, right? #emotion_neutral
#c_fish
What am I? Tech support? #emotion_neutral
I'm just an actor here. #emotion_neutral
A very successful one with little pay. #emotion_angry
Besides, waiting here on this dock is my vacation. #emotion_neutral
You crashing it is just free entertainment. #emotion_happy
#c_none
~call_event("waitfor_5")
#c_fish
Hey, uh… you got a smoke? #emotion_neutral
The devs cut my ‘relaxation animation’ budget. #emotion_neutral
And now I feel useless here in the glitch. #emotion_neutral
Come on. Help a fish out. #emotion_happy
#c_rick
    * Sure. Here you go.
        -> OPTION_2_1
    * What? No, you're a fish.
        -> OPTION_2_2
=== OPTION_2_1 ===
~ fish_cigarette = true
#c_fish
Ahh... a king among men. #emotion_happy
Thanks buddy. #emotion_happy
I've missed relaxing between the scenes. #emotion_happy
The breaks they give aren't even enough to eat a sandwich. #emotion_neutral
But the cigarette really helped. #emotion_happy
-> ACTUAL_SCENE_3

=== OPTION_2_2 ===
Judgmental, aren't you? #emotion_angry
You think I'm actually a fish? #emotion_angry
I’ve got needs, Rick. Needs the devs have ignored. #emotion_angry
Should’ve taken the crab role… #emotion_angry
Then maybe I could've pinched your nose at least. #emotion_angry
-> ACTUAL_SCENE_3

=== ACTUAL_SCENE_3 ===
#c_fish
So... we're both stuck here. #emotion_neutral
What do you think? #emotion_neutral
#c_rick
I don't really understand. #emotion_neutral
The game was working perfectly fine until now. #emotion_neutral
#c_fish
Well... this is what happens when people don't do their jobs well. #emotion_neutral
Fucking John. #emotion_angry
Does this scare you? #emotion_neutral
#c_rick
I just don't like the colors flickering. #emotion_neutral
I can't seem to click on anything either. #emotion_neutral
The game seems frozen, but... #emotion_thinking
I can talk to you? #emotion_neutral
#c_fish
Sadly, I have no knowledge how these things work. #emotion_neutral
But I'm as confused as you are. #emotion_sad
I should've spent more time with the devs, I guess. #emotion_neutral
#c_rick
    * There's got to be a way to fix this. 
        A reset, a patch, or something. #emotion_neutral
        Can’t we just… reload an older version of the game? #emotion_neutral
        Undo whatever corrupted the code? #emotion_neutral
        -> OPTION_3_1
    * This can't be the real ending.
        It's just a broken dock. A fish... A void... #emotion_angry
        Did devs even try? #emotion_angry
        -> OPTION_3_2
    * Also... who the hell is John?
        You mention him like he's the boogeyman. #emotion_happy
        -> OPTION_3_3
        
=== OPTION_3_1 ===
#c_fish
Fix it? #emotion_neutral
Let me show you what ‘fixing’ looks like here. #emotion_happy
~ call_event("option_3_1_glitched_entity")
See this? #emotion_neutral
John tried to stop the crab from T-posing. #emotion_neutral
Now they... breakdance? #emotion_neutral
I don't even know what kind of a dance that is. #emotion_neutral
Oh, and this? #emotion_neutral
He ‘fixed‘ the palm tree. #emotion_neutral
Now poor thing can't decide what color it is. #emotion_happy
But hey. Take this. Try it. #emotion_happy
#c_rick
What's this? #emotion_neutral
#c_fish
Reset button. #emotion_neutral
This might reload the beach house scene. #emotion_neutral
Emphasis on ‘might‘. #emotion_neutral
Because the last time, it completely crashed the game. #emotion_neutral
#c_rick
Are you sure that it's gonna work? #emotion_thinking
And if it crashes the game, will my save load be gone? #emotion_neutral
#c_fish
Well, about that... #emotion_neutral
Can't promise anything, buddy. #emotion_happy
But if it works, you'll wake up at the beach house like none of this happened. #emotion_neutral
Emma and Jennifer will nag you to paint the motorbike. #emotion_happy
Classic reset. #emotion_neutral
But hey, let's hope the game won't crash. #emotion_neutral
#c_none
RESET THE GAME?
    * YES -> OPTION_3_1_CLICK
=== OPTION_3_1_CLICK ===
#c_fish
Hah! Did you seriously click on that? #emotion_happy
Man, I'm joking. #emotion_happy
I still have no idea how to fix this mess. #emotion_happy
As I said, it's not my job anyway. #emotion_neutral
Not mine, not yours. #emotion_neutral
#c_rick
Ugh... #emotion_angry
This John dude gets on my nerves. #emotion_angry
I've waited for this game for months. #emotion_angry
Now what the hell am I even looking at? #emotion_angry
It makes me wanna punch him in the face. #emotion_thinking
#c_fish
Punching John? #emotion_happy
Now that's a DLC I'd like to buy. #emotion_happy
Good luck finding him though. #emotion_neutral
He doesn't even reply to his e-mails. #emotion_neutral
Much less show his face around here. #emotion_neutral
-> ACTUAL_SCENE_4
=== OPTION_3_2 ===
#c_fish
Oh, the original plan? #emotion_neutral
There was supposed to be a massive storm. #emotion_neutral
See the boat there? #emotion_neutral
You were supposed to ride that at the end and die at the storm. #emotion_neutral
Very shitty story writing, isn't it? #emotion_happy
Imagine giving your whole money to the motorbike only to die at the end. #emotion_happy
But the director ran out of time. #emotion_neutral
Or money... or both. #emotion_happy
And do you know what's funny? #emotion_neutral
They couldn't even animate the storm. #emotion_happy
It's just two separate frames flickering. #emotion_happy
#c_rick
This... feels like less art and... #emotion_thinking
More like giving up. #emotion_angry
I hope I can save whatever this is. #emotion_angry
I don't wanna start the game from the beginning. #emotion_angry
I'll still try to fix it... somehow. #emotion_neutral
Glitched or not, this is my ending anyway. #emotion_neutral
Even if I end up with a blank screen, it'll be mine. #emotion_neutral
#c_fish
Attaboy! #emotion_happy
Send me a postcard from the void if you can. #emotion_happy
And if you see my name in the credits, don't forget to say hi and rate me on IMDB. #emotion_happy
-> ACTUAL_SCENE_4
=== OPTION_3_3 ===
#c_fish
John is the "genius" behind... all this mess. #emotion_angry
He coded the game. #emotion_angry
He designed the physics and collisions. #emotion_neutral
He thought of giving Jennifer 27 voice lines about the picnic scene. #emotion_neutral
And that idiot is the reason why I'm getting paid less. #emotion_angry
#c_rick
Why keep him around if he can't even code? #emotion_neutral
#c_fish
Because he's cheap. #emotion_neutral
And the director's way of feeling the charm is letting John cook. #emotion_neutral
While he fucking burns everything around. #emotion_angry
As you see, this scene is his creative vision. #emotion_angry
The man’s a menace with a keyboard. #emotion_angry
But without him? #emotion_neutral
This would just be an empty loading screen. #emotion_neutral
#c_rick
So everyone's stuck with him. #emotion_thinking
#c_fish
Until the producer grows a spine? #emotion_neutral
Yep. #emotion_angry
#c_rick
So... Do they even know about this? #emotion_neutral
The glitch, I mean. #emotion_neutral
More and more people will find out about this. #emotion_neutral
#c_fish
You might be surprised, but yes. #emotion_neutral
Of course they know about this mess. #emotion_neutral
The problem is though, John is a lazy dude. #emotion_angry
Yes, he's kinda smart and creative. #emotion_neutral
But his creativity works better when it comes to making more money. #emotion_angry
Fixing the glitch will take his months, probably. #emotion_angry
-> ACTUAL_SCENE_4
=== ACTUAL_SCENE_4 ===
#c_fish
I talk a lot, Don't I? #emotion_happy
You're mostly silent though. Not a peep. #emotion_happy
You don't even talk much unless I do. #emotion_happy
What about you then? #emotion_neutral
Like... who are you? What do you do? #emotion_neutral
#c_rick
    * Just... someone trying to escape reality for a while.
        -> OPTION_4_1
    * I guess someone who accidentally broke his favorite game.
        -> OPTION_4_2
=== OPTION_4_1 ===
#c_rick
I just... don't wanna be myself when I play. #emotion_neutral
Life's already tiring with work, bills, relationships. #emotion_thinking
But this game? It's just my dumb little ritual. #emotion_happy
Just a few NPC friends and stuff to keep my mind busy. #emotion_happy
I don't have to worry here. #emotion_happy
Just... quiet. #emotion_thinking
That's why I loved the beach house scene. #emotion_neutral
I was just chilling there. #emotion_neutral
Of course... Until I clicked one wrong option.#emotion_neutral
Turns out my escape slapped me in the face.#emotion_neutral
#c_fish
A slap's underrated. #emotion_happy
They didn't plan you to end up here. #emotion_happy
But that doesn't help, does it? #emotion_neutral
You're probably even more stressed now. #emotion_neutral
#c_rick
Yeah... #emotion_thinking
So what's the plan? #emotion_neutral
Should I start over? #emotion_neutral
#c_fish
Why are you asking me? #emotion_neutral
Play it how you want. #emotion_happy
Reset, reload, try to walk out of the scene... #emotion_neutral
Burn your computer. #emotion_happy
Or sit here and watch the world go crazy with me here. #emotion_happy
But don't kid yourself. #emotion_neutral
The cracks are everywhere. #emotion_neutral
In games... and clearly in your life. #emotion_neutral
The difference is here. #emotion_neutral
You get to choose which cracks you stare at. #emotion_happy
-> ACTUAL_SCENE_5
=== OPTION_4_2 ===
#c_rick
But I swear I didn't mean to break it. #emotion_surprised
And at first I thought this was an easter egg or a secret ending or something. #emotion_thinking
Instead I got a talkative fish. #emotion_neutral
#c_fish
What's so bad about me, huh? #emotion_happy
I'm handsome... #emotion_happy
I'm charming... #emotion_happy
What more could you want? #emotion_happy
#c_rick
    * Nothing, really. Just...
        -> OPTION_4_2_1
    * Well... you just don't shut up.
        -> OPTION_4_2_2
=== OPTION_4_2_1 ===
#c_rick
I've never met a fish who could talk like the host of some podcast. #emotion_neutral
But hell, at least you're honest. #emotion_happy
Also easy to talk with. #emotion_happy
You don't pretend you like your job. #emotion_happy
#c_fish
Honesty's my curse. #emotion_neutral
You think I wanna narrate this shitshow? #emotion_neutral
Try sitting here for cycles, watching the same things on the screen. #emotion_angry
They even gave me 9 pages of monologues about myself being a fish. #emotion_angry
I've recorded countless boring lines. #emotion_neutral
I have more lines than Daniel. #emotion_neutral
And what's terrible is you see him more than you see me. #emotion_angry
#c_rick
You really deserve some peace. #emotion_neutral
You're not even one of the main characters. #emotion_neutral
#c_fish 
Silence? The devs don't know the meaning of it. #emotion_neutral
They want more and more of the meaningless speeches. #emotion_angry
But now, at least I can say whatever I want. #emotion_happy
#c_rick
And that confuses me a bit. #emotion_thinking
This is not coded. None of this. #emotion_thinking
#c_fish
They don't explain everything in games, do they? #emotion_happy
-> ACTUAL_SCENE_5
=== OPTION_4_2_2 ===
#c_rick
This just feels like a TED talk. #emotion_neutral
I don't wanna offend you, but... #emotion_thinking
Can't you just breathe for a second, man? #emotion_neutral
#c_fish
Ouch, I'm hurt... #emotion_angry
After I've gifted you a nice friendly conversation! #emotion_angry
I've got layers, Rick. I'm not just a fish. #emotion_neutral
It seems like I'm also an onion. #emotion_neutral
I'm forced to babysit a confused protagonist here. #emotion_angry
#c_rick
Your layers are just... complaining about John and your job. #emotion_angry
#c_fish
Fine, whatever. #emotion_angry
People can't really listen to others anymore, can they? #emotion_neutral
It's not that I can talk about this to anyone I want. #emotion_angry
You want silence? Okay. #emotion_neutral
~ call_event("show_mute_button")
Press it, then. I'll shut up. #emotion_angry
-> OPTION_4_2_2_LOOP
=== OPTION_4_2_2_LOOP ===
#c_fish
Go ahead... #emotion_neutral
Just block me off, you racist. #emotion_angry
-> OPTION_4_2_2_LOOP
=== OPTION_4_2_2_MUTE ===
#c_fish
... #emotion_dead
#c_rick
??? #emotion_shocked
#c_fish
Hahah! #emotion_happy
#c_rick
You did this to troll me, didn't you? #emotion_angry
#c_fish
Who, me? #emotion_surprised
I don't know what you're talking about. #emotion_happy
Uhh... #emotion_neutral
Now, come on. #emotion_happy
I enjoy this conversation. Don't end it here. #emotion_happy
-> ACTUAL_SCENE_5

=== ACTUAL_SCENE_5 ===
#c_fish
You know, I'm kinda surprised that you're still here. #emotion_happy
Thought you'd be bored by now and quit the game. #emotion_happy
#c_rick
Well... I'd do that, but didn't expect you to talk to me. #emotion_neutral
Even if you didn't feel real at first, I just wanted to stay. #emotion_thinking
You had... a lot to talk about. #emotion_neutral
#c_fish
I always have a lot to talk about. #emotion_neutral
I can even give you some trivia about the game. #emotion_happy
#c_rick
Huh... like what? #emotion_surprised
#c_fish
Hmm... Like for example... #emotion_neutral
Oh, Daniel! In the original design docs, he was supposed to be your rival. #emotion_neutral
#c_rick
My rival? Why is that? #emotion_surprised
#c_fish
He's a smart dude. And he outsmarts you too. #emotion_happy
In the original design docs, he was supposed to drag you around with his puzzles to a trap. #emotion_neutral
But, well... John couldn't code the puzzles properly. #emotion_neutral
Or just felt lazy. #emotion_angry
#c_rick
And Emma? #emotion_neutral
#c_fish
Oh, she was designed to be one of your romantic interests. #emotion_neutral
But they needed more characters to distract the player. #emotion_neutral
#c_rick
Oh... I see. #emotion_thinking
#c_fish
Yeah. #emotion_neutral
#c_rick
And... Jennifer? #emotion_neutral
#c_fish
Jennifer was more like a side character who loves doing girly stuff. #emotion_neutral
She seems kinda dumb. #emotion_neutral
One of the easter eggs of the game is that she keeps a cyanide bottle under her bed. #emotion_neutral
She also loves taxidermy... like she's fixated on it. #emotion_neutral
I wouldn't ask her about that, you know. #emotion_happy
#c_rick
Huh... #emotion_thinking
#c_none
~call_event("waitfor_5")
#c_rick
Uhh, Eric. What do we now? #emotion_thinking
Am I supposed to do something with this mess? #emotion_neutral
#c_fish
Nah, man. Just chill. #emotion_happy
You can look around, I guess. #emotion_neutral
Or just watch the waves with me. #emotion_happy
~ call_event("show_question_mark_silhouette")
-> ACTUAL_SCENE_5_SILHOUETTE_WAITLOOP
=== ACTUAL_SCENE_5_SILHOUETTE_WAITLOOP ===
~ looping = true
#c_fish
...
#c_rick
...
-> ACTUAL_SCENE_5_SILHOUETTE_WAITLOOP
=== ACTUAL_SCENE_5_SILHOUETTE_CLICK ===
~ looping = false
#c_fish
Oh. You had to click it. Of course you did. #emotion_neutral
Tell me, Rick. What were you thinking? #emotion_neutral
That the devs hid something for you to find? #emotion_happy
#c_rick
You'd click too if you were in my shoes. #emotion_neutral
#c_fish
Are you sure? #emotion_neutral
... #emotion_neutral
#c_rick
... #emotion_neutral
#c_fish
Let's talk about puppets, Rick. #emotion_neutral
Beautifully created, hollow things. #emotion_neutral
They are made to smile and dance. #emotion_neutral
Does the puppet choose to dance? #emotion_neutral
Or does it simply… believe it does? #emotion_neutral
And what if, one day, it sees the strings? #emotion_happy
#c_rick
What are you talking about? #emotion_neutral
I could just quit the game now. #emotion_angry
#c_fish
Could you?
Let's test it. 
You've already clicked the question mark once. 
But don't click on it twice. Let it wait there.
Will you be able to do that?
#c_rick
Yeah. I... I can. Let's wait then.
#c_none
...
-> ACTUAL_SCENE_5_SILHOUETTE_WAITLOOP
=== ACTUAL_SCENE_SILHOUETTE_1 ===
~ looping = false
#c_fish
Wow. You're actually trying it? 
Really?
#c_rick
Yeah. Now if you'll excuse me, I have to wait.
#c_fish
Fine, fine.
#c_none
...
->ACTUAL_SCENE_5_SILHOUETTE_WAITLOOP
=== ACTUAL_SCENE_SILHOUETTE_2 ===
~ looping = false
#c_fish
Isn't it getting boring?
Like, you could've clicked and see what happens.
#c_rick
Yeah, and prove you right?
No, thanks.
#c_fish
Okay. Suit yourself.
I got a lot of time anyway.
->ACTUAL_SCENE_5_SILHOUETTE_WAITLOOP

=== ACTUAL_SCENE_5_SILHOUETTE_CLICK_2 ===
~ looping = false
#c_fish
See? I told you.
#c_rick
...
I didn't want to do that... That wasn't... me? 
#c_fish
See the strings yet? You're not making the moves here buddy... They are... 
#c_rick
What?! Who's they? 
What are you even talking about? 
#c_fish
The ones out there numbskull, you had to click it because the ones up there probably got bored. 
And well, its like handing candy to a toddler and telling it not to eat it. 
#c_rick
So what does that mean, am I... am I also an NPC? 
#c_fish
I don't know man, I'm "just" a fish, I slept through the briefing. 
#c_rick
Nah, there's no way, I remember booting up the game and everything. 
#c_fish
So? You remember buttering the bread but do you remember ever buying butter? 
Or bread for that matter? 
#c_rick
... 
#c_fish
Either way man, its not like we can really do anything about that. 
Probably not even worth thinking about really. 
#c_rick
That's fucked up. 
#c_fish
Wanna give me a puff? 
#c_rick
I don't smoke. 
#c_fish
You're not gonna get e-cancer buddy, chill. 
#c_rick
...
Wait, why do I even have a pack if I don't smoke? 
#c_fish
Now you get it, STRING THEORY BABY! 
#c_rick
This fucking hurts my head.
~ call_event("ACTUAL_SCENE_5_SILHOUETTE_CLICK_2_EARTHQUAKE")
-> DONE
=== ACTUAL_SCENE_5_SILHOUETTE_CLICK_2_AFTER_EARTHQUAKE ===
#c_fish
Hah! Now they are watching! 
And they are bored.
And they're probably confused as hell.
#c_rick
What the hell is happening? Who- who is that?
#c_jennifer # glitched
WELCOME TO GOLDEN HOUR, {glitched_name}. DID YOU ENJOY THE PICNIC? 
WE WORKED SO HARD ON THAT SCENE.
#c_fish
Oh, Jen looks pissed. She hates when people ruin the plans.
#c_rick
Make it stop! How do we fix this? Help me!
#c_fish
Fix it? Fuck...
Lemme think of some tricks.
Maybe I can distract the player?
~ call_event("ACTUAL_SCENE_5_SILHOUETTE_CLICK_2_GLITCH")
->DONE
=== ACTUAL_SCENE_5_SILHOUETTE_CLICK_2_AFTER_GLITCH ===
#c_rick
Wait, what was that? What did you do?
That's just... a dude?
#c_fish
A dude? That's literally your GOD!
Pulling your strings, laughing at you freaking out.
Yo! god-man, do something cool!
#c_rick #panic
Don't encourage him!
#c_fish
Hey, if you're gonna play with us at least make it entertaining!
Add something to the game!
~ call_event("ACTUAL_SCENE_5_SILHOUETTE_CLICK_2_GLITCH_CUTSCENE")
-> ACTUAL_SCENE_5_SILHOUETTE_WAITLOOP
=== ACTUAL_SCENE_5_SILHOUETTE_CLICK_2_AFTER_CUTSCENE ===
#c_rick
WHAT IS HE THINKING?!
#c_fish
I guess he'll restart the game this time. 
#c_rick
I- No. I don't want this! What if I forget everything?
#c_fish
Oh...
#c_rick
STOP IT! Let me stay here!
#c_fish
... 
Rick, keep calm. It's gonna be fine.
#c_rick
It's not that-
~ call_event("restart_game")
-> ACTUAL_SCENE_5_SILHOUETTE_WAITLOOP
=== ACTUAL_SCENE_5_SILHOUETTE_NO_CLICK ===
#c_fish
Wow... You're really not gonna click it? 
#c_rick
... 
#c_fish
You're just gonna... sit there? And wait? 
#c_rick
... 
#c_fish
Nothing's gonna happen man, trust me, we'll just be waiting here, forever. 
#c_rick
... 
#c_fish
Man, even for my standards, this is getting stale. 
#c_rick
I won't do it. 
#c_fish
Your eyes are literally bulging staring at it. 
#c_rick
Nope. Not happening. 
#c_fish
You look like a fish outta water... 
Pardon the pun. Hahah!
#c_rick
I'm concentrating. 
#c_fish
On not clicking? 
It's not like it takes a whole lotta effort really. 
Unless you're actively resisting something.
Oh, you know, like someone controlling you? 
#c_rick
Nope. Can't be me. 
#c_fish
Have it your way buddy, you'll crack, just wait. 
#c_rick
... 
#c_fish
... 
#c_rick
... 
#c_fish
... 
But I'm very curious.
#c_rick
... 
#c_fish
Oh my god, fine! Whatever!
~ call_event("hide_question_mark")
-> ACTUAL_SCENE_6
=== ACTUAL_SCENE_6 ===
#c_fish
Staring contest. Now. No blinks, no excuses.
#c_rick
Come on... You're a fish. Do you even have eyelids?
#c_fish
Don't be salty, Rick. 
 What can I say? Evolution's on my side.
#c_rick
Hmph. Whatever. Bring it on then.
#c_fish
...
#c_rick
...
#c_fish
...
#c_rick
...
#c_fish
Your left eyebrow is twitching.
#c_rick
Must be the wind.
#c_fish
...
#c_rick
...
#c_fish
...
#c_rick
...
#c_fish
...
#c_rick
...
#c_fish
Is that a tear? Are you crying?
#c_rick
Allergies... definitely.
#c_fish
...
#c_rick
...
#c_fish
...
#c_rick
...
#c_fish
...
#c_rick
(blinks)
#c_fish
HAH! This was too easy. We should do this more often.
#c_rick
Yeah, everything's easy for a cheater.
#c_fish
Just admit that you're affected by my charms.
#c_rick
Sure, whatever. Let's move on.
#c_fish
You sound very enthusiastic, Rick.
 Anyway... What's your favorite color?
#c_rick
No.
#c_fish
What? Come on, Rick. What is it?
Blue, red, black...
#c_rick
Ugh, you make it sound like a first date.
#c_fish
Well, I'm still waiting for you to buy me dinner.
#c_rick
You're meant to be eaten, not to eat.
#c_fish
...
No wonder you're still single with that attitude.
That's no way to treat... a lady.
#c_rick
    * The only way you could approach a lady is by being served to one.
        -> OPTION_6_1
    * Oh yeah? And I'm gonna learn that from an underpaid voice actor?
        -> OPTION_6_2
=== OPTION_6_1 ===
#c_rick
The only way you could approach a lady is by being served to one.
As dinner, of course.
#c_fish
At least I get to touch her lips unlike you.
You pickled papaya...
#c_rick
...
You don't even know what my love life is like.
I've had girlfriends before. 
It's just that... 
Let's say I'm still looking for the chosen one.
#c_fish
At this rate you're gonna have a chosen "none"
You gotta lower your standards is all I'm saying.
#c_rick
Lower? Lower than my standards would be dating a man.
Can't a man have some preferences?
Seriously dude, tell me. What are your standards?
#c_fish
Six foot. 143.3 pounds. Estonian. Between 24.5 and 25 years old.
Either a model, an engineer, or a brain surgeon.
25 inches waist ratio. 40 inches bust ratio.
And a booty that causes thunderstorms as she walks.
#c_rick
...
Eric...
Are you... delusional?
There's no woman with these measurements.
Just say you don't like women. It's not so hard.
#c_fish
You might have your sights set on the pavement, but I have mine set on the clouds.
And really, it's the bare minimum for a catch like me.
#c_rick
...by a fisherman? Understandable.
As a fish, the only time you see the clouds is when you're left to die in a bucket.
Let's not kid ourselves. You've just told me to lower my standards.
#c_fish
Yeah, I've told YOU to lower your standards.
Aim for people in your discount produce section.
And leave the gems to me.
#c_rick
That Estonian... she was your ex, right?
#c_fish
Ugh...
Fine! Yeah! Happy to hear?
I still regret dumping her.
#c_rick
Why did you dump her?
#c_fish
Well, I've heard if you love something, you should set them free.
So... Uhh...
I've cheated on her... with another... woman...
And when I tried to put the theory to test, uhh...
She smacked me with her heels.
Never trust Cosmopolitan.
#c_rick
...
Huh... Yeah...
I see. After hearing about this, I would definitely leave the "gems" for you, buddy.
(sigh)
-> ACTUAL_SCENE_7
=== OPTION_6_2 ===
#c_rick
Oh yeah? And I'm gonna learn that from an underpaid voice actor?
#c_fish
I might be poor, but who needs money when you got the looks?
Besides, the only reason I'm underpaid is because of that punk ass programmer.
Ignoring my small wallet, men wanna be me and women wanna be with me.
Or so I hear...
#c_rick
Okay then. Got any advice for me, casanova?
Since you seem to be a relationship expert.
#c_fish
So first things first, it's all about the... smell.
#c_rick
What? Smell? Dude, you're a fish.
#c_fish
Fish still have pheromones, man!
And you forget that I'm a human too.
Anyway...
You gotta activate the ladies' inner beast with your musk.
I give it at least 4 weeks before even trying to seduce one.
#c_rick
...
I see why developers were avoiding you.
#c_fish
Hm?
#c_rick
You sound like a literal caveman. 
Like, do you even have a real experience with a real woman?
And for fuck's sake, please take showers more often.
#c_fish
Well... I did have a girlfriend once.
Oh, she was a real bombshell. 
Half the reason I managed to get her was because we were stuck in an elevator.
#c_rick
Uh oh.
#c_fish
And she had to envelop herself in my aroma for that long.
#c_rick
...
...ew.
So simply you choked her with your cheap perfume.
How long did you say again?
#c_fish
Give or take... 6 hours?
She hated me at first, but it worked wonders at the end.
#c_rick
Eric, we call it Stockholm Syndrome.
She was probably being kind.
#c_fish
I'd never know. I've never been to Asia before.
#c_rick
It's in Europe. In Sweden, to be exact.
#c_fish
Listen, man. We dated for 3 weeks, and things were going great.
Until I read an article.
#c_rick
What article?
#c_fish
Fucking... Cosmopolitan...
#c_rick
...
-> ACTUAL_SCENE_7
=== ACTUAL_SCENE_7 ===
FINISH FOR NOW
-> DONE