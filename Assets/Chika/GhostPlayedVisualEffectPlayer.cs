namespace Chika {
    public sealed class GhostPlayedVisualEffectPlayer : VisualEffectPlayer {
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

        public override void Play() {
            played = true;
            base.Play();
        }

        public override void PlayParticle() {
            if (ghostController) particle.transform.position = ghostController.transform.position;
            base.PlayParticle();
        }
    }
}
