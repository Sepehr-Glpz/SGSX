namespace SGSX.Strings.RandomTextGen
{
    public sealed class TextGenerator : object
    {
        public TextGenerator() : base()
        {
            AmountService = new AmountService();
        }

        private AmountService AmountService { get; }

        #region GenerateWord
        public string GenerateWord(ushort length)
        {
            if (length > ushort.MaxValue || length < 1)
            {
                throw new System.ArgumentOutOfRangeException(nameof(length));
            }

            var stringBuilder = new System.Text.StringBuilder();
            char previousChar = '\0';
            string newString;
            while (stringBuilder.Length < length)
            {
                newString = Characters.GetLetter(previousChar);
                stringBuilder.Append(newString);
                if (newString.Length > 1)
                {
                    newString = newString.Remove(0, 1);
                }
                previousChar = System.Convert.ToChar(newString);
            }
            string result = stringBuilder.ToString();
            return result;
        }
        public string GenerateWord()
        {
            var result = GenerateWord(AmountService.GetWordLength());
            return result;
        }
        #endregion /GenerateWord

        #region GenerateSentence
        public string GenerateSentence()
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            ushort sentenceWordCount = AmountService.GetSentenceWordCount();
            for (ushort wordIndex = 0; wordIndex < sentenceWordCount; wordIndex++)
            {
                stringBuilder.Append(this.GenerateWord());
                stringBuilder.Append(Characters.SpaceChar);
            }
            stringBuilder.Remove(stringBuilder.Length - 1,1);
            stringBuilder.Append(Characters.GetEndingChar());
            string result = stringBuilder.ToString();
            return result;
        }

        private string GenerateSentenceInternal()
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            ushort sentenceWordCount = AmountService.GetSentenceWordCount();
            for (ushort wordIndex = 0; wordIndex < sentenceWordCount; wordIndex++)
            {
                stringBuilder.Append(this.GenerateWord());
                stringBuilder.Append(Characters.SpaceChar);
            }
            stringBuilder.Remove(stringBuilder.Length - 1, 1);
            stringBuilder.Append(Characters.SpecialCharChance());
            string result = stringBuilder.ToString();
            return result;
        }

        #endregion /GenerateSentence

        #region GenerateText
        public string GenerateText(int maxLength)
        {
            if (maxLength > int.MaxValue || maxLength < 1)
            {
                throw new System.ArgumentOutOfRangeException(nameof(maxLength));
            }

            ushort? amount = AmountService.GetTextSentenceCount(maxLength);
            if (amount is null)
            {
                return string.Empty;
            }

            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();

            for (int index = 0; index < amount; index++)
            {
                stringBuilder.Append(GenerateSentenceInternal());
                stringBuilder.Append(' ');
            }
            if (stringBuilder.Length >= maxLength)
            {
                var unwantedLength = stringBuilder.Length - maxLength;
                var startIndex = stringBuilder.Length - unwantedLength - 1;
                stringBuilder.Remove(startIndex, unwantedLength);
            }
            stringBuilder.Remove(stringBuilder.Length - 1, 1);
            stringBuilder.Append(Characters.GetEndingChar());
            string result = stringBuilder.ToString();
            return result.Fix();
        }
        #endregion /GenerateText
    }
}
