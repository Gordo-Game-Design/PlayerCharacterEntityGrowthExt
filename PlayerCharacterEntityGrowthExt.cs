using UnityEngine;

//need to set the toggle and rate on player character male or female

namespace MultiplayerARPG
{
    public partial class PlayerCharacterEntity
    {
        [Category("Character Settings")]
        [Header("Growth System - GG")]
        [SerializeField]
        protected bool enableGrowthSystem = true;
        [SerializeField]
        public float growthRate = 1f;

        [DevExtMethods("Awake")]
        protected void GrowDevExtAwake()
        {
            if (enableGrowthSystem)
            {
                //Debug.LogError("GrowDevExtAwake ");
                onLevelChange += AHCharGrow;
            }            
        }

        protected void AHCharGrow(short Level)
        {
            float G = (Level * growthRate) + 1;
            transform.localScale = new Vector3(G, G, G);
            //Debug.LogError("AHCharGrow " + name + " " + Level + " growth rate " + growthRate + "new scale " + G + " ");
        }

        [DevExtMethods("OnDestroy")]
        protected void OnDestroyGrowExt()
        {
            if (enableGrowthSystem)
            {
                //Debug.LogError("OnDestroyGrowExt ");
                onLevelChange -= AHCharGrow;
            }            
        }
    }
}
