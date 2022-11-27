using System.Collections.Generic;
using System.Management.Automation;
using Albacore.ViVe;
using Albacore.ViVe.NativeStructs;
using Albacore.ViVe.NativeEnums;
using PsViveTool.Types;

namespace PsViveTool.Commands
{
    [Cmdlet(VerbsCommon.Set, "ViveFeature")]
    public sealed class SetViveFeatureCommand : Cmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = "SetByFeatureId")]
        public uint[] FeatureId { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = "SetByFeatureName")]
        public string[] FeatureName { get; set; }

        [Parameter(Mandatory = true)]
        public RTL_FEATURE_ENABLED_STATE FeatureState { get; set; }

        protected override void EndProcessing()
        {
        }
    }
}