using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Reflection;
namespace Basic
{
    /// <summary>
    /// ʵ��ת��������
    /// </summary>
    public class EntityConvertHelper<T> where T : new()
    {
        public static List<T> ConvertToModel(DataTable dt)
        {
            // ���弯��
            List<T> ts = new List<T>();
            // ��ô�ģ�͵�����
            Type type = typeof(T);
            string tempName = "";
            foreach (DataRow dr in dt.Rows)
            {
                T t = new T();
                // ��ô�ģ�͵Ĺ�������
                PropertyInfo[] propertys = t.GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    tempName = pi.Name;
                    // ���DataTable�Ƿ��������
                    if (dt.Columns.Contains(tempName))
                    {
                        // �жϴ������Ƿ���Setter
                        if (!pi.CanWrite) continue;
                        object value = dr[tempName];
                        if (value != DBNull.Value)
                            pi.SetValue(t, value, null);
                    }
                }
                ts.Add(t);
            }
            return ts;
        }
    }  
    
}