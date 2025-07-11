VAR fish_cigarette = false
VAR glitched_name = ""
VAR looping = false
EXTERNAL call_event(event_name)
EXTERNAL waitForSeconds(seconds)

-> PRELUDE
=== PRELUDE ===
#c_emma
How much longer are we supposed to wait?
It's been almost an hour already
We need that boat before sunset or we'll be stranded
#c_daniel
Geez, relax a bit. Rick's got this
Right man?
Just...
Let's hope that his bike won't break down in the middle of the chase.
Like it did yesterday.
You gave me a real scare there.
#c_rick
Hey, my bike's the old reliable. And quiet enough to do the job. 
I'll be in and out quickly, they won't even realize.
It's not you who's driving anyway.
#c_jennifer
Quiet? Maybe.
But that red paint's gonna stick out like a flare.
You'll get caught for sure.
#c_emma
Can't you just... paint it? 
I know you like it red, but it might be too bright.
#c_jennifer
I think I've got spray cans in the house somewhere.
Besides, it won't take too long. Just cover it up.
#c_daniel
Or leave it if you trust yourself.
What's the worst that can happen?
#c_rick
Do you want to paint your bike?
    * Fine, whatever. I'll paint it. 
        Better safe than sorry, I guess.
        Bring the cans, then. 
        -> PRELUDE_YES
    * No way! This color's iconic. I'm sticking with it.
        Look, you don't need to worry about me.
        I'll be so fast. They won't even catch a whiff of me. 
        -> PRELUDE_NO
=== PRELUDE_YES ===
#c_jennifer
Awesome!
It's nice to see that you listen for once.
I’ll grab the cans. Be right back.
#c_emma
Hmm... What color are you gonna pick?
#c_rick
Whatever Jen has in store.
#c_daniel
I think black would look so badass.
I hope she has a black can in there somewhere.
~ call_event("second_scene")
->ACTUAL_SCENE_1
=== PRELUDE_NO ===
#c_jennifer
Ugh... you're no fun!
#c_emma
Think, Rick. This isn't only about the color.
We can't risk anything when we're this close to making it out.
#c_daniel
Eh, let him ride it like that.
It'll be funny to watch him running away from Victor's dogs.
~ call_event("second_scene")
->ACTUAL_SCENE_1
=== ACTUAL_SCENE_1 ===
#c_rick
What the hell is happening here? Who are you?
#c_fish
Dude!
Personal space!
You can’t just--
I mean…
Welcome, traveler! Enjoy this… uh…
…serene seaside moment?
Wait... Hold on a second.
What are you doing here? You’re way too early. 
The devs haven’t even finished my animations yet.
#c_rick
    * Wait a second, how can you talk to me? 
        You're just a... fish NPC?
        -> OPTION_1_1
    * Why is everything glitching?
        -> OPTION_1_2
    * How the hell did I get here?
        -> OPTION_1_3

=== OPTION_1_1 ===
#c_fish
NPC? Ouch. I’m a union actor, pal.
Name’s Eric. Usually I voice ‘Drunk Tourist’ at the beach bar.
But today? The developer got a bit... creative.
"Oh, Eric. How about we make you an interactable fish today instead?"
What am I supposed to say? No?
Don't tell anyone but, the idea is ridiculous. 
My voice is too deep for a damn fish.
#c_rick
So... you say, you're an actor? A voice actor? 
That can't be true. 
You're supposed to be coded into the game. 
How can you even communicate with me?
#c_fish
Coded? Please. 
You think I’m just ones and zeros?
Nah, man. The devs recorded my voice too. 
I’m Eric from Omaha. 
They literally drew an ugly fish and said "Just be chill!"
I'm so chill that I talk to you... secretly.
But if glitches break the rules, so will I.
#c_rick
Uhh...
Did you say that you also voice the drunk tourist?
#c_fish
Ugh, yeah. That thing...
The devs cheaped out.
I voiced the fish, and the drunk dude at the bar.
But I only got paid for one.
"But Eric, it's just a few extra lines."
Meanwhile the producer bought a car recently.
I don't get paid nearly enough for this.
#c_rick
You're joking, right?
That sucks. Why did you agree to do this then?
#c_fish
Well...
I didn't know that those few lines would turn into whole ass character.
Just needed the quick money and got it.
But well, you can't always back out due to legal issues.
#c_rick
I see...
-> ACTUAL_SCENE_2

