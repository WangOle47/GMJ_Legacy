using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Chika {
    public sealed class CharacterDeadVisualEffectPlayer : VisualEffectPlayer {
        public Volume volume;
        public float vignetteDuration = 0.2f;
        public AnimationCurve vignetteIntensity = new(new Keyframe(0f, 0f), new Keyframe(0.5f, 1f), new Keyframe(1f, 0f));
        public float chromaticAberrationDuration = 0.2f;
        public AnimationCurve chromaticAberrationIntensity = new(new Keyframe(0f, 0f), new Keyframe(0.5f, 1f), new Keyframe(1f, 0f));

        void OnEnable() {
            EventSystem.OncharacterDead += OnCharacterDead;
        }

        void OnDisable() {
            EventSystem.OncharacterDead -= OnCharacterDead;
        }

        public override Sequence CreateSequence() {
            var sequence = base.CreateSequence();
            if (DOTween.IsTweening(Sequence)) Sequence.Kill();
            if (!volume) volume = FindAnyObjectByType<Volume>();
            if (volume.profile.TryGet(out Vignette vignette))
                sequence.Join(DOTween.To(() => 0f, x => vignette.intensity.value = vignetteIntensity.Evaluate(x), 1f, vignetteDuration));
            if (volume.profile.TryGet(out ChromaticAberration chromaticAberration))
                sequence.Join(DOTween.To(() => 0f, x => chromaticAberration.intensity.value = chromaticAberrationIntensity.Evaluate(x), 1f, chromaticAberrationDuration));
            sequence.AppendCallback(() => {
                if (vignette && volume.sharedProfile.TryGet(out Vignette sharedVignette))
                    vignette.intensity.value = sharedVignette.intensity.value;
                if (chromaticAberration && volume.sharedProfile.TryGet(out ChromaticAberration sharedChromaticAberration))
                    chromaticAberration.intensity.value = sharedChromaticAberration.intensity.value;
            });
            return sequence;
        }

        void OnCharacterDead() {
            Play();
        }
    }
}
