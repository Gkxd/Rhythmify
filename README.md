# Rhythmify
A Rhythm Syncing Implementation for Unity

#### Overview
This project provides scripts that allow game objects to be synchronized with the tempo of an audio track, which is useful for rhythm based games.

#### Basic Usage
An example of basic usage is provided in the [_Scene](./Assets/_Scene) directory.

#### Instructions for setting up:
1. Copy the [Rhythmify_Scripts](./Assets/Rhythmify_Scripts) directory into your Unity project.
2. To sync an audio track, first create an audio source GameObject with your audio track.
3. Tag the audio source with `"Rhythmify_Music"`. Each scene should only have one active object tagged with `"Rhythmify_Music"` at a time.
4. To control a game object with the beat, create a script that extends `_AbstractRhythmObject`, or use one of the existing scripts inside the [rhythmObject](./Assets/Rhythmify_Scripts/rhythmObject) directory, and add the script to the game object as a component.

For more detailed information, see the documentation in the [Rhythmify_Scripts](./Assets/Rhythmify_Scripts) directory.
___
