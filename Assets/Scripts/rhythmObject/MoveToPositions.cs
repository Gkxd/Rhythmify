/* @Author: Gkxd
 * 
 * Moves a GameObject to a list of specified positions
 * 
 * */
using UnityEngine;
using System.Collections;

namespace Rhythmify {
    public class MoveToPositions : _AbstractRhythmObject {
        public Vector3[] positions;
        public int offset;
    
        override protected void rhythmUpdate(int beat) {
            int size = positions.Length;
        
            if (size <= 1) {
                return;
            }
        
            int idx = beat + offset;
        
            StartCoroutine(move(positions [idx % size], positions [(idx + 1) % size], secondsPerBeat));
        }
    
        private IEnumerator move(Vector3 startPos, Vector3 endPos, float duration, float beatMod = 1) {
            //duration = seconds per beat.
            float startTime = Time.time;
        
            while (Time.time <= startTime + duration) {
                float lerpPercent = Mathf.Clamp01((Time.time - startTime) / (duration * beatMod));
                transform.position = Vector3.Lerp(startPos, endPos, lerpPercent);
                yield return null;
            }
        }
    }
}
