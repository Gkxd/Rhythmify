This directory contains scripts that control GameObjects with the beat of the music.

##Scripts
- **[_AbstractRhythmObject.cs](#_AbstractRhythmObject.cs):** Contains basic framework common to all rhythm synced game objects
- **[ChangeColors.cs](#ChangeColors.cs):** Applies color transitions to a game object.
- **[MoveToPositions.cs](#MoveToPositions.cs):** Moves a GameObject to a list of specified positions.
- **[RotateToEulers.cs](#RotateToEulers.cs):** Rotates a GameObject to a list of specified Euler angles.

##Script Documentation
###<a name="_AbstractRhythmObject.cs"></a>[_AbstractRhythmObject.cs](./_AbstractRhythmObject.cs)
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
`protected virtual void` | [`init()`](#init)
`protected abstract void` | [`rhythmUpdate(int beat)`](#rhythmUpdate)
`protected bool` | [`onBeat()`](#onBeat)

####Function Descriptions
<a name="asyncUpdate"></a>
>**`protected virtual void asyncUpdate()`**  
>This is the replacement for the `Update()` function that Unity generates.

<a name="init"></a>
>**`protected virtual void init()`**  
>This is the replacement for the `Start()` function that Unity generates.

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
###<a name="ChangeColors.cs"></a>[ChangeColors.cs](./ChangeColors.cs)
This script is an example usage of [`_AbstractRhythmObject`](#_AbstractRhythmObject.cs). This applies a series of color transitions to a GameObject if the GameObject has a material with a color setting.

####Usage
To use this script, attach it to a GameObject. Then specify the color transitions that you want to apply to the GameObject.

<a name="ColorTransition"></a>
######ColorTransition
This script uses a second class called `ColorTransition`. `ColorTransitions` is a container for holding information relevant to a color transition. The field descriptions for a `ColorTransition` is as follows:
<a name="endColor"></a>
>**`public Color endColor`**
>The ending color of the transition.

<a name="smooth"></a>
>**`public bool smooth`**
>Determines whether the transition will be smooth or not. If true, [`startColor`](#startColor) and [`endColor`](#endColor) will be interpolated in the middle of a beat. If false the material color will be immediately set to [`endColor`](#endColor).

<a name="startColor"></a>
>**`public Color startColor`**  
>The starting color of the transition. This will only be used if [`smooth`](#smooth) is true.

####Field Summary
Type and Modifiers | Field Name
--- | ---:
`public ColorTransition[]` | [`colorTransitions`](#colorTransitions)
`public int[]` | [`indices`](#ChangeColors_indices)
`public int` | [`offset`](#ChangeColors_offset)
`public bool` | [`shared`](#shared)

####Field Descriptions
<a name="colorTransitions"></a>
>**`public ColorTransition[] colorTransitions`**  
>The list of [`ColorTransition`](#ColorTransition) objects that you want to apply to a GameObject.

<a name="ChangeColors_indices"></a>
>**`public int[] indices`**  
>Indices into the [`colorTransitions`](#colorTransitions) array that specfies the order in which the color transitions will be applied to the GameObject. If the size of this array is 0, the color transitions in the [`colorTransitions`](#colorTransitions) array will be used in a round-robin style. If a negative index is specified, the current color will be held.

<a name="ChangeColors_offset"></a>
>**`public int offset`**  
>If [`indices`](#ChangeColors_indices) has 0 elements, this is the index of [`colorTransitions`](#colorTransitions) array that you want to start at. Otherwise, this is the index of the [`indices`](#ChangeColors_indices) array that you want to start at.

<a name="shared"></a>
>**`public bool shared`**  
>If true, this will change the shared material's color instead of creating a copy of the material. Use this if you want every object that uses the material to be changed in the same way. Changes to the shared material will stay after the game resets.

___
###<a name="MoveToPositions.cs"></a>[MoveToPositions.cs](./MoveToPositions.cs)
This script is an example usage of [`_AbstractRhythmObject`](#_AbstractRhythmObject.cs). This translates a GameObject through a list of positions, one at a time, in a round-robin style by default.

####Usage
To use this script, attach it to a GameObject. Then specify the positions that you want the GameObject to travel through in the inspector.

####Field Summary
Type and Modifiers | Field Name
--- | ---:
`public int[]` | [`indices`](#MoveToPositions_indices)
`public bool` | [`local`](#MoveToPositions_local)
`public int` | [`offset`](#MoveToPositions_offset)
`public Vector3[]` | [`positions`](#positions)
`public bool` | [`relative`](#MoveToPositions_relative)
`public bool` | [`rigid`](#MoveToPositions_rigid)

####Field Descriptions
<a name="MoveToPositions_indices">
>**`public int[] indices`**  
>Indices into the [`positions`](#positions) array that specfies the order of the positions through which the GameObject will travel. If the size of this array is 0, the positions in the [`positions`](#positions) array will be used in a round-robin style.

<a name="MoveToPositions_local"></a>
>**`public bool local`**  
>If true, will transform relative to local coordinates instead of world coordinates. This field is ignored if [`rigid`](#MoveToPositions_rigid) is true.

<a name="MoveToPositions_offset"></a>
>**`public int offset`**  
>If [`indices`](#MoveToPositions_indices) has 0 elements, this is the index of [`positions`](#positions) array that you want to start at. Otherwise, this is the index of the [`indices`](#MoveToPositions_indices) array that you want to start at.

<a name="positions"></a>
>**`public Vector3[] positions`**  
>The list of positions that the GameObject will travel through.

<a name="MoveToPositions_relative"></a>
>**`public bool relative`**  
>If true, the positions in the [`positions`](#positions) array are relative to the start position of the GameObject.

<a name="MoveToPositions_rigid"></a>
>**`public bool rigid`**  
>If true, this will use rigid body transforms instead.
___
###<a name="RotateToEulers.cs"></a>[RotateToEulers.cs](./RotateToEulers.cs)
This script is an example usage of [`_AbstractRhythmObject`](#_AbstractRhythmObject.cs). This rotates a GameObject through a list of Euler angle rotations, one at a time, in a round-robin style by default.

####Usage
To use this script, attach it to a GameObject. Then specify the rotations that you want the GameObject to travel through in the inspector.

####Field Summary
Type and Modifiers | Field Name
--- | ---:
`public Vector3[]` | [`eulerAngles`](#eulerAngles)
`public int[]` | [`indices`](#RotateToEulers_indices)
`public bool` | [`local`](#RotateToEulers_local)
`public int` | [`offset`](#RotateToEulers_offset)
`public bool` | [`rigid`](#RotateToEulers_rigid)
`public bool` | [`spherical`](#spherical)

####Field Descriptions
<a name="eulerAngles"></a>
>**`public Vector3[] eulerAngles`**  
>The list of Euler angle rotations that the GameObject will rotate through.

<a name="RotateToEulers_indices">
>**`public int[] indices`**  
>Indices into the [`eulerAngles`](#eulerAngles) array that specfies the order of the rotations through which the GameObject will travel. If the size of this array is 0, the rotations in the [`eulerAngles`](#eulerAngles) array will be used in a round-robin style.

<a name="RotateToEulers_local"></a>
>**`public bool local`**  
>If true, will transform relative to local coordinates instead of world coordinates. This field is ignored if [`rigid`](#RotateToEulers_rigid) is true.

<a name="RotateToEulers_offset"></a>
>**`public int offset`**  
>If the [`indices`](#RotateToEulers_indices) array has 0 elements, this is the index of the [`eulerAngles`](#eulerAngles) that you want to start at. Otherwise, this is the index of the [`indices`](#RotateToEulers_indices) array that you want to start at.

<a name="RotateToEulers_rigid"></a>
>**`public bool rigid`**  
>If true, this will use rigid body transforms instead.

<a name="spherical"></a>
>**`public bool spherical`**  
>If true, this will use spherical interpolation instead of linear interpolation.

___
