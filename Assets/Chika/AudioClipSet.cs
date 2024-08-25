using System;
using UnityEngine;

namespace Chika {
    [Serializable]
    public sealed class AudioClipSet {
        public AudioClip clip;

        [Range(0f, 1f)]
        public float volume = 1f;

        [Range(-3f, 3f)]
        public float pitch = 1f;

        public bool loop;
    }
}
