using UnityEngine;

namespace EVAChutePack
{
    [KSPAddon(KSPAddon.Startup.Flight, false)]
    public class EVAChutePack : MonoBehaviour
    {
        private bool triggered = false;

        public void Update()
        {
            if (HighLogic.LoadedSceneIsFlight)
            {
                if (FlightGlobals.ActiveVessel.isEVA)
                {
                    if (!FlightGlobals.ActiveVessel.LandedOrSplashed)
                    {
                        triggered = true;
                    }

                    if (triggered && FlightGlobals.ActiveVessel.LandedOrSplashed)
                    {
                        CheckChute();
                    }
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

                triggered = false;
            }
        }

        private void Dummy()
        {
        }
    }
}
