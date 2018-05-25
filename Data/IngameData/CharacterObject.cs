using System.Collections;
using System.Collections.Generic;

public class CharacterObject
{
    public StatusSheet DefaultStat { get { return m_DefaultStatusSheet; } }
    public StatusSheet ResultStat { get { return m_ResultStatusSheet; } }

    public LinkedList<BaseEnchant> Enchanted { get { return m_TotalEnchanted; } }

    public List<BaseEnchant> Buff { get { return m_ListBuff; } }
    public List<BaseEnchant> DeBuff { get { return m_ListDebuff; } }

    StatusSheet m_DefaultStatusSheet = null;
    StatusSheet m_ResultStatusSheet = null;

    LinkedList<BaseEnchant> m_TotalEnchanted = null;

    List<BaseEnchant> m_ListBuff = null;
    List<BaseEnchant> m_ListDebuff = null;

    //List<CalculationDelegators>

    public virtual void PostTurnProcess()
    {
        RefreshStatusSheet(true);
    }

    public virtual void RefreshStatusSheet(bool isChangeDuration)
    {
        if (ResultStat == null)
            m_ResultStatusSheet = new StatusSheet(); // must be existed

        // refresh origin sheet
        ResultStat.CopySrc(DefaultStat);

        // recalculate enchant affected status
        if (Buff != null)
            Buff.Clear();
        if (DeBuff != null)
            DeBuff.Clear();

        if (Enchanted != null)
        {
            var iterElem = Enchanted.First;
            while (iterElem != null)
            {
                BaseEnchant eachEnchant = iterElem.Value;

                var nextElem = iterElem.Next;

                if (eachEnchant == null) // data null
                {
                    Enchanted.Remove(iterElem);
                }
                else
                {
                    if(isChangeDuration == true)
                    {
                        eachEnchant.ChangeDuration(); // decrease duration
                    }

                    if (eachEnchant.IsExpired == true) // enchant duration expired
                    {
                        Enchanted.Remove(iterElem);
                    }
                    else
                    {
                        eachEnchant.GetAffected(ResultStat); // affect enchant
                        switch(eachEnchant.Type)
                        {
                            case EnchantType.Buff:
                                Buff.Add(eachEnchant);
                                break;
                            case EnchantType.Debuff:
                                DeBuff.Add(eachEnchant);
                                break;
                        }
                    }
                }

                iterElem = nextElem;
                continue;
            }

        }

        ResultStat.StatusSettlement();
    }
}
