﻿
using EZ;
using EZ.Data;
using EZ.DataMgr;

public class PurchaseFilter : BaseFilter
{

    public override bool Filter(float[] condition)
    {
        return false;
    }

    public override string GetUnfinishTips(float[] condition)
    {
        string tip = Global.gApp.gGameData.GetTipsInCurLanguage(3093);
        return tip;
    }
    public override string GetTinyUnfinishTips(float[] condition)
    {
        string tip = Global.gApp.gGameData.GetTipsInCurLanguage(3093);
        return tip;
    }
    public override string GetMiddleUnfinishTips(float[] condition)
    {
        string tip = Global.gApp.gGameData.GetTipsInCurLanguage(3093);
        return tip;
    }
    public override string GetLeftTips(float[] condition)
    {
        string tip = Global.gApp.gGameData.GetTipsInCurLanguage(3093);
        return tip;
    }
    public override double GetDefault(float[] condition)
    {
        return Global.gApp.gSystemMgr.GetMiscMgr().FirstPurchase;
    }
}
