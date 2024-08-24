using System;
using UnityEngine;
using UnityEngine.Audio;

namespace Chika {
    public abstract class SoundEffectPlayer : MonoBehaviour {
        public AudioSource audioSource;
        public AudioMixerGroup audioMixerGroup;

#if UNITY_EDITOR
        void Reset() {
            audioSource = GetComponentInChildren<AudioSource>();
        }
#endif

        void OnDestroy() {
            if (!audioSource) return;
            Destroy(audioSource.gameObject);
        }

        public virtual AudioClipSet GetClipSet() => null;

        protected virtual AudioSource CreateAudioSource() {
            var gameObject = new GameObject("Audio Source") { hideFlags = HideFlags.DontSave };
            gameObject.SetActive(false);
            gameObject.transform.SetParent(transform, false);
            var instance = gameObject.AddComponent<AudioSource>();
            instance.playOnAwake = false;
            instance.outputAudioMixerGroup = audioMixerGroup;
            return instance;
        }

        public virtual void Play() {
            var set = GetClipSet();
            if (set is null) return;
            if (!audioSource) {
                audioSource = CreateAudioSource();
                return;
            }

            audioSource.Stop();
            audioSource.clip = set.clip;
            audioSource.volume = set.volume;
            audioSource.pitch = set.pitch;
            audioSource.gameObject.SetActive(true);
            audioSource.Play();
        }

        public virtual void Stop() {
            if (audioSource) audioSource.Stop();
        }
    }

#if UNITY_EDITOR
    [UnityEditor.CustomEditor(typeof(SoundEffectPlayer), true)]
    public class SoundEffectPlayerObserverEditor : UnityEditor.Editor {
        public override void OnInspectorGUI() {
            base.OnInspectorGUI();
            using var disableScope = new UnityEditor.EditorGUI.DisabledGroupScope(!UnityEditor.EditorApplication.isPlaying);
            if (GUILayout.Button("Play")) ((SoundEffectPlayer)target).Play();
            if (GUILayout.Button("Stop")) ((SoundEffectPlayer)target).Stop();
        }
    }
#endif
}
