

namespace PyConsumerApp.DataService
{
    public interface IHashService
    {
        string GenerateHashkey();
        void StartSMSRetriverReceiver();
    }
}
