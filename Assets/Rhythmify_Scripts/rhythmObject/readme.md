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

####Field Summary
Type and Modifiers | Field Name
--- | ---:
`protected int` | [`BPM`](#BPM)
`protected float` | [`samplesPerBeat`](#samplesPerBeat)
`protected float` | [`secondsPerBeat`](#secondsPerBeat)

####Field Descriptions
<a name="BPM"></a>
>**`protected int BPM`**  
>Tempo of the audio clip in beats per minute.

<a name="samplesPerBeat"></a>
>**`protected float samplesPerBeat`**  
>The number of audio samples in one beat.

<a name="secondsPerBeat"></a>
>**`protected float secondsPerBeat`**  
>The number of seconds in one beat.

####Function Summary
Return Type and Modifiers | Function Name and Parameters
--- | ---:
`protected virtual void` | [`asyncUpdate()`](#asyncUpdate)
`protected abstract void` | [`rhythmUpdate(int beat)`](#rhythmUpdate)
`protected bool` | [`onBeat()`](#onBeat)

####Function Descriptions
<a name="asyncUpdate()"></a>
>**`protected virtual void asyncUpdate`**  
>This is the replacement for the `Update()` that Unity generates.

<a name="rhythmUpdate"></a>
>**`protected abstract void rhythmUpdate(int beat)`**  
>This function will be executed once every beat.  
>######Parameters:
>- **`beat`:** The number of beats that have elapsed since the beginning of the clip

<a name="onBeat"></a>
>**`protected bool onBeat(float deltaSeconds)`**  
>This function will return true if the current time is close enough to a beat. This allows you to detect whether player input is on beat or not.  
>######Parameters:
>- **`deltaSeconds`:** The number of seconds that the current time can be off by. Note that the window of time is twice as long, since this checks before and after the beat.

___
###<a name="MoveToPositions.cs"></a>[MoveToPositions.cs](./MoveToPositions.cs)
This script is an example usage of [`_AbstractRhythmObject`](#_AbstractRhythmObject.cs). This translates a GameObject through a list of positions, one at a time, in a round-robin style.

####Usage
To use this script, attach it to a GameObject. Then specify the positions that you want the GameObject to travel through in the inspector.

####Field Summary
Type and Modifiers | Field Name
--- | ---:
`public bool` | [`local`](#local0)
`public int` | [`offset`](#offset0)
`public Vector3[]` | [`positions`](#positions)

####Field Descriptions
<a name="local0"></a>
>**`public bool local`**
>If true, will transform relative to local coordinates instead of world coordinates.

<a name="offset0"></a>
>**`public int offset`**
>The position that you want to start at.

<a name="positions"></a>
>**`public Vector3[] positions`**
>The list of positions that the GameObject will travel through.

___
###<a name="RotateToEulers.cs"></a>[RotateToEulers.cs](./RotateToEulers.cs)
This script is an example usage of [`_AbstractRhythmObject`](#_AbstractRhythmObject.cs). This rotates a GameObject through a list of Euler angle rotations, one at a time, in a round-robin style.

####Usage
To use this script, attach it to a GameObject. Then specify the rotations that you want the GameObject to travel through in the inspector.

####Field Summary
Type and Modifiers | Field Name
--- | ---:
`public Vector3[]` | [`eulerAngles`](#eulerAngles)
`public bool` | [`local`](#local1)
`public int` | [`offset`](#offset1)
`public bool` | [`spherical`](#spherical)

####Field Descriptions
<a name="eulerAngles"></a>
>**`public Vector3[] eulerAngles`**  
>This list of Euler angle rotations that the GameObject will rotate through.

<a name="local1"></a>
>**`public bool local`**  
>If true, will transform relative to local coordinates instead of world coordinates.

<a name="offset1"></a>
>**`public int offset`**  
>The rotation that you want to start at.

<a name="spherical"></a>
>**`public bool spherical`**  
>If true, this will use spherical interpolation instead of linear interpolation.

___
