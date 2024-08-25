namespace Chika {
    public sealed class GhostPlayedSoundEffectPlayer : SoundEffectPlayer {
        public AudioClipSet set = new();
        public GhostController ghostController;
        public bool played;

        void Awake() {
            played = true;
        }

        void Update() {
            if (!ghostController) {
                played = false;
                ghostController = FindAnyObjectByType<GhostController>();
            }

            if (!ghostController) return;
            if (!played) Play();
        }

        public override AudioClipSet GetClipSet() => set;

        public override void Play() {
            played = true;
            base.Play();
        }
    }
}
