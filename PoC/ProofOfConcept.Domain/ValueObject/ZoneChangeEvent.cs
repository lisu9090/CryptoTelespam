using ProofOfConcept.Domain.Enum;

namespace ProofOfConcept.Domain.ValueObject
{
    public class ZoneChangeEvent<T>
    {
        public MessageTemplateId MessageTemplateId { get; }

        public ZoneId CurrentZoneId { get; }

        public ZoneId PreviousZoneId { get; }

        public IndicatorId IndicatorId { get; }

        public AssetId AssetId { get; }

        public T Value { get; set; }

        public ZoneChangeEvent(
            MessageTemplateId messageTemplateId,
            ZoneId currentZoneId,
            ZoneId previousZoneId,
            IndicatorId indicatorId,
            AssetId assetId)
        {
            MessageTemplateId = messageTemplateId;
            CurrentZoneId = currentZoneId;
            PreviousZoneId = previousZoneId;
            IndicatorId = indicatorId;
            AssetId = assetId;
        }
    }
}