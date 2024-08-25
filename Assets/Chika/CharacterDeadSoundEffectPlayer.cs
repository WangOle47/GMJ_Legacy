namespace Chika {
    public sealed class CharacterDeadSoundEffectPlayer : SoundEffectPlayer {
        public AudioClipSet set = new();

        void OnEnable() {
            EventSystem.OncharacterDead += OnCharacterDead;
        }

        void OnDisable() {
            EventSystem.OncharacterDead -= OnCharacterDead;
        }

        public override AudioClipSet GetClipSet() => set;

        void OnCharacterDead(UnityEngine.Vector2 pos) {
            Play();
        }
    }
}
