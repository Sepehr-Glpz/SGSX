namespace SGSX.Persistense.Tools
{
    public class Options : object
    {
        public Options() : base()
        {

        }

        public string ConnectionString { get; set; }

        public Enums.Provider Provider { get; set; }
    }
}
