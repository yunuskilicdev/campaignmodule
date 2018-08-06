using System;

namespace CampaignModule.Models
{
    public class Campaign
    {
        public Campaign(string name, string productCode, int startTime, int duration, int pmLimit, int targetSalesCount)
        {
            Name = name;
            ProductCode = productCode;
            StartTime = startTime;
            Duration = duration;
            PmLimit = pmLimit;
            TargetSalesCount = targetSalesCount;
            SetActive(true);

            Id = Guid.NewGuid();
        }

        public string Name { get; }
        public string ProductCode { get; }
        public int Duration { get; }
        public int PmLimit { get; }
        public int TargetSalesCount { get; }

        public int StartTime { get; }

        private bool active;

        public bool GetActive()
        {
            return active;
        }

        private void SetActive(bool value)
        {
            active = value;
        }

        public Guid Id { get; }

        public void Deactivate(){
            this.SetActive(false);
        }
    }
}