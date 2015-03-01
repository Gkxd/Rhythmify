This directory contains all of the scripts in this library.

##Subdirectories
- **[rhythmObject](./rhythmObject):** Contains scripts that sync GameObjects to the beat of the music.

##Scripts
- **[MusicWrapper.cs](#MusicWrapper.cs):** Used to hold information about audio clips.

##Script Documentation
####<a id="MusicWrapper.cs"></a>[MusicWrapper.cs](./MusicWrapper.cs)
This script holds user-specified information about audio clips. To use this script, attach it as a component to a GameObject that has an AudioSource component. Then set the tag of that GameObject to *Rhythmify_Music*.
#####Important Fields
- `BPM`: Tempo of the audio clip in beats per minute.
- `loopLength`: The length of the looping portion of the audio clip in seconds. Only used for audio clips that have a non-looping intro and a looping part. Set to 0 if there is no non-looping intro. 
- `loopThreshold`: Amount of seconds to wait before looping back partially. Only used for audio clips that have a non-looping intro and a looping part. Set to 0 if there is no non-looping intro.