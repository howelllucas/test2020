﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Game.Tool
{
    public class AlphasTween : TweenBase
    {
        [FormerlySerializedAs("m_targets")]
        public Graphic[] targets;
        [FormerlySerializedAs("m_from")]
        public float from;
        [FormerlySerializedAs("m_to")]
        public float to;

        protected override void Awake()
        {
            base.Awake();
            if (targets == null || targets.Length == 0)
                targets = GetComponentsInChildren<Graphic>();
        }

        protected override void DoTween(float t)
        {
            if (targets == null || targets.Length <= 0)
                return;

            float alpha = Mathf.LerpUnclamped(from, to, t);
            for (int i = 0; i < targets.Length; i++)
            {
                var color = targets[i].color;
                color.a = alpha;
                targets[i].color = color;
            }

        }

    }
}