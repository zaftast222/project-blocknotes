using System.Collections;
using System.Collections.Generic;

public enum EnchantType
{
    Buff,
    Debuff,

    ETC,
}

public class BaseEnchant
{
    public int InitialDuration;
    public int RemainedDuration;

    public string IconCode;

    public EnchantType Type;

    public void GetAffected(StatusSheet affectTarget)
    {
    }

    public virtual void ChangeDuration() { }

    public virtual bool IsExpired { get { return true; } }
}
