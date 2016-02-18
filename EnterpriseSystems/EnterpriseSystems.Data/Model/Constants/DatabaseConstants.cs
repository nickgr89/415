namespace EnterpriseSystems.Data.Model.Constants
{
    public class CustomerRequestColumnNames
    {
        public const string Identity = "CUS_REQ_I";
        public const string Status = "PRS_STT";
        public const string BusinessEntityName = "BUS_UNT_ETY_NM";
        public const string TypeCode = "REQ_TYP_C";
        public const string ConsumerClassificationType = "CNSM_CLS";
        public const string CreatedDate = "CRT_S";
        public const string CreatedUserId = "CRT_UID";
        public const string CreatedProgramCode = "CRT_PGM_C";
        public const string LastUpdatedDate = "LST_UPD_S";
        public const string LastUpdatedUserId = "LST_UPD_UID";
        public const string LastUpdatedProgramCode = "LST_UPD_PGM_C";
    }

    public class CustomerRequestQueryParameters
    {
        public const string BusinessName = "@BUS_UNT_KEY_CH";
        public const string Identity = "@CUS_REQ_I";
    }

    public class DatabaseConnectionStrings
    {
        public const string Default = "NULL";
    }
}
