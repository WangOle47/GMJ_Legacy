using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Chika {
    public sealed class GhostMovingSoundEffectPlayer : SoundEffectPlayer {
        public AudioClipSet[] sets = Array.Empty<AudioClipSet>();
        public int lastSetIndex = -1;
        public GhostController ghostController;
        public float lastGhostPositionX;

        void Update() {
            //if (!IsGhostMoving()) {
            //    Stop();
            //    return;
            //}

            //lastGhostPositionX = ghostController.transform.position.x;
            //if (!audioSource || !audioSource.isPlaying) Play();
        }

        bool IsGhostMoving() {
            if (!ghostController) {
                ghostController = FindAnyObjectByType<GhostController>();
                if (!ghostController) return false;
                lastGhostPositionX = ghostController.transform.position.x;
            }

            if (Mathf.Approximately(ghostController.transform.position.x, lastGhostPositionX)) return false;
            return true;
        }

        public override AudioClipSet GetClipSet() {
            var index = Random.Range(1, sets.Length);
            lastSetIndex = index != lastSetIndex ? index : 0;
            return sets[lastSetIndex];
        }
    }
}