=== OPTION_1_2 ===
#c_fish
You skipped the queue! This scene’s still in beta.
The textures? Not loaded. 
The physics? Non-existent. 
You're seeing the most meaningless part of the game.
And nobody wants that. 
Definitely not the edgy fans.
Although I must say...
It would be funny to see the devs being cancelled for that.
"Oh, you cut it out to make a DLC", it'd be hilarious.
#c_rick
But I didn't do something to trigger the glitch.
Right? 
I was just supposed to make a choice for the bike.
#c_fish
Ah, the bike!
The game ties everything to that choice. 
Pick ‘YES’? YES routes you to Act 1. 
Pick ‘NO’? NO routes you to…
…also Act 1.
It’s a mess. Code’s held together by duct tape. 
You just… yanked the tape.
They outsourced this part to an intern named John.
Hah! Never trust a John.
-> ACTUAL_SCENE_2

=== OPTION_1_3 ===
#c_fish
Let’s see…
You triggered Scene27_Dock via corrupted motorbike interaction.
Classic. 
You probably clicked a dialogue option so weird it broke the script. 
And it's not the first time someone got here.
Guess I'm experienced with welcoming guests, huh?
#c_rick
So… what now? 
Am I supposed to quit the game? 
I didn’t even save it yet!
Are there checkpoints or something?
#c_fish
Save? Checkpoints? How naive of you.
The developer autosaves every 5 seconds.
Quit? You can go right ahead.
You'll just reload here again, staring at my beautiful fish face.
But it's not too bad, is it?
Warm sunny beach... nice weather.
And yours truly.
It was getting lonely here anyway.
-> ACTUAL_SCENE_2

=== ACTUAL_SCENE_2 ===
#c_rick
So... You can't just fix the game, right?
#c_fish
What am I? Tech support?
I'm just an actor here.
A very successful one with little pay.
Besides, waiting here on this dock is my vacation.
You crashing it is just free entertainment.
...
...
...
...
...
Hey, uh… you got a smoke?
The devs cut my ‘relaxation animation’ budget.
And now I feel useless here in the glitch.
Come on. Help a fish out.
#c_rick
    * Sure. Here you go.
        -> OPTION_2_1
    * What? No, you're a fish.
        -> OPTION_2_2
=== OPTION_2_1 ===
~ fish_cigarette = true
#c_fish
Ahh... a king among men.
Thanks buddy.
I've missed relaxing between the scenes.
The breaks they give aren't even enough to eat a sandwich.
But the cigarette really helped. 
-> ACTUAL_SCENE_3

=== OPTION_2_2 ===
Judgmental, aren't you?
You think I'm actually a fish?
I’ve got needs, Rick. Needs the devs have ignored.
Should’ve taken the crab role…
Then maybe I could've pinched your nose at least.
-> ACTUAL_SCENE_3

=== ACTUAL_SCENE_3 ===
#c_fish
So... we're both stuck here.
What do you think?
#c_rick
I don't really understand.
The game was working perfectly fine until now.
#c_fish
Well... this is what happens when people don't do their jobs well.
Fucking John.
Does this scare you?
#c_rick
I just don't like the colors flickering.
I can't seem to click on anything either.
The game seems frozen, but...
I can talk to you?
#c_fish
Sadly, I have no knowledge how these things work.
But I'm as confused as you are.
I should've spent more time with the devs, I guess.
#c_rick
    * There's got to be a way to fix this. 
        A reset, a patch, or something.
        Can’t we just… reload an older version of the game?
        Undo whatever corrupted the code?
        -> OPTION_3_1
    * This can't be the real ending.
        It's just a broken dock. A fish... A void...
        Did devs even try?
        -> OPTION_3_2
    * Also... who the hell is John?
        You mention him like he's the boogeyman.
        -> OPTION_3_3
        
=== OPTION_3_1 ===
#c_fish
Fix it? 
Let me show you what ‘fixing’ looks like here.
~ call_event("option_3_1_glitched_entity")
See this? 
John tried to stop the crab from T-posing.
Now they... breakdance?
I don't even know what kind of a dance that is.
Oh, and this?
He ‘fixed‘ the palm tree. 
Now poor thing can't decide what color it is.
But hey. Take this. Try it.
#c_rick
What's this?
#c_fish
Reset button. 
This might reload the beach house scene.
Emphasis on ‘might‘.
Because the last time, it completely crashed the game.
#c_rick
Are you sure that it's gonna work?
And if it crashes the game, will my save load be gone?
#c_fish
Well, about that...
Can't promise anything, buddy.
But if it works, you'll wake up at the beach house like none of this happened.
Emma and Jennifer will nag you to paint the motorbike.
Classic reset.
But hey, let's hope the game won't crash.
#c_none
RESET THE GAME?
    * YES -> OPTION_3_1_CLICK
