All of these sprites have been ripped from the android version of the game. The folders beginning with "Dan The Man_com.halfbrick.dantheman" contain newer versions than the folder "1_dan_the_man" which contains the version from "http://play.mob.org/game/dan_the_man.html". There's probably many more but I couldn't find any. Don't ask me where their differences are. I don't even know, myself. Just look at the newest folder and it probably already contains everything you want.



NAQ (Never Asked Questions):

Q:	How do I separate the sprites from the background?
A:	The sprites are in a PNG format which contains 8-bit information about each of the RGB color channels, as well as the alpha channel. Your painting program appears to not support images with alpha channel transparency. If you need the images with a specific background color, there's a neat workaround for that: Open the file "Demonstration.html" with your web browser. Then enter the color and you will see all of the images with that background color. Now, simply make a screenshot of your web browser and you should be good to go.
Q:	Why does a pixel art game need an alpha channel?
A:	You're right, it would seem that an alpha channel is redundant for a pixel art game. However, I saw a glowy effect on the dark master which requires semi-transparent pixels. And there may be some more occurrences.
Q:	I opened "Demonstration.html" but it's blank.
A:	You need to enable JavaScript.
Q:	I entered the background color into the prompt of "Demonstration.html" and my browser froze.
A:	The game contains so many sprites that your browser needs some time to display them all. Just wait some more and it may work.
Q:	"Demonstration.html" looks like a bunch of empty rectangles describing the folder structure but I don't see any sprites.
A:	If your browser has already finished loading the page, this may be caused by your operating system. It should work but I have only tested it on Windows. You might be able to fix it by opening the file with Notepad and then replacing every occurence of "\\" with "/". Please send me an e-mail so I can examine it, further.
Q:	"Demonstration.html" contains a lot of images but I cannot see any of them.
A:	You need to unzip the archive, first. The file needs to be in a specific relation to the sprites because it accesses them. That means that moving, removing or renaming anything might cause it to cease displaying, correctly.
Q:	"Demonstration.html" contains a lot of images but they're all totally distorted.
A:	You probably zoomed in or out, causing the images not to be displayed in their original size. If you use Firefox, you can zoom in or out by holding the "Ctrl" key and then pressing "+" or "-", respectively. You can switch back to the original resolution by holding the "Ctrl" key and then pressing "0". I don't know about the other web browsers, though.
Q:	I successfully zoomed in and out by I cannot switch back to the original resolution.
A:	"0" is a number and not a letter. Pressing the letter "O", instead of the number "0" won't work. Pressing the number "0" might work if you pressed the one on the numpad without having the num key selected, before that. Just try out all of your keyboard's keys that resemble a "0" and you should be good to go.

Q:	Are the sprites 100% in their original form?
A:	The original files were in a binary format with 32 bits per pixel, line by line. I decoded each of the sprites' pixels into the PNG file format without changing any of the pixels' colors. However, the first 13 bytes of the files are something else which I had difficulties to read. They contain information about the image's resolution which I tried to automate the process but when looking at the images, I noticed that some of them were interpreted, incorrectly. If you see a sprite which is distorted to the point where it looks like a bunch of stripes, the automatism guessed the resolution wrong so you may want to manually correct them with a painting program. However, most of the files don't have that problem. Additionally, I saw some graphical errors which I cannot explain: You can see some weird, horizontal lines in the game's logo and some modes' previews. Also, I've seen weird purple clouds in the first stage's logo. You cannot see any of these errors in the game itself. However, the decoding process of the binary information into colory pixels was lossless so if the image looks OK, I'd say it is.
Q:	Some of the files look weird.
A:	The "assets" > "art" > "textures" > "backgrounds" folder consists of images which consist of only a single column. I think that they are looped to get the skies. Meanwhile, the "assets" > "art" > "textures" > "misc" folder contains images which look like color palettes which are used for changing the game's graphics style in some arena levels. If you don't know what I'm talking about, play all of the weekly challenges for several weeks and you may come across at least one of them. However, the same folder also contains a lot of images I cannot explain. I don't even know if they're in the correct resolution. The same goes for the image "assets" > "art" > "sprites" > "shops" > "vendor_table.png". I have no idea what they are. If, however, the image looks like something which was merely distorted and could theoretically be manually corrected, please read the previous question's answer.
Q:	No, I mean that the colors are all wrong and stuff.
A:	The official website contains some sprites. However, I would advise against using them because the website's sprites' colors are not identical to the ones in the game. I checked. Meanwhile, the sprites I ripped have exactly the same colors as in the game. I checked this using an emulator. Meanwhile, the videos have such a bad quality that it's impossible to get the colors from them, in the first place, even those in extreme close-up. I tried. Also, I'm pretty sure that some of the sprites' looks changed over time.
Q:	Why did you refer to the folders like that?
A:	Because each operating system seperates folders from each other, differently. Linux uses "/", Mac uses "\" and Windows uses both of them. I don't know about the other operating systems.
Q:	Why did you make an own program to decode these files?
A:	The files have the extension *.tex which, according to the internet, can be easily opened and/or converted with several programs. However, none of them worked so I made my own.
Q:	There already is a program for these kinds of files.
A:	Send me an e-mail, immediately!

