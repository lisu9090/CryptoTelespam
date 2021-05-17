namespace ProofOfConcept.Domain.ValueObject
{
    public class ZoneChangeEvent<T>
    {
        public int MessageTemplateId { get; }

        public int CurrentZoneId { get; }

        public int PreviousZoneId { get; }

        public int IndicatorId { get; }

        public int AssetId { get; }

        public T Value { get; set; }

        public ZoneChangeEvent(int messageTemplateId, int currentZoneId, int previousZoneId, int indicatorId, int assetId)
        {
            MessageTemplateId = messageTemplateId;
            CurrentZoneId = currentZoneId;
            PreviousZoneId = previousZoneId;
            IndicatorId = indicatorId;
            AssetId = assetId;
        }
    }
}