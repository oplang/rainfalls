using System;
using System.Collections.Generic;
using System.Reflection;

namespace Zyf.Xml
{
    class ObjectCreator
    {
        #region 字段
        object o;
        #endregion

        public ObjectCreator(string classPath)
        {
            InitObject(classPath);
        }

        public ObjectCreator(object obj)
        {
            o = obj;
        }

        #region 属性

        /// <summary>
        /// 获取一个对象
        /// </summary>
        public object Object
        {
            get
            {
                return o;
            }
        }
        
        #endregion

        #region 公有方法

        /// <summary>
        /// 获取对象属性值集合
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, string> GetAttributes()
        {
            IDictionary<string, string> args = new Dictionary<string, string>();
            //遍历所有属性
            foreach (PropertyInfo pi in o.GetType().GetProperties())
            {
                //取出属性值
                string value = this.GetPropertyValue(pi);
                //添加到集合中
                if (value != null)
                {
                    args.Add(pi.Name, value);
                }
            }
            return args;
        }
        /// <summary>
        /// 设置对象属性
        /// </summary>
        /// <param name="attrs"></param>
        public void SetAttributes(IDictionary<string, string> attrs)
        {
            /* 遍历对象属性，分别设值 */
            foreach (PropertyInfo pi in o.GetType().GetProperties())
            {
                object value = this.RestoreType(pi, attrs);
                pi.SetValue(o, value, null);
            }
        }
        
        #endregion

        #region 私有方法

        /// <summary>
        /// 获取指定属性的值
        /// </summary>
        /// <param name="pi">属性</param>
        /// <returns></returns>
        private string GetPropertyValue(PropertyInfo pi)
        {
            object ov = pi.GetValue(o, null);
            switch (ov.GetType().Name)
            {
                case "Byte":
                case "Int16":
                case "Int32":
                case "Int64":
                case "SByte":
                case "UInt16":
                case "UInt32":
                case "UInt64":
                case "Single":
                case "Double":
                case "Decimal":
                case "Boolean":
                case "Char":
                case "String":
                case "DateTime": return ov.ToString();
                default: return null;
            }
        }
        /// <summary>
        /// 初始化对象
        /// </summary>
        /// <param name="classPath"></param>
        private void InitObject(string classPath)
        {
            Assembly assembly = Assembly.Load(classPath.Substring(0, classPath.LastIndexOf('.')));
            Type type = assembly.GetType(classPath);

            o = Activator.CreateInstance(type);
        }
        /// <summary>
        /// 恢复类型
        /// </summary>
        /// <param name="pi"></param>
        /// <param name="attrs"></param>
        /// <returns></returns>
        private object RestoreType(PropertyInfo pi, IDictionary<string, string> attrs)
        {
            object result = null;
            Type t = pi.PropertyType;
            switch (t.Name)
            {
                /*-- 整型 --*/
                case "Byte": result = Byte.Parse(attrs[pi.Name]); break;
                case "Int16": result = Int16.Parse(attrs[pi.Name]); break;
                case "Int32": result = Int32.Parse(attrs[pi.Name]); break;
                case "Int64": result = Int64.Parse(attrs[pi.Name]); break;
                case "SByte": result = SByte.Parse(attrs[pi.Name]); break;
                case "UInt16": result = UInt16.Parse(attrs[pi.Name]); break;
                case "UInt32": result = UInt32.Parse(attrs[pi.Name]); break;
                case "UInt64": result = UInt64.Parse(attrs[pi.Name]); break;
                /*-- 浮点型 --*/
                case "Single": result = Single.Parse(attrs[pi.Name]); break;
                case "Double": result = Double.Parse(attrs[pi.Name]); break;
                case "Decimal": result = Decimal.Parse(attrs[pi.Name]); break;
                /*-- 其它类型 --*/
                case "Boolean": result = Boolean.Parse(attrs[pi.Name]); break;
                case "Char": result = Char.Parse(attrs[pi.Name]); break;
                case "String": result = attrs[pi.Name]; break;
                case "DateTime": result = DateTime.Parse(attrs[pi.Name]); break;
                /*-- 其它 --*/
                default: result = null; break;
            }
            return result;
        }

        #endregion
    }
}
