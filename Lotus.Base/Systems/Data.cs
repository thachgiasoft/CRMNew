using Lotus.Libraries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

namespace Lotus.Base.Systems
{
    public class Data
    {
        public static bool IsNewRow(object data)
        {
            DataRow r = null;
            if (data is DataRowView)
                r = (data as DataRowView).Row;
            else if (data is DataRow)
                r = (data as DataRow);
            else
                return false;

            return (r.RowState == DataRowState.Detached || r.RowState == DataRowState.Added);
        }
        public static string GetDescription(Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());
            var attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                    typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
        }

    }
}
