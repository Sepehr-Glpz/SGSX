using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGSX.Strings.RandomTextGenerator;
internal sealed class TextGenerator : ITextGenerator
{
    private readonly object _syncRoot;
    private readonly StringBuilder _innerBuilder;
    private readonly Random _random;
    internal TextGenerator()
    {
        _random = new Random();
        _innerBuilder = new StringBuilder();
        _syncRoot = new object();
    }

    private const byte AVG_WORD_LENGTH = 5;

    private byte GetSentenceAverageWordLength()
    {
        return (byte)_random.Next(15, 21);
    }
    private string AppendToStringBuilder(Func<StringBuilder,StringBuilder> builder)
    {
        lock (_syncRoot)
        {
            try
            {
                return builder(_innerBuilder).ToString();
            }
            finally
            {
                _innerBuilder.Clear();
            }
        }
    }

    public string GenerateSentence()
    {
        
    }

    public string GenerateSentence(byte length)
    {
        
    }

    public string GenerateText()
    {
        
    }

    public string GenerateText(byte length)
    {
        
    }

    public string GenerateWord()
    {
        
    }

    public string GenerateWord(byte length)
    {
        
    }

    public ITextGenerator GetDefaultGenerator()
    {
        
    }

    private bool RandomBool()
    {
        return _random.NextSingle() < 0.5F;
    }

}

