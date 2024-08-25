using UnityEngine;

namespace Chika {
    public sealed class FlagGeneratedSoundEffectPlayer : SoundEffectPlayer {
        public AudioClipSet set = new();

        void OnEnable() {
            EventSystem.OnFlagGenerated += OnFlagGenerated;
        }

        void OnDisable() {
            EventSystem.OnFlagGenerated -= OnFlagGenerated;
        }

        public override AudioClipSet GetClipSet() => set;

        void OnFlagGenerated(Vector2 _) {
            Play();
        }
    }
}
