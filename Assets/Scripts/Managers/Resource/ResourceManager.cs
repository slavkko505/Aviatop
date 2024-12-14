
namespace Managers.Resource
{
    public class ResourceManager
    {
        private int _amount;

        public int Amount
        {
            get => _amount;
            set { _amount = value; }
        }

        public ResourceManager(int initialAmount)
        {
            _amount = initialAmount;
        }

        public void AddAmount(int amount)
        {
            _amount += amount;
        }
        
        public void RemoveRes(int amount)
        {
            _amount -= amount;
        }
    }
}