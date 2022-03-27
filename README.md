# Δ Type

This program was made by [Denneth Ahles](https://denneth.nl)

## Abstract

A small program to search for and type out characters or collections of characters, such as engineering characters (Δ Ω μ etc.), General use Unicode (© € ± etc.), or any other user defined characters, all without having to use your mouse.

## Usage

After running the program, simply press (Control + D) to open the pop-up.

![Delta Type](https://user-images.githubusercontent.com/26671826/160284672-2721639f-b0e1-4e45-a37a-c221ff207bbc.png)

Type in text to have it automagically search for characters (typing "del" returns the 2 delta characters for example)

![Searching For Delta](https://user-images.githubusercontent.com/26671826/160284811-1b7a5247-9b5b-43e5-a91c-cba6461de6fb.png)

Press enter to type out the most left one currently on screen, hold shift to only show capitals (search for "del" returns 'δ' and 'Δ', pressing enter types 'δ', but holding shift and pressing enter returns 'Δ' )

![Holding Shift](https://user-images.githubusercontent.com/26671826/160284803-4d0c4f88-6dd8-4f57-9445-652c75492521.png)

Clicking a character types it out, holding control and clicking a character copies it to the clipboard

## Configuration

Δ Type comes with a system tray icon.

![Icon](https://user-images.githubusercontent.com/26671826/160285012-80e4d019-ce53-48c8-ab2a-feea23d520d3.png)

Simply right click the Δ icon in your system tray, which gives you the option to either close the program, or open settings.

![Settings](https://user-images.githubusercontent.com/26671826/160285003-fa181f54-32f7-4a72-a5e8-453fa08edfe1.png)

The settings menu includes a way to change the shortcut to open the program, a toggle on whether to open at startup or not, and a character definition manager.

![Settings Menu](https://user-images.githubusercontent.com/26671826/160285024-8472c8ba-46ab-4f15-93e1-2479edad5e1d.png)

To create a new character set, simply fill in a name, and press "Create".

![Creating a set](https://user-images.githubusercontent.com/26671826/160285032-fa1dda49-a2dc-467d-b128-2acb03ed1c23.png)

You can toggle between them by selecting them in the list provided.

![Toggle](https://user-images.githubusercontent.com/26671826/160285036-cee75bd0-8721-41df-b6e0-ba2bc9af0360.png)

By pressing edit it opens the definition in your default text editor.

![Opened Config](https://user-images.githubusercontent.com/26671826/160285058-4ec62eea-326e-4c74-ae2b-9fc8d8c84320.png)

## Creating character definitions

The current implementation is as follows:

- Beginning a line with # makes it a comment, allowing you to put any text there without consequences.

- Every character definition is made up of two parts
  
  - The name of the character
  
  - The character
  
  - These are separated by a comma
  
  - Any space between the comma and the character string is automatically filtered out (adding "trademark, ™" will return "™" not " ™"
  
  - You can add as many characters definitions as you want, which also enables search synonyms, by simply adding the same character under different names.

- A character can be any text, such as "A", "λ" or "Km/h".
  
  - Kudos to the [Unicode Consortium](https://home.unicode.org/) for making this possible in the first place.

- The name is what you search for to find the character (π is named "pi")
  
  - The program is case insensitive (ignores the difference between upper and lowercase)

- Adding "upper" to the name allows filtering it using shift
  
  - For example, 'δ' is named "delta", but 'Δ' is named "delta upper"

```
#here is an example file, adding both variants of delta, and a trademark symbol
delta, δ
delta upper, Δ
trademark, ™
tm, ™
```

A standard character file is included with every installation, which includes the Greek alphabet (such as: λ, Δ, α, β, γ, π, Ω etc. for engineering and physics), some currency and trademark symbols (such as: ₽, €, ©, ™ etc.), and mathematical symbols (such as ±, ∞, √, ½, ² etc.)

If you have any characters you want, or think you wont need, you can simply edit the character definition file to suit your needs.

## Why

Why did I make this?

Well, I am a huge space nerd, and in space travel, the usual denotation for how much energy you still have left (how much you can "move"" with the current fuel), is ΔV, which is science for change in velocity.

Now, since I'm not Greek, I don't have Δ on my keyboard, and typing out "Delta" just isn't the same.

So I set to work making a program, mainly so I could type the character Δ without having to pick up my mouse, switch to a browser, and copy the Unicode off the internet.

Hence the name, Δ Type.

So anyone talking about [Kerbal Space Program](https://www.kerbalspaceprogram.com/), or trying to search for [ΔV: Rings of Saturn](https://games.kodera.pl/dv/) in their [Steam](https://store.steampowered.com/) library, can now more easily do so! 


