﻿
using EZ.Data;
using EZ.DataMgr;
using UnityEngine;

namespace EZ.Weapon
{
    public class HgrenadeGun : SecondGun
    {
        public override void Init(FightWeaponMgr mgr)
        {
            InitDamage();
            base.Init(mgr);
        }

        protected override void InitDamage()
        {
            ItemItem weaponItem = Global.gApp.gGameData.GetItemDataByName(GameConstVal.WWeaponHgrenade);
            m_DtTime = weaponItem.dtime;

            GunsPass_dataItem weaponLevelData = Global.gApp.CurScene.GetGunPassDataItem();
            double atk = weaponLevelData.weapon_hgrenade[(int)MWeapon.Atk];

            int curLv = Global.gApp.gSystemMgr.GetWeaponMgr().GetWeaponLevel(GameConstVal.WWeaponHgrenade);
            GunsSub_dataItem levelItem = Global.gApp.gGameData.GunSubDataConfig.Get(curLv);
            double[] weaponParams = ReflectionUtil.GetValueByProperty<GunsSub_dataItem, double[]>("base_params_" + weaponItem.qualevel, levelItem);
            m_Damage = atk * weaponParams[0] * GetCampDamageInc();

            m_WeaponItem = weaponItem;
        }
    }
}

