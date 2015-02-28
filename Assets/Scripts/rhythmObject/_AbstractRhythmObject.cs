/* @Author: Gkxd
 * 
 * Contains basic framework that syncs objects to the beat
 * 
 * */

using UnityEngine;
using System.Collections;

namespace Rhythmify {
public abstract class _AbstractRhythmObject : MonoBehaviour {
    protected int BPM;
    protected float samplesPerBeat;
    protected float secondsPerBeat;
    private AudioSource audioSource;
    private AudioClip audioClip;
    private int lastBeatUpdate = -1;

    public void Start() {
        GameObject bgmContainer = GameObject.FindGameObjectWithTag("Rhythmify_Music");
        
        audioSource = bgmContainer.audio;
        audioClip = audioSource.clip;
        
        BPM = bgmContainer.GetComponent<MusicWrapper>().BPM;
        
        secondsPerBeat = 60.0f / BPM;
        samplesPerBeat = secondsPerBeat * audioClip.frequency;
    }
    
    public void Update() {
        int beat = (int)(audioSource.timeSamples / samplesPerBeat);
        
        if (beat != lastBeatUpdate) {
            lastBeatUpdate = beat;
            rhythmUpdate(beat);
        }
        
        asyncUpdate();
    }
    
    protected bool onBeat(float deltaSeconds) {
        float beatOffset = audioSource.timeSamples % samplesPerBeat;
        float deltaSamples = deltaSeconds * audioClip.frequency;
        return beatOffset < deltaSamples || samplesPerBeat - beatOffset < deltaSamples;
    }

    protected virtual void asyncUpdate() {
    }

    protected abstract void rhythmUpdate(int beat);
}
}
