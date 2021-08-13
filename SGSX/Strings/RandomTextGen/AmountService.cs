namespace SGSX.Strings.RandomTextGen
{
    internal class AmountService : object
    {
        public AmountService() : base()
        {
            RandomNumbGen = new System.Random();
        }

        public System.Random RandomNumbGen { get; }

        public ushort GetWordLength()
        {
            ushort result = (ushort) RandomNumbGen.Next(2, 8);
            return result;
        }

        public ushort GetSentenceWordCount()
        {
            ushort result = (ushort) RandomNumbGen.Next(13, 22);
            return result;
        }

        public ushort? GetTextSentenceCount(int textLength)
        {
            if (textLength > 851942)
            {
                textLength = 851942;
            }
            ushort amount = (ushort) (textLength / GetSentenceWordCount());
            if (amount <= 0)
            {
                return null;
            }

            return amount;
        }

    }
}
