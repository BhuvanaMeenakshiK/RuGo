# RuGo
USC CSCI538 Augmented, Virtual, and Mixed Reality course team project.

# Team Members
- [Michael Root](https://github.com/nemosx)
- [Kishore Venkateshan](https://github.com/kv3n)
- [Hsuan-Hau (Howard) Liu](https://github.com/hsuanhauliu)
- [Darwin Mendyke](https://github.com/NiwradMendyke)
- [Abhishek Bhatt](https://github.com/abhatt95)
- [Devashree Shirude](https://github.com/DevaShirude)
- [Sarah Riaz](https://github.com/sriaz08)

--------------------

# Project Overview

## Key Abstractions

### Gadget

Gadgets are the objects from which our Rube Goldberg machine is built with. Each concrete Gadget such as **BoxGadget, DominoGadget, BallGadget** derive from the abstract Gadget class.

The Gadget class manages shared concerns such as transparency, solidification, and toggling between physics modes.

### GameManager

The **GameManager** manages the current mode of the game. It listens for user input to open the GadgetShelf.


Currently there are three modes.

* Build Mode - The default mode in which the player can pick gadgets in the world for manipulation

* Select Mode - The mode that is set when the GadgetShelf is visible

* Draw Mode - The mode that is set when Draw/Path tooling is enabled

* Delete Mode - Gadgets touched in delete mode are deleted from the scene.


## World

A collection of Gadgets that have been inserted into the scene. The world also manages auto saving to a current save slot.


## Adding New Gadgets

**This guide is subject to change and is intended to only give a rough overview**


1. Create a prefab in the resources folder with the name of your gadget.
2. Attach a YourGadget.cs file to your prefab. YourGadget.cs must extend the **Gadget** abstract class.
3. Add the name of your gadget, which matches the name in the resources directory, to the GadgetInventory enum inside Gadget.cs.
--------------------

# Development Guidelines

## Scenes

Each developer has a scene with their usc email id as the name of the scene. Please do all your testing / feature work on this scene and please **do not interfere with the Master** scene. The person doing the integrations will be responsible for collecting all the necessary working bits from each scene and merging onto the Master. This way we can keep a consistent, compilable and working build at the end of each week.

## Scripts

Each developer also should **create a folder inside the global Scripts folder** with their usc email id as the name of their scripts folder. Please insert all your scripts here and work locally on them as much as possible. If there is a need to reuse a script and you feel like you need to edit that script, make sure you communicate that need with the author of that script. This way we can avoid a lot of unnecessary merge conflict issues.

Every week when the integrations are performed, the necessary scripts will be brought into a **Master folder inside the Scripts folder**. This again will help us keep a compilable and working build at the end of each week.

## Prefabs

Similar to Scripts, before creating your prefab ensure that you create a folder with your usc email id as the name of the folder inside the **global Prefabs folder**. Drag and drop your prefabs into this folder and try to keep it as localized as possible. If a change is need in the prefab, please let the author know that you will be making changes to the respective prefab.

Every week when the integrations are performed, the necessary prefabs will be brought into a **Master folder inside the Prefabs folder**. All references will be carefully looked at to make sure there are no broken references. This again will help us keep a compilable and working build at the end of each week.

## Materials and Textures

Every time you create a new material for your scene, please place the material in the **Materials** folder. Please be thoughtful when it comes to naming your materials so that it can be reused by others when building their prototypes.

We will follow the same principle for **Textures** folder as well. Good descriptive names go a long way into helping others search for the material and/or textures they want to use with their prototypes.

# Demystifying Unity

## Awake vs Start vs OnEnabled

At the outset these functions appear to do exactly the same thing but this is not true. The general ordering is, Awake runs first, then OnEnabled and then Start.

But the difference is as follows
- Awake and Start run only once when the object is first initialized to the scene. Where as OnEnabled runs every time you SetActive a deactivated object or every time you SetActive the script component.
- If an object and the script is active, both Awake and Start are called. But if the object is active and script is not active when we first start the game, only Awake is called. Start is called at a later time when the script is first activated.

# Game Input Controls

### Keyboard Bindings

Q - opens/closes the Gadget Shelf 



## Needed Features
- Real world setting for the gadgets in AR.

## Future Gadget Ideas
- Tracks
- Conveyor belt
- Support beams
- Bridge (sort of like a track)
- Trap door

### Schedule
Week 1 (10/25 ~ 10/31):
- Start working on physics, re-scaling gadgets, UI, sound, VR space design
- Fix current bugs
- Implement gadget deletion in VR

Week 2 (11/1 ~ 11/7):
- Finish up gadget physics, re-scaling gadgets, VR space
- Gadget compatibility, textures, and models re-design
- Continue working on UI, sound

Week 3 (11/8 ~ 11/14):
- Experiment with VIVE tracker
- Finish up UI, sound
- Start implementing start and end gadgets

Week 4 (11/15 ~ 11/21):
- Camera viewpoint implementation
- Gadget refinement, final testing

Week 5 (11/22 ~ 11/28):
- Final testing and make sure everything is ready for final demo
