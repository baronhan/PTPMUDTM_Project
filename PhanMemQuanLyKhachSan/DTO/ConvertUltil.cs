using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public static class ConvertUltil
    {
        public static DataTable ConvertListToDataTable<T>(this List<T> list)
        {
            DataTable dataTable = new DataTable();
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));

            // Tạo các cột trong DataTable từ các thuộc tính
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor propertyDescriptor = props[i];
                Type type = propertyDescriptor.PropertyType;

                // Xử lý kiểu Nullable<>
                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                    type = Nullable.GetUnderlyingType(type);
                dataTable.Columns.Add(propertyDescriptor.Name, type);
            }

            // Duyệt qua danh sách và thêm hàng
            foreach (T item in list)
            {
                object[] values = new object[props.Count];
                for (int i = 0; i < props.Count; i++)
                {
                    values[i] = props[i].GetValue(item) ?? DBNull.Value;
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }
    }
}
