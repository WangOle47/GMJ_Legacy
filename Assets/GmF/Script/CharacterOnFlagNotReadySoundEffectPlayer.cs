using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GmF
{
    public class CharacterOnFlagNotReadySoundEffectPlayer : Chika.SoundEffectPlayer
    {
        public Chika.AudioClipSet set = new();
        public GhostController ghostController;
        public bool played;

        void Awake()
        {
            played = true;
        }

        public override Chika.AudioClipSet GetClipSet() => set;

        public override void Play()
        {
            played = true;
            base.Play();
        }
    }
}