=== OPTION_3_1_CLICK ===
#c_fish
Hah! Did you seriously click on that?
Man, I'm joking. 
I still have no idea how to fix this mess.
As I said, it's not my job anyway.
Not mine, not yours.
#c_rick
Ugh...
This John dude gets on my nerves.
I've waited for this game for months.
Now what the hell am I even looking at?
It makes me wanna punch him in the face.
#c_fish
Punching John?
Now that's a DLC I'd like to buy.
Good luck finding him though.
He doesn't even reply to his e-mails.
Much less show his face around here.
-> ACTUAL_SCENE_4
=== OPTION_3_2 ===
#c_fish
Oh, the original plan?
There was supposed to be a massive storm.
See the boat there? 
You were supposed to ride that at the end and die at the storm.
Very shitty story writing, isn't it?
Imagine giving your whole money to the motorbike only to die at the end.
But the director ran out of time.
Or money... or both.
And do you know what's funny?
They couldn't even animate the storm.
It's just two separate frames flickering.
#c_rick
This... feels like less art and...
More like giving up.
I hope I can save whatever this is.
I don't wanna start the game from the beginning.
I'll still try to fix it... somehow.
Glitched or not, this is my ending anyway.
Even if I end up with a blank screen, it'll be mine.
#c_fish
Attaboy!
Send me a postcard from the void if you can.
And if you see my name in the credits, don't forget to say hi and rate me on IMDB.
-> ACTUAL_SCENE_4
=== OPTION_3_3 ===
#c_fish
John is the "genius" behind... all this mess.
He coded the game.
He designed the physics and collisions. 
He thought of giving Jennifer 27 voice lines about the picnic scene.
And that idiot is the reason why I'm getting paid less.
#c_rick
Why keep him around if he can't even code?
#c_fish
Because he's cheap.
And the director's way of feeling the charm is letting John cook.
While he fucking burns everything around.
As you see, this scene is his creative vision.
The man’s a menace with a keyboard.
But without him?
This would just be an empty loading screen.
#c_rick
So everyone's stuck with him.
#c_fish
Until the producer grows a spine?
Yep. 
#c_rick
So... Do they even know about this?
The glitch, I mean.
More and more people will find out about this.
#c_fish
You might be surprised, but yes.
Of course they know about this mess.
The problem is though, John is a lazy dude.
Yes, he's kinda smart and creative.
But his creativity works better when it comes to making more money.
Fixing the glitch will take his months, probably. 
-> ACTUAL_SCENE_4
=== ACTUAL_SCENE_4 ===
#c_fish
I talk a lot, Don't I?
You're mostly silent though. Not a peep.
You don't even talk much unless I do.
What about you then?
Like... who are you? What do you do?
#c_rick
    * Just... someone trying to escape reality for a while.
        -> OPTION_4_1
    * I guess someone who accidentally broke his favorite game.
        -> OPTION_4_2
=== OPTION_4_1 ===
#c_rick
I just... don't wanna be myself when I play.
Life's already tiring with work, bills, relationships.
But this game? It's just my dumb little ritual.
Just a few NPC friends and stuff to keep my mind busy.
I don't have to worry here.
Just... quiet.
That's why I loved the beach house scene.
I was just chilling there.
Of course... Until I clicked one wrong option.
Turns out my escape slapped me in the face.
#c_fish
A slap's underrated. 
They didn't plan you to end up here.
But that doesn't help, does it?
You're probably even more stressed now.
#c_rick
Yeah...
So what's the plan?
Should I start over? 
#c_fish
Why are you asking me?
Play it how you want.
Reset, reload, try to walk out of the scene...
Burn your computer. 
Or sit here and watch the world go crazy with me here.
But don't kid yourself.
The cracks are everywhere.
In games... and clearly in your life.
The difference is here.
You get to choose which cracks you stare at.
-> ACTUAL_SCENE_5
=== OPTION_4_2 ===
#c_rick
But I swear I didn't mean to break it.
And at first I thought this was an easter egg or a secret ending or something.
Instead I got a talkative fish.
#c_fish
What's so bad about me, huh?
I'm handsome
I'm charming
What more could you want?
#c_rick
    * Nothing, really. Just...
        -> OPTION_4_2_1
    * Well... you just don't shut up.
        -> OPTION_4_2_2
