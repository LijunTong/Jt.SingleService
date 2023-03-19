using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.Win32;
using System.Collections;
using System.Security.Cryptography;

namespace Jt.SingleService.Lib.Utils
{
    /// <summary>
    /// 通用方法的类
    /// </summary>
    public class CHelperCommon
    {
        /// <summary>
        /// 延迟时间
        /// </summary>
        /// <param name="ms">毫秒</param>
        public static void Delay(int ms)
        {
            var beginTime = DateTime.Now;
            while (true)
            {
                var endTime = DateTime.Now;

                var ts = endTime - beginTime;
                if (ts.TotalMilliseconds >= ms)
                {
                    break;
                }
                Thread.Sleep(10);
            }
        }

        /// <summary>
        /// 将文本追加到文件中
        /// 并且换行
        /// </summary>
        /// <param name="strFilePath">文件全路径，包括目录与文件名</param>
        /// <param name="strText">文本信息</param>
        public static void AppendTextToFile(string strFilePath, string strText)
        {
            string directoryName = Path.GetDirectoryName(strFilePath);
            if (!Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }

            if (!strText.EndsWith("\r\n"))
            {
                strText += "\r\n";
            }

            File.AppendAllText(strFilePath, strText, Encoding.Default);
        }

        /// <summary>
        /// 从嵌入资源中读取文件内容(e.g: xml).
        /// </summary>
        /// <param name="fileWholeName">嵌入资源文件名，包括项目的命名空间.</param>
        /// <returns>资源中的文件内容.</returns>
        public static string ReadFileFromEmbedded(string fileWholeName)
        {
            string result = string.Empty;

            using (TextReader reader = new StreamReader(
                Assembly.GetExecutingAssembly().GetManifestResourceStream(fileWholeName)))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }


        /// <summary>
        /// 获区枚举类型的键值对
        /// </summary>
        /// <param name="enumType">枚举类型</param>
        /// <returns>键值对，key:名称 value:值</returns>
        public static Dictionary<string, int> GetEnumDic(Type enumType)
        {
            Dictionary<string, int> dicEnum = new Dictionary<string, int>();
            foreach (int value in Enum.GetValues(enumType))
            {
                if (!dicEnum.ContainsKey(Enum.GetName(enumType, value)))
                {
                    dicEnum.Add(Enum.GetName(enumType, value), value);
                }
            }

            return dicEnum;
        }

        /// <summary>
        /// 获取枚举类型的枚举名称以及对应的描述信息
        /// </summary>
        /// <param name="enumType">枚举类型</param>
        /// <returns>键值对，key:名称 value:描述信息</returns>
        public static Dictionary<string, string> GetEnumDescp<T>(T t)
        {
            Dictionary<string, string> dicDescp = new Dictionary<string, string>();

            FieldInfo[] fieldInfos = t.GetType().GetFields(BindingFlags.Public | BindingFlags.Static);
            if (fieldInfos != null && fieldInfos.Length > 0)
            {
                foreach (FieldInfo item in fieldInfos)
                {
                    object[] attrs = item.GetCustomAttributes(typeof(DescriptionAttribute), false);
                    if (attrs != null && attrs.Length > 0)
                    {
                        if (!dicDescp.ContainsKey(item.Name))
                        {
                            dicDescp.Add(item.Name, ((DescriptionAttribute)attrs[0]).Description);
                        }
                    }
                }
            }
            return dicDescp;
        }

        /// <summary>
        /// 计算商品条码的校验位
        /// 比如说某个商品的条形码是： 6 9 2 3 0 7 6 2 1 3 1 9 5
        /// 一。把奇数位的数字加起来，除了最后一位校验码，这里是 6＋2＋0＋6＋1＋1＝16 这个＝A
        /// 二。把偶数位的数字加起来，这里是 9＋3＋7＋2＋3＋9＝33 这个＝B
        /// 三。A＋3×B＝115，取个位数 5
        /// 四。10－5＝5
        /// 这就是最后一位那个校验码 5 的来历。。。
        /// </summary>
        /// <param name="strCode"></param>
        /// <returns></returns>
        public static string CalcCheckSumEAN13(string strCode)
        {
            int nCheckSum = 0;
            if (strCode.Length != 13)
            {
                throw new Exception(string.Format("商品条码:{0},长度不是13", strCode));
            }

            string strTemp = strCode.Substring(0, 12);
            int nSumOdd = 0;//奇数位和
            int nSumEven = 0;//偶数位和
            for (int i = 0; i < strTemp.Length; i++)
            {
                if ((i + 1) % 2 == 0)//偶数位
                {
                    nSumEven += int.Parse(strTemp[i].ToString());
                }
                else//奇数位
                {
                    nSumOdd += int.Parse(strTemp[i].ToString());
                }
            }

            int a = nSumOdd + 3 * nSumEven;
            //取a的个位数，即是最后一位
            int b = int.Parse(a.ToString().Substring(a.ToString().Length - 1, 1));
            //用10－b,即是校验位
            nCheckSum = 10 - b;
            return nCheckSum.ToString();
        }

