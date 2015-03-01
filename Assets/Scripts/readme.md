This directory contains all of the scripts in this library.

##Subdirectories
- **[rhythmObject](./rhythmObject):** Contains scripts that sync GameObjects to the beat of the music.

##Scripts
- **[MusicWrapper.cs](#MusicWrapper.cs):** Used to pass along information about the background music

##Script Documentation
####[MusicWrapper.cs](./MusicWrapper.cs)
#####Important Fields
- `BPM`: Tempo of the audio clip in beats per minute.
- `loopLength`: The length of the looping portion of the audio clip in seconds. Only used for audio clips that have a non-looping intro and a looping part. Set to 0 if there is no non-looping intro. 
- `loopThreshold`: Amount of seconds to wait before looping back partially. Only used for audio clips that have a non-looping intro and a looping part. Set to 0 if there is no non-looping intro.