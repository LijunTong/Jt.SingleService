using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jt.Cms.Data.Tables.DatabaseEntity
{
    public class DbFieldInfo
    {
        public string FieldName { get; set; }
        public string FieldModelName { get; set; }
        public string FieldModelNameCamel { get; set; }
        public string FieldDbType { get; set; }
        public string FieldModelType { get; set; }
        public int FieldLength { get; set; }
        public int NumberLength { get; set; }

        public int DecimalPoint { get; set; }
        public string IsNotNull { get; set; }
        public int IsIncrement { get; set; }
        public int IsPrimaryKey { get; set; }
        public string FieldDes { get; set; }
        public string DefaultValue { get; set; }

    }

    public class DbInfo
    {
        public string DataBase { get; set; }
    }

    public class DbTableInfo
    {
        public string TableName { get; set; }
    }
}
