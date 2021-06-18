﻿using EZ.Data;
using UnityEngine;
namespace EZ
{
    public class DeadthSkill1Act : PetBaseAct
    {

        [SerializeField] protected AudioClip AtkClip;
        [SerializeField] protected int AtkTimes = 1;
        [SerializeField] protected double AtkParam = 1;
        [SerializeField]private float BreakDis = 20;
        [SerializeField]private DeadthNormalBullet DeadthBullet1;

        private PetLockDisTools m_LockTools;
        private float m_AnimTime = 2.0f;
        private float m_DtTime;

        private bool m_ForceEndSkill = false;

        private bool m_EndSkill = false;
        public override void Init(BasePet pet,PetAtkState controller)
        {
            base.Init(pet, controller);
            m_AtkTimes = AtkTimes;
            ItemItem weaponItem = Global.gApp.gGameData.GetItemDataByName(GameConstVal.WDeadthWalker);
            GunsPass_dataItem weaponLevelData = Global.gApp.CurScene.GetGunPassDataItem();
            double atk = weaponLevelData.DeathWalker[(int)MWeapon.Atk];


            int curLv = Global.gApp.gSystemMgr.GetWeaponMgr().GetWeaponLevel(GameConstVal.WDeadthWalker);
            GunsSub_dataItem levelItem = Global.gApp.gGameData.GunSubDataConfig.Get(curLv);
            double[] weaponParams = ReflectionUtil.GetValueByProperty<GunsSub_dataItem, double[]>("base_params_" + weaponItem.qualevel, levelItem);

            float campAtkInc = Global.gApp.CurScene.GetMainPlayerComp().GetBuffMgr().CampPetIncAtk;

            m_Damage = atk * AtkParam * weaponParams[0] * (1 + campAtkInc);

            m_DtTime = weaponItem.dtime + m_AnimTime;
            m_LockTools = new PetLockDisTools(transform,pet);
            m_LockTools.MaxRadio = 1;
            m_LockTools.MinRadio = 1;
            m_LockTools.BreakDis = BreakDis;
            m_LockTools.SetBreakCall(BreakCall);
        }
        private void BreakCall()
        {
            if (m_LockMonster != null && m_LockMonster.InDeath && !m_EndSkill)
            { 
                m_ForceEndSkill = true;
            }
        }
        public override void SetLockMonster(Transform monsterTsf, Monster monster, float monsterRadio)
        {
            float radio = monsterRadio + m_Pet.CircleRadio;
            base.SetLockMonster(monsterTsf, monster, monsterRadio);
            m_LockTools.MaxRadio = radio + MaxOffset;
            m_LockTools.MinRadio = radio + MinOffset;
            m_LockTools.SetFollowState(false);
            m_LockTools.ResetCurRadio();
            m_LockTools.SetFollowSpeed(monster.GetMonsterItem().baseSpeed * 1.2f);
        }
        public override void EndEffect()
        {

        }
        public override void EndSkill()
        {
            DeadthBullet1.End();
        } 

        public override void StartSkill()
        {
            m_EndSkill = false;
            m_InBreakState = false;
            m_ForceEndSkill = false;
            m_CurTime = m_DtTime - 0.1f;
            m_LockTools.SetLockTsf(m_LockMonsterTsf);
        }
        public override bool CanTriggerSkill()
        {
            return m_AtkTimes > 0;
        }
        private void InstalceBullet()
        {
            DeadthBullet1.Run(m_Damage);
        }
        public override void MUpdate()
        {
            float dtTime = BaseScene.GetDtTime();
            m_CurTime += dtTime;
            if(dtTime > 0 && !m_InBreakState)
            {
                if (!m_EndSkill)
                {
                    m_LockTools.Update();
                }
                if (!m_InBreakState)
                {
                    if (m_LockMonster != null && m_LockMonster.InDeath)
                    {
                        m_EndSkill = true;
                    }
                    if (m_LockMonster != null && !m_LockMonster.InDeath && !m_EndSkill)
                    { 
                        if (m_AtkTimes > 0 && m_CurTime > m_DtTime)
                        {
                            m_Pet.PlayAnimAbs(GameConstVal.Skill01);
                            Global.gApp.gAudioSource.PlayOneShot(AtkClip);
                            m_CurTime = m_CurTime - m_DtTime;
                            if (m_ForceEndSkill)
                            {
                                m_AtkTimes = 0;
                                m_ForceEndSkill = false;
                            }
                            else
                            {
                                m_AtkTimes--;
                            }
                            InstalceBullet();
                        }
                        else if (m_AtkTimes == 0 && m_CurTime > m_AnimTime)
                        {
                            m_AtkTimes = AtkTimes;
                            m_Pet.PlayAnim(GameConstVal.Run);
                            m_Controller.EndFirstSkill();
                            m_Controller.TriggerSecondSkill();
                        }
                    }
                    else if (m_CurTime > m_AnimTime) // 必须等待动作执行完毕
                    {
                        if (m_AtkTimes == 0)
                        {
                            m_AtkTimes = AtkTimes;
                            m_Controller.EndFirstSkill();
                        }
                        else
                        {
                            m_Controller.EndSkill();
                        }
                        m_Pet.PlayAnim(GameConstVal.Idle);
                    }
                }
                else
                {
                    m_Pet.SetSpeed(Vector2.zero);
                }
            }
            else
            {
                m_Pet.SetSpeed(Vector2.zero);
            }
        }
    }
}
