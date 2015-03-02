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
        public int[] indices;
        public int offset;
        public bool local;
    
        override protected void rhythmUpdate(int beat) {
            int size = positions.Length;
        
            if (size <= 1) {
                return;
            }
            
            int idx = beat + offset;
            if (indices.Length > 0) {
                int idxA = indices[idx % indices.Length];
                int idxB = indices[(idx + 1) % indices.Length];
                StartCoroutine(move(positions [idxA % size], positions [idxB % size], secondsPerBeat));
            }
            else {
                StartCoroutine(move(positions [idx % size], positions [(idx + 1) % size], secondsPerBeat));
            }
        }
    
        private IEnumerator move(Vector3 startPos, Vector3 endPos, float duration) {
            float startTime = Time.time;
            if (local) {
                while (Time.time <= startTime + duration) {
                    float lerpPercent = Mathf.Clamp01((Time.time - startTime) / duration);
                    transform.localPosition = Vector3.Lerp(startPos, endPos, lerpPercent);
                    yield return null;
                }
            }
            else {
                while (Time.time <= startTime + duration) {
                    float lerpPercent = Mathf.Clamp01((Time.time - startTime) / duration);
                    transform.position = Vector3.Lerp(startPos, endPos, lerpPercent);
                    yield return null;
                }
            }
        }
    }
}
