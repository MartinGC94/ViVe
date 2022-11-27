using Albacore.ViVe.NativeEnums;
using Albacore.ViVe.NativeStructs;

namespace PsViveTool.Types
{
    internal class ViveFeature
    {
        public ViveFeature(RTL_FEATURE_CONFIGURATION featureStruct)
        {
            FeatureName = "";
            FeatureId = featureStruct.FeatureId;
            Priority = featureStruct.Priority;
            State = featureStruct.EnabledState;
            Variant = featureStruct.Variant;
            PayloadKind = featureStruct.VariantPayloadKind;
            Payload = featureStruct.VariantPayload;
        }

        public string FeatureName { get; set; }
        public uint FeatureId { get; set; }
        public RTL_FEATURE_CONFIGURATION_PRIORITY Priority { get; set; }
        public RTL_FEATURE_ENABLED_STATE State { get; set; }
        public uint Variant { get; set; }
        public RTL_FEATURE_VARIANT_PAYLOAD_KIND PayloadKind { get; set; }
        public uint Payload { get; set; }
    }
}