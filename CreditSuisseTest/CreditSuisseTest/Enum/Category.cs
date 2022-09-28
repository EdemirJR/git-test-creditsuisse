using System.ComponentModel;

namespace CreditSuisseTest.Enum
{
    internal enum Category
    {
        [Description("EXPIRED")]
        EXPIRED = 0,
        [Description("HIGHRISK")]
        HIGHRISK = 1,
        [Description("MEDIUMRISK")]
        MEDIUMRISK = 2
    }
}
