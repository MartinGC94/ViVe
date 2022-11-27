using System.Collections.Generic;
using System.Management.Automation;
using Albacore.ViVe;
using Albacore.ViVe.NativeStructs;
using Albacore.ViVe.NativeEnums;
using PsViveTool.Types;

namespace PsViveTool.Commands
{
    [Cmdlet(VerbsCommon.Get, "ViveFeature")]
    [OutputType(typeof(ViveFeature))]
    public sealed class GetViveFeatureCommand : Cmdlet
    {
        [Parameter()]
        public uint[] FeatureId { get; set; }

        [Parameter()]
        public RTL_FEATURE_CONFIGURATION_TYPE ConfigType { get; set; } = RTL_FEATURE_CONFIGURATION_TYPE.Runtime;

        protected override void EndProcessing()
        {
            IList<RTL_FEATURE_CONFIGURATION> featuresToOutput;
            if (FeatureId is null || FeatureId.Length == 0)
            {
                featuresToOutput = FeatureManager.QueryAllFeatureConfigurations(ConfigType);
            }
            else
            {
                featuresToOutput = new List<RTL_FEATURE_CONFIGURATION>(FeatureId.Length);
                foreach (var id in FeatureId)
                {
                    var foundFeature = FeatureManager.QueryFeatureConfiguration(id, ConfigType);
                    if (foundFeature != null)
                    {
                        featuresToOutput.Add((RTL_FEATURE_CONFIGURATION)foundFeature);
                    }
                }
            }

            foreach (var feature in featuresToOutput)
            {
                WriteObject(new ViveFeature(feature));
            }
        }
    }
}