        /// <summary>  
        /// 列从1开始,转换得到excel列中的英文序号  
        /// 调用示例：string s = TransferExcelColumnIndex(5);//得到E  
        /// </summary>  
        /// <param name="colIndex"></param>  
        /// <returns></returns>
        public static string TransferExcelColIndex(int colIndex)
        {
            string strResult = "";
            int iHead = (colIndex - 1) / 26;
            int iLeftOver = (colIndex - 1) % 26;
            if (iHead >= 26)
            {
                strResult = TransferExcelColIndex(iHead);
            }
            else if (iHead > 0)
            {
                strResult += (char)(64 + iHead);
            }

            strResult += (char)(65 + iLeftOver);

            return strResult;
        }

        ///   <summary>   
        ///   将DataReader转换为DataTable   
        ///   </summary>   
        ///   <param   name="reader">要被转换的DataReader</param>   
        ///   <returns>转换后的DataTable</returns>   
        public static DataTable ConvertDataReaderToDataTable(IDataReader reader)
        {
            try
            {
                DataTable objDataTable = new DataTable();
                int intFieldCount = reader.FieldCount;

                //将列名添加到DataTable中   
                for (int intCounter = 0; intCounter < intFieldCount; ++intCounter)
                {
                    objDataTable.Columns.Add(reader.GetName(intCounter), reader.GetFieldType(intCounter));
                }

                //装入内容   
                objDataTable.BeginLoadData();

                object[] objValues = new object[intFieldCount];
                while (reader.Read())
                {
                    reader.GetValues(objValues);
                    objDataTable.LoadDataRow(objValues, true);
                }
                reader.Close();
                objDataTable.EndLoadData();

                return objDataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// DataTable对象转换成List<T>对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <returns></returns>
        public static List<T> DataTableToList<T>(DataTable table)
        {
            if (table == null)
            {
                return null;
            }

            List<DataRow> rows = new List<DataRow>();

            foreach (DataRow row in table.Rows)
            {
                rows.Add(row);
            }

            List<T> list = null;

            if (rows != null)
            {
                list = new List<T>();

                foreach (DataRow row in rows)
                {
                    T item = DataRowToObject<T>(row);
                    list.Add(item);
                }
            }

            return list;
        }

        private static List<T> ConvertTo<T>(List<DataRow> rows)
        {
            List<T> list = null;

            if (rows != null)
            {
                list = new List<T>();

                foreach (DataRow row in rows)
                {
                    T item = DataRowToObject<T>(row);
                    list.Add(item);
                }
            }

            return list;
        }

        /// <summary>
        /// DataRow对象转换成Object<T>对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="row"></param>
        /// <returns></returns>
        public static T DataRowToObject<T>(DataRow row)
        {
            T obj = default;
            if (row != null)
            {
                obj = Activator.CreateInstance<T>();

                foreach (DataColumn column in row.Table.Columns)
                {
                    PropertyInfo prop = obj.GetType().GetProperty(column.ColumnName);

                    object value = row[column.ColumnName];
                    prop.SetValue(obj, value, null);
                }
            }
            return obj;
        }

        /// <summary>
        /// List<T>对象转换成DataTable对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static DataTable ListToDataTable<T>(List<T> collection)
        {
            var props = typeof(T).GetProperties();
            var dt = new DataTable();
            dt.Columns.AddRange(props.Select(p => new DataColumn(p.Name, p.PropertyType)).ToArray());
            if (collection.Count() > 0)
            {
                for (int i = 0; i < collection.Count(); i++)
                {
                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in props)
                    {
                        object obj = pi.GetValue(collection.ElementAt(i), null);
                        tempList.Add(obj);
                    }
                    object[] array = tempList.ToArray();
                    dt.LoadDataRow(array, true);
                }
            }
            return dt;
        }

        /// <summary>
        /// 获取时间戳Timestamp  
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="isMillisconds">是否是毫秒，默认为：true</param>
        /// <returns></returns>
        public static long GetTimeStamp(DateTime dt, bool isMillisconds = true)
        {
            DateTime dateStart = new DateTime(1970, 1, 1, 8, 0, 0);
            long timeStamp = isMillisconds ? Convert.ToInt64((dt - dateStart).TotalMilliseconds) : Convert.ToInt64((dt - dateStart).TotalSeconds);
            return timeStamp;
        }

        public static bool IsImageFile(string extension)
        {
            List<string> imageExList = new List<string>() { ".bmp", ".jpg", ".gif", ".png", ".jpeg", ".tif" };
            return imageExList.Contains(extension.ToLower());
        }
    }
}
