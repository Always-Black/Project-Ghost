namespace Interfaces
{
    public interface IHealingSource
    {
        public float CalculateHealthAmount();
        public float Health { get; set; }
        public float TransferTime { get; set; }
    }
}