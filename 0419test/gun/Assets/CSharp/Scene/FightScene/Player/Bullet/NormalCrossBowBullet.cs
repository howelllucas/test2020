﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace EZ
{
    public class NormalCrossBowBullet : BaseBullet
    {
        void Update()
        {
            if (!m_IsInDelayDestroy)
            {

                m_CurTime = m_CurTime + BaseScene.GetDtTime();
                if (m_CurTime < m_LiveTime)
                {
                    transform.Translate(Vector3.right * m_Speed * BaseScene.GetDtTime(), Space.Self);
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }

        public override void Init(double damage, Transform firePoint, float dtAngleZ , float offset,float atkRange = 0)
        {
            transform.SetParent(Global.gApp.gBulletNode.transform, false);
            InitBulletPose(damage, firePoint, dtAngleZ, offset);
            InitBulletEffect(firePoint);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (m_IsInDelayDestroy)
            {
                return;
            }
            GameObject obj = collision.gameObject;

            if (obj.CompareTag(GameConstVal.MapTag))
            {
                Global.gApp.gAudioSource.PlayOneShot(HittedEnemyClip);
                m_IsInDelayDestroy = true;
                gameObject.GetComponent<Collider2D>().enabled = false;
                AddHittedWallEffect();
                Destroy(gameObject);
            }
            else if (obj.CompareTag(GameConstVal.MonsterTag))
            {
                Global.gApp.gAudioSource.PlayOneShot(HittedEnemyClip);
                Monster monster = collision.gameObject.GetComponent<Monster>();
                monster.OnHit_Vec(m_Damage, transform);
                if (monster.CheckCanAddHittedEffect())
                {
                    GameObject effect = GetHittedEnemyEffect();
                    effect.transform.SetParent(monster.transform, false);
                    effect.transform.position = monster.transform.position;
                }
            }
            else if (obj.CompareTag(GameConstVal.ShieldTag))
            {
                Global.gApp.gAudioSource.PlayOneShot(HittedEnemyClip);
                collision.gameObject.GetComponent<AIShieldEvent>().AddHittedEffect(transform.position);
                m_IsInDelayDestroy = true;
                gameObject.GetComponent<Collider2D>().enabled = false;
                Destroy(gameObject);
            }
        }
    }
}
