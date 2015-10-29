/**
 * Hell-O-Week 2015
 * kerbalspaceproram.de
 */

using System;
using System.IO;
using UnityEngine;

namespace KCST
{
    /// Einige Überraschungen für die Hell-O-Week 2015
    [KSPAddon(KSPAddon.Startup.MainMenu, false)]
    public class KerbalCenterForScreamsAndTorture : MonoBehaviour
    {
        void Start()
        {
            /// Main-Menu: Den Mond rot machen
            CelestialBody mun = PSystemManager.Instance.localBodies.Find(b => b.name == "Mun");
            if (mun != null)
            {
                PQSMod_VertexBloodColor red = new GameObject("VertexBloodColor").AddComponent<PQSMod_VertexBloodColor>();
                red.transform.parent = mun.pqsController.transform;
                red.order = Int32.MaxValue;
                red.modEnabled = true;
                mun.scaledBody.renderer.material.mainTexture = GameDatabase.Instance.GetTexture("Hell-o-Week 2015/Textures/mun_color", false);
            }
        }
    }

    /// Blutmond-PQSMod
    public class PQSMod_VertexBloodColor : PQSMod
    {
        /// Amount of red color
        public Color32 red = new Color32(138, 7, 7, 255);

        public override void OnVertexBuild(PQS.VertexBuildData data)
        {
            data.vertColor *= red;
        }
    }
}