Q:	Some of the sprites are missing.
A:	Are you referring to texts? Because this archive only contains graphics files. I also saw some font files in there which I didn't include because they aren't sprites.
Q:	No, I am not referring to texts.
A:	Are you referring to bodily parts? On this forum, I read that the game uses Spine despite being a pixel art game: http://ja.esotericsoftware.com/forum/Using-Spine-with-Pixelart-in-Dan-The-Man-7532
That means that some of the custom character's bodily parts are occasionally rotated by angles indivisible by 90 degrees. It wouldn't surprise me if this applied to some of the enemies, as well, since many of them look similar to some of the costumes you can give your custom character.
Q:	No, I am referring to sprites which are not in the game, at all!
A:	Since the game is frequently updated, there might already be a newer version containing new elements which are not here. You can get them by following the following steps:
	Step 1: Get an android device. A virtual one should work, too.
	Step 2: Download and install the game, as well as an app called "Apk Extractor".
	Step 3: Use Apk Extractor to get the *.apk file from the game.
	Step 4: Move the file to your computer somehow.
	Step 5: In your file manager, display the file extensions.
	Step 6: Rename the *.apk file to a *.zip file.
	Step 7: Unzip the archive into a separate folder.
	Step 8: Copy the files "Dan.bat" and "Dan.jar" from my archive into the folder.
	Step 9: Install the newest version of Java.
	Step 10: Double-click both files. But not one immediately after another. Wait a few minutes in between them. If you get any sort of feedback, you'll know if it worked or not. If it worked for one of them, you don't have to double-click the other one, anymore. At least one of them should work.
Q:	I used your program to get the sprites from the newest version of the game but they're missing.
A:	I was only able to rip the sprites because they were encoded in a very simple and relatively straightforward binary format. The creators of the game probably encrypted them in the newest version. Since I'm not very good at hacking, any kind of encryption would be too much for me.
Q:	No, the other sprites are OK. But the sprites I'm referring to are still missing.
A:	Are you referring to some of the enemies' recolors? Everything I decoded was the *.tex files because they contained direct graphical information. I expect all of the other files to be mere information about what files to use and where which of the sprites are and how to place them and stuff like that. However, it wouldn't surprise me if they also contained additional information about how to recolor the sprites for the recolors. Since the *.tex files are in a simple binary format, it should be theoretically easy to expand the program to create *.png files of recolors, as well.
Q:	No, I am not referring to recolors.
A:	The game contains a level where you can see videos of the previous stages. These videos are stored on the internet and not in the game itself. However, I actually saw a video file inside of the game. I didn't extract each frame from the video because I don't know how to do that, losslessly.
Q:	No, I am not referring to videos.
A:	Everything I decoded was the *.tex files. There could be more in the other files.
Q:	Well, the sprites I'm referring to are not exactly from the game...
A:	The Dan the Man franchise encompasses the mobile game, 7 previous videos, a website and a facebook page, as far as I know. If there is anything you want, I might be able to help you with downloading the things from the websites. If you want something that is only in the videos, there's not much hope for you because their quality is so bad that, while it is possible to manually recreate the sprites' shapes, the exact colors are almost impossible to reproduce. However, there might be more. For example: Valentine's Day 2017 had a special update where players could share some random pictures, one of which contained a high-quality picture of the princess from stage 1 and her tower. It's actually in this spritesheet! See: "assets" > "art" > "sprites" > "cinematic_refs" > "wardrobe_screenshots.png" If you find anything more, even if it seems minor, please tell me.
Q:	I found a way to decode files not originally stored as *.tex files.
A:	Send me an e-mail, immediately!

