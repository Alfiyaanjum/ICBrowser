using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICBrowser.Business
{
    class UserRequestData
    {
        public List<SheetMapping> SheetDetails { get; set; }
    }

    [Serializable]
    public class SheetMapping
    {
        public string SheetName { get; set; }
        public List<WorkSheetColumnMapping> SchemaMapping { get; set; }
        public string SheetNameToView { get; set; }
    }

    [Serializable]
    public class WorkSheetColumnMapping
    {
        public Int32 ColumnNo { get; set; }
        public string ColumnName { get; set; }
        public string ColumnSubHeaderName { get; set; }
    }
}
