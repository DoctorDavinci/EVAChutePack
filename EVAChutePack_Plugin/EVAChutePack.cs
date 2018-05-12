using UnityEngine;

namespace EVAChutePack
{
    [KSPAddon(KSPAddon.Startup.Flight, false)]
    public class EVAChutePack : MonoBehaviour
    {
        public void Update()
        {
            if (HighLogic.LoadedSceneIsFlight)
            {
                if (FlightGlobals.ActiveVessel.isEVA)
                {
                    CheckChute();
                }
            }
        }

        private void CheckChute()
        {
            foreach (Part p in FlightGlobals.ActiveVessel.Parts)
            {
                var EVAchute = p.vessel.FindPartModuleImplementing<ModuleEvaChute>();
                if (EVAchute != null)
                {
                    if (p.vessel.Landed || p.vessel.Splashed)
                    {
                        EVAchute.Repack();
                    }
                }
            }
        }

        private void Dummy()
        {
        }
    }
}
