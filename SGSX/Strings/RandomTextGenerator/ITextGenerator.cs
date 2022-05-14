namespace SGSX.Strings.RandomTextGenerator;
public interface ITextGenerator
{
    string GenerateWord();
    string GenerateWord(byte length);

    string GenerateSentence();
    string GenerateSentence(byte length);

    string GenerateText();
    string GenerateText(byte length);

    ITextGenerator GetDefaultGenerator();
}

