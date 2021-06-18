﻿
using EZ;
using EZ.Data;
using EZ.DataMgr;

//武器处理逻辑
public class SubWeaponItemStrategy : BaseItemStrategy
{
    private WeaponMgr subWeaponMgr;

    public SubWeaponItemStrategy(WeaponMgr subWeaponMgr)
    {
        this.subWeaponMgr = subWeaponMgr;
    }

    public override double GetItem(int itemId)
    {
        ItemItem itemCfg = Global.gApp.gGameData.ItemData.Get(itemId);
        if (itemCfg != null && subWeaponMgr.GetWeaponOpenState(itemCfg))
        {
            return 1f;
        }
        else
        {
            return 0f;
        }
    }
    public override bool AddItem(ItemDTO itemDTO)
    {
        return true;
    }
    public override bool ReduceItem(ItemDTO itemDTO)
    {
        return false;
    }
}
