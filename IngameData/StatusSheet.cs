using System.Collections;
using System.Collections.Generic;

public class StatusSheet
{
    StatusSheet originSheet;

    public long CurHP;
    public long MaxHP;

    public int buff_MaxHP_Increase; // 0 ~ 
    public int debuff_MaxHP_Decrease; // 0 ~ 10000

    public void InitFactors()
    {
        buff_MaxHP_Increase = 0;
        debuff_MaxHP_Decrease = 0;
    }

    public void CopySrc(StatusSheet srcSheet, bool isInitialCopy = false)   // default sheet, copy consumable status (ex:HP)
    {
        originSheet = srcSheet;
        InitFactors();

        if (originSheet == null)
            return;

        if(isInitialCopy == true)
        {
            CurHP = srcSheet.CurHP;
        }
    }

    public void StatusSettlement()  // final clarify status after enchant affected
    {
        if (originSheet == null)
            return;

        int MaxHP_affectFactor = buff_MaxHP_Increase - debuff_MaxHP_Decrease;
        MaxHP = originSheet.MaxHP * (GlobalConstant.DecimalMagnification + MaxHP_affectFactor) / GlobalConstant.DecimalMagnification;

        if (CurHP > MaxHP)
            CurHP = MaxHP;
    }
}
