using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;

    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoTypes ammoType;
        public int ammoAmount;
    }
    public int GetCurrentAmmo(AmmoTypes ammoType) //get only falue so the player cant modify it exterinaly
    {
        return GetAmmoSlot(ammoType).ammoAmount;
    }
    public void IncreaseCurrentAmmo(AmmoTypes ammoType, int ammoAmount)
    {
        GetAmmoSlot(ammoType).ammoAmount += ammoAmount;
    }

    public void ReduceCurrentAmmo(AmmoTypes ammoType, int AmmoToReload)
    {
        GetAmmoSlot(ammoType).ammoAmount--;
    }

    AmmoSlot GetAmmoSlot(AmmoTypes ammoType)
    {
        foreach(AmmoSlot slot in ammoSlots)
        {
            if(slot.ammoType == ammoType)
            {
                return slot;
            }
        }

        return null;
    }
}
