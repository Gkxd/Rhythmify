/* @Author: Gkxd
 * 
 * Rotates a GameObject to a list of specified Euler angles
 * 
 * */
using UnityEngine;
using System.Collections;

namespace Rhythmify {
    public class RotateToEulers : _AbstractRhythmObject {
        public Vector3[] eulerAngles;
        public int offset;
        public bool local;
        public bool spherical;
    
        override protected void rhythmUpdate(int beat) {
            int size = eulerAngles.Length;
        
            if (size <= 1) {
                return;
            }
        
            int idx = beat + offset;
        
            Quaternion startRot = Quaternion.Euler(eulerAngles [idx % size]);
            Quaternion endRot = Quaternion.Euler(eulerAngles [(idx + 1) % size]);
        

            StartCoroutine(rotate(startRot, endRot, secondsPerBeat));
        }
    
        private IEnumerator rotate(Quaternion startRot, Quaternion endRot, float duration) {
            float startTime = Time.time;

            if (spherical) {
                if (local) {
                    while (Time.time <= startTime + duration) {
                        float lerpPercent = Mathf.Clamp01((Time.time - startTime) / duration);
                        transform.localRotation = Quaternion.Slerp(startRot, endRot, lerpPercent);
                        yield return null;
                    }
                }
                else{
                    while (Time.time <= startTime + duration) {
                        float lerpPercent = Mathf.Clamp01((Time.time - startTime) / duration);
                        transform.rotation = Quaternion.Slerp(startRot, endRot, lerpPercent);
                        yield return null;
                    }
                }
            }
            else {
                if (local) {
                    while (Time.time <= startTime + duration) {
                        float lerpPercent = Mathf.Clamp01((Time.time - startTime) / duration);
                        transform.localRotation = Quaternion.Lerp(startRot, endRot, lerpPercent);
                        yield return null;
                    }
                }
                else {
                    while (Time.time <= startTime + duration) {
                        float lerpPercent = Mathf.Clamp01((Time.time - startTime) / duration);
                        transform.rotation = Quaternion.Lerp(startRot, endRot, lerpPercent);
                        yield return null;
                    }
                }
            }
        }
    }
}
