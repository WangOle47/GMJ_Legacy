using Cinemachine;
using DG.Tweening;
using UnityEngine;

namespace Chika {
    public abstract class VisualEffectPlayer : MonoBehaviour {
        public ParticleSystem particle;
        public CinemachineImpulseSource cinemachineImpulseSource;
        public Sequence Sequence;

        public bool IsSequencePlaying() => Sequence is not null && Sequence.IsPlaying();

        public virtual Sequence CreateSequence() => DOTween.Sequence();

        public virtual void Play() {
            PlayParticle();
            PlayCinemachineImpulse();
            PlaySequence();
        }

        public virtual void Stop() {
            StopParticle();
            StopCinemachineImpulse();
            StopSequence();
        }

        public virtual void PlayParticle() {
            if (!particle) return;
            particle.gameObject.SetActive(true);
            particle.Play();
        }

        public virtual void StopParticle() {
            if (!particle) return;
            particle.Stop();
            particle.gameObject.SetActive(false);
        }

        public virtual void PlayCinemachineImpulse() {
            if (cinemachineImpulseSource) cinemachineImpulseSource.GenerateImpulse();
        }

        public virtual void StopCinemachineImpulse() { }

        public virtual void PlaySequence() {
            if (IsSequencePlaying()) Sequence.Kill();
            Sequence = CreateSequence();
            Sequence.Play();
        }

        public virtual void StopSequence() {
            Sequence?.Kill(true);
            Sequence = null;
        }
    }

#if UNITY_EDITOR
    [UnityEditor.CustomEditor(typeof(VisualEffectPlayer), true)]
    [UnityEditor.CanEditMultipleObjects]
    public class VisualEffectPlayerEditor : UnityEditor.Editor {
        public override void OnInspectorGUI() {
            base.OnInspectorGUI();
            using var disableScope = new UnityEditor.EditorGUI.DisabledGroupScope(!UnityEditor.EditorApplication.isPlaying);
            using var horizontalScope = new UnityEditor.EditorGUILayout.HorizontalScope();
            if (GUILayout.Button("Play"))
                foreach (var t in targets)
                    ((VisualEffectPlayer)t).Play();
            if (GUILayout.Button("Stop"))
                foreach (var t in targets)
                    ((VisualEffectPlayer)t).Stop();
        }
    }
#endif
}
