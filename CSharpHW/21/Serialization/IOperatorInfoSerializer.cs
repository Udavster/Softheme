
namespace Serialization
{
    interface IOperatorInfoSerializer
    {
        void Serialize(MobileOperatorWithMemo mobileOperator, string path,
            bool withCallsJournal = true, bool withSmsJournal = true);
        MobileOperatorWithMemo Deserialize(string path);
    }
}
