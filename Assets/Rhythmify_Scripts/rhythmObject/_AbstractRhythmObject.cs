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
        private int beatCount = 0;

        public void Start() {
            GameObject[] bgmContainers = GameObject.FindGameObjectsWithTag("Rhythmify_Music");
            if (bgmContainers.Length > 1) {
                Debug.LogError("This scene contains more than 1 background music.");
                Debug.Break();
            }
            else if (bgmContainers.Length < 1) {
                Debug.LogError("This scene must contain 1 GameObject tagged with \"Rhythmify_Music\".");
                Debug.Break();
            }

            GameObject bgmContainer = GameObject.FindGameObjectWithTag("Rhythmify_Music");
        
            audioSource = bgmContainer.GetComponent<AudioSource>();
            audioClip = audioSource.clip;
        
            BPM = bgmContainer.GetComponent<MusicWrapper>().BPM;
        
            secondsPerBeat = 60.0f / BPM;
            samplesPerBeat = secondsPerBeat * audioClip.frequency;

            init();
        }
    
        public void Update() {
            int beat = (int)(audioSource.timeSamples / samplesPerBeat);
        
            if (beat != lastBeatUpdate) {
                lastBeatUpdate = beat;
                rhythmUpdate(beatCount++);
            }

            asyncUpdate();
        }
    
        protected bool onBeat(float deltaSeconds) {
            float beatOffset = audioSource.timeSamples % samplesPerBeat;
            float deltaSamples = deltaSeconds * audioClip.frequency;
            return beatOffset < deltaSamples || samplesPerBeat - beatOffset < deltaSamples;
        }

        protected virtual void init() {
        }

        protected virtual void asyncUpdate() {
        }

        protected abstract void rhythmUpdate(int beat);
    }
}
