using DG.Tweening;
using UnityEngine;

namespace Chika {
    public abstract class VisualEffectPlayer : MonoBehaviour {
        public Sequence Sequence;

        public bool IsPlaying() => Sequence is not null && Sequence.IsPlaying();

        public virtual Sequence CreateSequence() => DOTween.Sequence();

        public virtual void Play() {
            if (IsPlaying()) Sequence.Kill();
            Sequence = CreateSequence();
            Sequence.Play();
        }

        public virtual void Stop() {
            Sequence?.Kill(true);
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