Q:	I found some sprites that are not in the game.
A:	If they really aren't in the game, they are either unused or leftovers from a previous version or both.
Q:	Can you separate the used sprites from the unused sprites?
A:	No.
Q:	I've found multiple sprites of something that look identical to each other. Which one should I use?
A:	Look at the filename and the folders it's in. If that doesn't help, I don't know.
Q:	Why are some of the sprites upscaled?
A:	Because they are like that in the game's files. I actually found some upscaled sprites and made some experiments with them and came to the conclusion that upscaling them was completely unneccessary. You should be able to scale them back down if you want. The creators of the game probably did this because simply displaying them with a larger size, programmatically, wasn't worth the work or something.

Q:	Can you also rip more than sprites?
A:	When looking into the game's files, I saw font files and sound files and music files, even a video file, all of which were completely unencrypted. You can get all of them by following the previously mentioned steps to step 7 and then simply looking at the files.
Q:	I looked into the game's files without using your program and I saw some images that were not included in your spritesheet.
A:	Not all graphical files of the game are encoded. Either the newest version of the game has added more sprites or I accidentally deleted them. The latter is the case if these images are not *.png files. Please send me an e-mail with the images' extensions.

Q:	I would like to regularly update your spritesheet by frequently adding more of the game's versions' sprites to it using your program.
A:	If you do that, please give credit and send me an e-mail every time you do. For more information, read "give credit and notify me.txt".
Q:	Your program simply added *.png files whereever there's a *.tex file. Do I have to remove everything which is not a graphics file, manually?
A:	Actually, I created another program for deleting everything which is not a *.png file and then deleting all empty folders. Send me an e-mail if you want me to give it to you. By the way, that's also the reason why the spritesheet also contains other image files of the game that were not originally encoded, but only if they were also *.png files.
Q:	I would also like to update the "Demonstration.html" file. Will I have to do that, manually?
A:	Actually, I created another program for creating that file. Send me an e-mail if you want me to give it to you.
Q:	I would like to see the source code of the program or parts of it or expand or otherwise modify the program.
A:	Read "give credit and notify me.txt" for more information about that.

Q:	Why did you give so many weird instructions, instead of just fixing the errors, yourself?
A:	The entire spritesheet was created, automatically. The only thing I did, manually, was looking at the sprites. And this only applies to the "art" folder. The folder structure is so vast and expansive that it would have been too much work for me to fix them all.
Q:	I would like to fix some of the sprites and/or add the missing sprites by following your weird instructions.
A:	Please contact me before you do anything, manually, because I might be able to save you a lot of time.
Q:	If I change the sprites, will this change the game?
A:	The program I used to decode the sprites doesn't work both ways. However, it would be theoretically possible to expand it. If you already want to start working, please at least use a painting program which supports alpha channels because if it doesn't the alpha channel might get lost. Microsoft Paint doesn't support alpha channels. Read "give credit and notify me.txt" for more information about expanding the program.
Q:	Please expand the program.
A:	Send me an e-mail and tell me, how exactly you want me to expand the program and why. If you want to do something awesome and/or I get contacted by many people I may think about it.
Q:	I want to use the sprites and you to help me.
A:	Send me an e-mail with the details and I'll see what I can do.
Q:	What's your e-mail address?
A:	Read "give credit and notify me.txt" for more information about contacting me.



TL;DR:

If you just want to use the sprites, right ahead, and don't have any questions, the only thing important for you is this:
The folder "Dan The Man_com.halfbrick.dantheman" contains the newest version so you should start looking, there.
The sprites interesting for you are probably OK but please check if they look alright before using them, anyway.
Also, read the file "give credit and notify me.txt" before using them for anything you publish, anywhere.