=== OPTION_4_2_1 ===
#c_rick
I've never met a fish who could talk like the host of some podcast.
But hell, at least you're honest.
Also easy to talk with.
You don't pretend you like your job.
#c_fish
Honesty's my curse.
You think I wanna narrate this shitshow?
Try sitting here for cycles, watching the same things on the screen.
They even gave me 9 pages of monologues about myself being a fish.
I've recorded countless boring lines.
I have more lines than Daniel.
And what's terrible is you see him more than you see me.
#c_rick
You really deserve some peace.
You're not even one of the main characters.
#c_fish
Silence? The devs don't know the meaning of it.
They want more and more of the meaningless speeches.
But now, at least I can say whatever I want.
#c_rick
And that confuses me a bit.
This is not coded. None of this.
#c_fish
They don't explain everything in games, do they?
-> ACTUAL_SCENE_5
=== OPTION_4_2_2 ===
#c_rick
This just feels like a TED talk.
I don't wanna offend you, but...
Can't you just breathe for a second, man?
#c_fish
Ouch, I'm hurt...
After I've gifted you a nice friendly conversation!
I've got layers, Rick. I'm not just a fish.
It seems like I'm also an onion.
I'm forced to babysit a confused protagonist here.
#c_rick
Your layers are just... complaining about John and your job.
#c_fish
Fine, whatever.
People can't really listen to others anymore, can they?
It's not that I can talk about this to anyone I want.
You want silence? Okay.
~ call_event("show_mute_button")
Press it, then. I'll shut up.
-> OPTION_4_2_2_LOOP
=== OPTION_4_2_2_LOOP ===
#c_fish
Go ahead..
Just block me off, you racist.
-> OPTION_4_2_2_LOOP
=== OPTION_4_2_2_MUTE ===
#c_none
...
...
...
...
...
#c_rick
You did this to troll me, didn't you?
#c_fish
Who, me?
I don't know what you're talking about.
Uhh...
Now, come on.
I enjoy this conversation. Don't end it here.
-> ACTUAL_SCENE_5

=== ACTUAL_SCENE_5 ===
#c_fish
You know, I'm kinda surprised that you're still here.
Thought you'd be bored by now and quit the game.
#c_rick
Well... I'd do that, but didn't expect you to talk to me.
Even if you didn't feel real at first, I just wanted to stay.
You had... a lot to talk about.
#c_fish
I always have a lot to talk about. 
I can even give you some trivia about the game.
#c_rick
Huh... like what?
#c_fish
Hmm... Like for example...
Oh, Daniel! In the original design docs, he was supposed to be your rival.
#c_rick
My rival? Why is that?
#c_fish
He's a smart dude. And he outsmarts you too.
In the original design docs, he was supposed to drag you around with his puzzles to a trap.
But, well... John couldn't code the puzzles properly.
Or just felt lazy.
#c_rick
And Emma? 
#c_fish
Oh, she was designed to be one of your romantic interests
But they needed more characters to distract the player.
#c_rick
Oh... I see.
#c_fish
Yeah.
#c_rick
And... Jennifer?
#c_fish
Jennifer was more like a side character who loves doing girly stuff.
She seems kinda dumb.
One of the easter eggs of the game is that she keeps a cyanide bottle under her bed.
She also loves taxidermy... like she's fixated on it.
I wouldn't ask her about that, you know.
#c_rick
Huh...
#c_none
...
...
...
#c_rick
Uhh, Eric. What do we now?
Am I supposed to do something with this mess?
#c_fish
Nah, man. Just chill.
You can look around, I guess.
Or just watch the waves with me.
~ call_event("show_question_mark_silhouette")
-> ACTUAL_SCENE_5_SILHOUETTE_WAITLOOP
=== ACTUAL_SCENE_5_SILHOUETTE_WAITLOOP ===
~ looping = true
#c_fish
...
...
#c_rick
...
...
-> ACTUAL_SCENE_5_SILHOUETTE_WAITLOOP
=== ACTUAL_SCENE_5_SILHOUETTE_CLICK ===
~ looping = false
#c_fish
Oh. You had to click it. Of course you did.
Tell me, Rick. What were you thinking?
That the devs hid something for you to find?
#c_rick
You'd click too if you were in my shoes.
#c_fish
Are you sure?
...
#c_rick
...
#c_fish
Let's talk about puppets, Rick.
Beautifully created, hollow things.
They are made to smile and dance.
Does the puppet choose to dance?
Or does it simply… believe it does?
And what if, one day, it sees the strings?
#c_rick
What are you talking about?
I could just quit the game now.
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