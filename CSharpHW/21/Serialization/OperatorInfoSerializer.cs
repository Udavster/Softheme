
namespace Serialization
{
    interface OperatorInfoSerializer
    {
        void Serialize(MobileOperatorWithMemo mobileOperator, string path);
        void Deserialize(string path);
    }
}
