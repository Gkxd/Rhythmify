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
        public int[] indices;
        public int offset;
        public bool local;
        public bool rigid;
        public bool spherical;
        
        private Rigidbody rigidBody;

        override protected void init() {
            if (rigid) {
                rigidBody = gameObject.GetComponent<Rigidbody>();
                if (rigidBody == null) {
                    Debug.LogError("The GameObject " + gameObject + " has no RigidBody component attached!");
                    Debug.Break();
                }
            }
        }

        override protected void rhythmUpdate(int beat) {
            int size = eulerAngles.Length;
        
            if (size <= 1) {
                return;
            }
        
            int idx = beat + offset;

            Quaternion startRot;
            Quaternion endRot;

            if (indices.Length > 0) {
                int idxA = indices[idx % indices.Length];
                int idxB = indices[(idx + 1) % indices.Length];
                startRot = Quaternion.Euler(eulerAngles [idxA % size]);
                endRot = Quaternion.Euler(eulerAngles [idxB % size]);
            }
            else {
                startRot = Quaternion.Euler(eulerAngles [idx % size]);
                endRot = Quaternion.Euler(eulerAngles [(idx + 1) % size]);
            }

            StartCoroutine(rotate(startRot, endRot, secondsPerBeat));
        }
    
        private IEnumerator rotate(Quaternion startRot, Quaternion endRot, float duration) {
            float startTime = Time.time;

            if (spherical) {
                if (rigid && rigidBody != null) {
                    while (Time.time <= startTime + duration) {
                        float lerpPercent = Mathf.Clamp01((Time.time - startTime) / duration);
                        rigidBody.MoveRotation(Quaternion.Slerp(startRot, endRot, lerpPercent));
                        yield return null;
                    }
                }
                else if (local) {
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
                if (rigid && rigidBody != null) {
                    while (Time.time <= startTime + duration) {
                        float lerpPercent = Mathf.Clamp01((Time.time - startTime) / duration);
                        rigidBody.MoveRotation(Quaternion.Lerp(startRot, endRot, lerpPercent));
                        yield return null;
                    }
                }
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
