using System;
using System.Data;
using System.Configuration;
using System.Xml;
namespace Rainfall.App.AppSync
{
    /// <summary>
    /// XmlHelper ��ժҪ˵��
    /// </summary>
    public class CXml
    {
        public CXml()
        {
        }

        /// <summary>
        /// ��ȡ����
        /// </summary>
        /// <param name="path">·��</param>
        /// <param name="node">�ڵ�</param>
        /// <param name="attribute">���������ǿ�ʱ���ظ�����ֵ�����򷵻ش���ֵ</param>
        /// <returns>string</returns>
        public static string Read(string path, string node, string attribute)
        {
            string value = "";
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode xn = doc.SelectSingleNode(node);
                value = (attribute.Equals("") ? xn.InnerText : xn.Attributes[attribute].Value);
            }
            catch { }
            return value;
        }

        public static XmlNodeList ReadList(string path, string node)
        {
            XmlNodeList pList = null;
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                pList = doc.SelectNodes(node);

                return pList;
            }
            catch { }
            return null;
        }

        public static string GetNodeAttribute(string attribute, XmlNode node)
        {
            try
            {
                string value = "";
                value = (attribute.Equals("") ? node.InnerText : node.Attributes[attribute].Value);

                return value;
            }
            catch
            {
                return "";
            }

        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="path">·��</param>
        /// <param name="node">�ڵ�</param>
        /// <param name="element">Ԫ�������ǿ�ʱ������Ԫ�أ������ڸ�Ԫ���в�������</param>
        /// <param name="attribute">���������ǿ�ʱ�����Ԫ������ֵ���������Ԫ��ֵ</param>
        /// <param name="value">ֵ</param>
        /// <returns></returns>
        public static void Insert(string path, string node, string element, string attribute, string value)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode xn = doc.SelectSingleNode(node);
                if (element.Equals(""))
                {
                    if (!attribute.Equals(""))
                    {
                        XmlElement xe = (XmlElement)xn;
                        xe.SetAttribute(attribute, value);
                    }
                }
                else
                {
                    XmlElement xe = doc.CreateElement(element);
                    if (attribute.Equals(""))
                        xe.InnerText = value;
                    else
                        xe.SetAttribute(attribute, value);
                    xn.AppendChild(xe);
                }
                doc.Save(path);
            }
            catch { }
        }

        /// <summary>
        /// �޸�����
        /// </summary>
        /// <param name="path">·��</param>
        /// <param name="node">�ڵ�</param>
        /// <param name="attribute">���������ǿ�ʱ�޸ĸýڵ�����ֵ�������޸Ľڵ�ֵ</param>
        /// <param name="value">ֵ</param>
        /// <returns></returns>
        public static void Update(string path, string node, string attribute, string value)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode xn = doc.SelectSingleNode(node);
                XmlElement xe = (XmlElement)xn;
                if (attribute.Equals(""))
                    xe.InnerText = value;
                else
                    xe.SetAttribute(attribute, value);
                doc.Save(path);
            }
            catch { }
        }

        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="path">·��</param>
        /// <param name="node">�ڵ�</param>
        /// <param name="attribute">���������ǿ�ʱɾ���ýڵ�����ֵ������ɾ���ڵ�ֵ</param>
        /// <param name="value">ֵ</param>
        /// <returns></returns>
        public static void Delete(string path, string node, string attribute)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode xn = doc.SelectSingleNode(node);
                XmlElement xe = (XmlElement)xn;
                if (attribute.Equals(""))
                    xn.ParentNode.RemoveChild(xn);
                else
                    xe.RemoveAttribute(attribute);
                doc.Save(path);
            }
            catch { }
        }
    }
}

