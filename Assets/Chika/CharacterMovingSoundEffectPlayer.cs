using System;
using GMTK.PlatformerToolkit;
using Random = UnityEngine.Random;

namespace Chika {
    public sealed class CharacterMovingSoundEffectPlayer : SoundEffectPlayer {
        public AudioClipSet[] sets = Array.Empty<AudioClipSet>();
        public int lastSetIndex = -1;
        public characterMovement characterMovement;

        void Update() {
            if (!IsPlayerMoving()) {
                Stop();
                return;
            }

            if (!audioSource || !audioSource.isPlaying) Play();
        }

        bool IsPlayerMoving() {
            if (!characterMovement) {
                characterMovement = FindAnyObjectByType<characterMovement>();
                if (!characterMovement) return false;
            }

            if (!characterMovement.onGround) return false;
            if (characterMovement.velocity.x == 0) return false;
            return true;
        }

        public override AudioClipSet GetClipSet() {
            var index = Random.Range(1, sets.Length);
            lastSetIndex = index != lastSetIndex ? index : 0;
            return sets[lastSetIndex];
        }
    }
}
