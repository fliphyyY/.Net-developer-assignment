namespace Metrans.OrderContext
{
    internal interface IOrderContext
    {
        void ValidateXml();
       Task  DeserializeAndSaveToDb();

    }
}
