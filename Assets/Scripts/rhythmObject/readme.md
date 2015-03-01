This directory contains scripts that control GameObjects with the beat of the music.

##Scripts
- **[_AbstractRhythmObject.cs](#_AbstractRhythmObject.cs):** Contains basic framework common to all rhythm synced game objects
- **[MoveToPositions.cs](#MoveToPositions.cs):** Moves a GameObject to a list of specified positions.
- **[RotateToEulers.cs](#RotateToEulers.cs):** Rotates a GameObject to a list of specified Euler angles.

##Script Documentation
###<a name="_AbstractRhythmObject.cs"></a>[_AbstractRhythmObject.cs](./AbstractRhythmObject.cs)
This script contains the basic framework for synchronizing events with the beat.
####Usage
To create your own script that does things with the beat of the music, create a script that extends `_AbstractRhythmObject` instead of `MonoBehaviour`. Then implement the `rhythmUpdate()` function, which gets executed once every beat.

**Important:** Remove the `Start()` and `Update()` functions that Unity generates for you in your subclasses, otherwise you may get unexpected results when extending this class.
####Useful Fields
- **`protected int BPM`:** Tempo of the audio clip in beats per minute.
- **`protected float samplesPerBeat`:** The number of audio samples in one beat.
- **`protected float secondsPerBeat`:** The number of seconds in one beat.

####Useful Functions
- **`protected virtual void asyncUpdate()`:** This is the replacement for the `Update()` that Unity generates.
- **`protected abstract void rhythmUpdate(int beat)`:** This function will be executed once every beat.  

  *Parameters:*  
  **`beat`:** The number of beats that have elapsed since the beginning of the clip

- **`protected bool onBeat(float deltaSeconds)`:** This function will return true if the current time is close enough to a beat. This allows you to detect whether player input is on beat or not.  
  
  *Parameters:*  
  **`deltaSeconds`:** The number of seconds that the current time can be off by. Note that the window of time is twice as long, since this checks before and after the beat.

___
###<a name="MoveToPositions.cs"></a>[MoveToPositions.cs](./MoveToPositions.cs)
This script is an example usage of [`_AbstractRhythmObject`](#_AbstractRhythmObject.cs). This translates a GameObject through a list of positions, one at a time, in a round-robin style.

####Usage
To use this script, attach it to a GameObject. Then specify the positions that you want the GameObject to travel through in the inspector.

####Useful Fields
- **`public int offset`:** The position that you want to start at.
- **`public Vector3[] positions`:** The list of positions that the GameObject will travel through.

___
###<a name="RotateToEulers.cs"></a>[RotateToEulers.cs](./RotateToEulers.cs)
This script is an example usage of [`_AbstractRhythmObject`](#_AbstractRhythmObject.cs). This rotates a GameObject through a list of Euler angle rotations, one at a time, in a round-robin style.

####Usage
To use this script, attach it to a GameObject. Then specify the rotations that you want the GameObject to travel through in the inspector.

####Useful Fields
- **`public Vector3[] eulerAngles`:** This list of Euler angle rotations that the GameObject will rotate through.
- **`public int offset`:** The rotation that you want to start at.
- **`public bool spherical`:** If true, this will use spherical interpolation instead of linear interpolation.

___
