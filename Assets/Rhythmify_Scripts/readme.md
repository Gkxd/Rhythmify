This directory contains all of the scripts in this library.

##Subdirectories
- **[rhythmObject](./rhythmObject):** Contains scripts that sync GameObjects to the beat of the music.

___
##Scripts
- **[MusicWrapper.cs](#MusicWrapper.cs):** Used to hold information about audio clips.

___
##Script Documentation
###<a id="MusicWrapper.cs"></a>[MusicWrapper.cs](./MusicWrapper.cs)
This script holds user-specified information about audio clips.
####Usage
To use this script, attach it as a component to a GameObject that has an AudioSource component. Then set the tag of that GameObject to `"Rhythmify_Music"`.
######For looping audio tracks:
- If the entire audio track is meant to loop, then set `loopLength` and `loopThreshold` to 0.
- If the audio track consists of an introduction section followed by a looping portion
 1. Using an external audio editing program, create an audio track of the following form:  
 **[intro][loop][1st few seconds of loop]**  
 That is, concatenate the looping portion to the intro portion, then concatenate another small portion of the looping portion to that.
 2. Set `loopLength` to the length of the looping portion in seconds.
 3. Set the `loopThreshold` to some time greater than the length of the intro + one loop, but less than the length of the entire track you created in step 1.

####Field Summary
Type and Modifiers | Field Name
--- | ---:
`public int` | [`BPM`](#BPM)
`public float` | [`loopLength`](#loopLength)
`public float` | [`loopThreshold`](#loopThreshold)

####Field Descriptions
<a name="BPM"></a>
>**`public int BPM`**  
>Tempo of the audio clip in beats per minute.

<a name="loopLength"></a>
>**`public float loopLength`**  
>The length of the looping portion of the audio clip in seconds. Only used for audio clips that have a non-looping intro and a looping part. Set to 0 if there is no non-looping intro. 

<a name="loopThreshold"></a>
>**`public float loopThreshold`**  
>Amount of seconds to wait before looping back partially. Only used for audio clips that have a non-looping intro and a looping part. Set to 0 if there is no non-looping intro.

___
