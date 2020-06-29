using System;
using System.Collections.Generic;
using System.Xml;

namespace Zyf.Xml
{
    public class XMLReader : XMLReaderBase
    {
        public XMLReader(string filePath, string currentPath)
            : base(filePath)
        {
            base.CurrentNodePath = currentPath;
        }

        #region 公有方法

  
        /// <summary>
        /// 根据属性名称获得指定属性的值
        /// </summary>
        /// <param name="name">属性名称</param>
        /// <returns></returns>
        public string GetAttribute(string name)
        {
            //检查当前节点是否被初始化
            CheckCurrentNode();
            //获取指定属性
            XmlAttribute attribute = CurrentNode.Attributes[name];
            //返回属性的值
            return attribute == null ? null : attribute.Value;
        }
        /// <summary>
        /// 根据一个节点名获取一个节点的文本
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetChildNodeText(string name)
        {
            //检查当前节点是否被初始化
            CheckCurrentNode();
            //获取指定节点
            XmlNode node = CurrentNode[name];
            //返回节点的文本
            return node == null ? null : node.InnerText;
        }
        /// <summary>
        /// 获取一个指定类型的对象
        /// </summary>
        /// <param name="classPath">对象的类型</param>
        /// <returns></returns>
        public object GetObjectByClassPath(string classPath)
        {
            //检查当前节点是否被初始化
            CheckCurrentNode();
            //获取属性集合
            IDictionary<string, string> attrs = GetChildNodes();
            //初始化一个对象创建者
            ObjectCreator oc = new ObjectCreator(classPath);
            //设置对象属性
            oc.SetAttributes(attrs);
            //返回对象
            return oc.Object;
        }
        /// <summary>
        /// 设置指定属性的值
        /// </summary>
        /// <param name="name">属性名称</param>
        /// <param name="value">属性值</param>
        public void SetAttribute(string name, string value)
        {
            //检查当前节点是否被初始化
            CheckCurrentNode();
            //设置节点属性
            SetNodeAttribute(name, value);
            //保存文件
            SaveFile();
        }
        /// <summary>
        /// 设置指定子节点的文本
        /// </summary>
        /// <param name="name">子节点名称</param>
        /// <param name="value">文本内容</param>
        public void SetChildNodeText(string name, string value)
        {
            //检查当前节点是否被初始化
            CheckCurrentNode();
            //设置子节点的文本
            SetChildNodeInnerText(name, value);
            //保存文件
            SaveFile();
        }
        /// <summary>
        /// 设置一个对象（保存一个对象的所有属性）
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void SetObject(object obj)
        {
            //检查当前节点是否被初始化
            CheckCurrentNode();
            //初始化一个对象创建者
            ObjectCreator oc = new ObjectCreator(obj);
            //获取对象属性集合
            IDictionary<string, string> args = oc.GetAttributes();
            //遍历属性集合，添加子节点
            foreach (var arg in args)
            {
                SetChildNodeInnerText(arg.Key, arg.Value);
            }
            SaveFile();
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 向当前节点追加一个属性
        /// </summary>
        /// <param name="name">属性名称</param>
        /// <param name="value">属性值</param>
        private void AppendAttribute(string name, string value)
        {
            //使用XML文档对象创建一个属性
            XmlAttribute xa = CreateAttribute(name);
            //设置属性的值
            xa.Value = value;
            //将创建的属性追加到当前节点中
            CurrentNode.Attributes.Append(xa);
        }
        /// <summary>
        /// 在当前节点下添加一个节点元素
        /// </summary>
        /// <param name="name">元素名称</param>
        /// <param name="value">文本内容</param>
        private void AppendElement(string name, string value)
        {
            //创建一个节点元素
            XmlElement xd = CreateElement(name);
            //设置元素的文本
            xd.InnerText = value;
            //将创建的元素追加到当前节点中
            CurrentNode.AppendChild(xd);
        }
        /// <summary>
        /// 检查当前节点是否被初始化
        /// </summary>
        private void CheckCurrentNode()
        {
            if (CurrentNode == null) throw new CurrentNodeIsNullException("没有初始化当前节点");
        }
        /// <summary>
        /// 获取子节点的“键/值”对形式
        /// </summary>
        /// <returns></returns>
        private IDictionary<string, string> GetChildNodes()
        {
            IDictionary<string, string> result = new Dictionary<string, string>();

            foreach (XmlNode node in CurrentNode)
            {
                result.Add(node.Name, node.InnerText);
            }

            return result;
        }
        /// <summary>
        /// 替换指定的属性值
        /// </summary>
        /// <param name="name">属性名称</param>
        /// <param name="value">属性值</param>
        /// <returns></returns>
        private bool ReplaceAttribute(string name, string value)
        {
            //遍历当前节点的属性
            foreach (XmlAttribute xa in CurrentNode.Attributes)
            {
                //如果找到指定的属性，就设置对应的属性值
                if (xa.Name == name)
                {
                    xa.Value = value;
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 替换指定节点的InnerText
        /// </summary>
        /// <param name="name">节点名称</param>
        /// <param name="value">节点值</param>
        /// <returns></returns>
        private bool ReplaceInnerText(string name, string value)
        {
            //遍历当前节点的子节点
            foreach (XmlNode xn in CurrentNode.ChildNodes)
            {
                //如果找到指定的节点，就设置对应的节点文本
                if (xn.Name == name)
                {
                    xn.InnerText = value;
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 设置节点属性
        /// </summary>
        /// <param name="name">属性名称</param>
        /// <param name="value">属性值</param>
        private void SetNodeAttribute(string name, string value)
        {
            //如果替换属性执行失败，就追加一个属性
            if (!this.ReplaceAttribute(name, value))
            {
                this.AppendAttribute(name, value);
            }
        }
        /// <summary>
        /// 设置子节点内部的文本
        /// </summary>
        /// <param name="childNodeName">子节点名称</param>
        /// <param name="value">子节点值</param>
        private void SetChildNodeInnerText(string childNodeName, string value)
        {
            //如果替换指定节点的文本执行失败，就追加一个节点
            if (!this.ReplaceInnerText(childNodeName, value))
            {
                this.AppendElement(childNodeName, value);
            }
        }

        #endregion

    }
}
