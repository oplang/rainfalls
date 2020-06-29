using System;
using System.IO;
using System.Xml;

namespace Zyf.Xml
{
    public class XMLReaderBase
    {
        #region 私有字段
        private string xmlFilePath;
        private XmlNode currentNode;
        #endregion

        internal XMLReaderBase(string filePath)
        {
            XMLFilePath = filePath;
            xmlFilePath = filePath;
        }

        #region 属性
        
        /// <summary>
        /// XML文件路径
        /// </summary>
        private string XMLFilePath
        {
            set
            {
                /*
                 * 初始化XML文档对象，并加载指定XML文件
                 * 如果加载产生“找不到文件”异常，置空XML文档对象，同时抛出该异常
                 */
                try
                {
                    XMLDocument = new XmlDocument();
                    XMLDocument.Load(value);
                }
                catch (FileNotFoundException ex)
                {
                    XMLDocument = null;
                    throw ex;
                }
            }
        }
        /// <summary>
        /// XML文档对象
        /// </summary>
        private XmlDocument XMLDocument { get; set; }
        /// <summary>
        /// 当前节点路径
        /// </summary>
        internal string CurrentNodePath
        {
            set
            {
                if (XMLDocument == null) throw new DocumentNotExistException("XML文档对象初始化失败，可能是XML文件不存在。");

                //初始化当前节点对象
                CurrentNode = GetNodeForPath(XMLDocument, value);                
            }
        }
        /// <summary>
        /// 当前节点对象
        /// </summary>
        internal XmlNode CurrentNode
        {
            get { return currentNode; }
            private set
            {
                if (value == null) throw new NodeNotFoundException("找不到XML节点“" + currentNode + "”");
                currentNode = value;
            }
        }

        #endregion

        #region 保护方法

        /// <summary>
        /// 创建XML属性
        /// </summary>
        /// <param name="name">属性名称</param>
        /// <returns></returns>
        internal XmlAttribute CreateAttribute(string name)
        {
            return XMLDocument.CreateAttribute(name);
        }

        /// <summary>
        /// 创建XML元素
        /// </summary>
        /// <param name="name">元素名称</param>
        /// <returns></returns>
        internal XmlElement CreateElement(string name)
        {
            return XMLDocument.CreateElement(name);
        }

        /// <summary>
        /// 保存XML文件
        /// </summary>
        internal void SaveFile()
        {
            XMLDocument.Save(xmlFilePath);
        }
        
        #endregion

        #region 初始化当前节点 私有方法

        /// <summary>
        /// 检查子节点
        /// </summary>
        /// <param name="childNode">要检查的子节点</param>
        /// <param name="nodeName">期望的节点名称</param>
        /// <param name="otherPath">节点路径</param>
        /// <returns></returns>
        private XmlNode CheckChildNode(XmlNode childNode, string nodeName, string otherPath)
        {
            // 如果某子节点的节点名称与期望的节点名称相同，
            if (childNode.Name == nodeName)
            {
                // 判断传入的节点路径有没有子节点，
                // 即“剩余部分”是否有值，
                if (otherPath != null && otherPath != string.Empty)
                {
                    // 如果有，深入检查下一级节点对象，
                    // 并使用方法执行结果做为返回值
                    return GetNodeForPath(childNode, otherPath);
                }
                else
                {
                    // 否则返回当前节点对象
                    return childNode;
                }
            }
            return null;
        }
        
        /// <summary>
        /// 根据节点路径获得指定节点
        /// </summary>
        /// <param name="root">当前节点</param>
        /// <param name="nodePath">节点路径</param>
        /// <returns></returns>
        private XmlNode GetNodeForPath(XmlNode root, string nodePath)
        {
            if (root.ChildNodes == null || root.ChildNodes.Count == 0 ||
                nodePath == null || nodePath == string.Empty)
            {
                return null;
            }

            return TraversalChildNodes(root, nodePath);
        }

        /// <summary>
        /// 遍历子点节，查找指定节点
        /// </summary>
        /// <param name="root">当前节点</param>
        /// <param name="nodePath">节点路径</param>
        /// <returns></returns>
        private XmlNode TraversalChildNodes(XmlNode root, string nodePath)
        {
            XmlNode result = null;

            // 从节点路径中截取期望的节点名称和剩余部分
            // 这里的“剩余部分”是后面N级的节点路径
            string[] nodepaths = nodePath.Split(new char[] { '/' }, 2);

            // 遍历当前节点下的所有子节点
            foreach (XmlNode node in root.ChildNodes)
            {
                //使用检查子点节的结果做为返回值
                result = this.CheckChildNode(node, nodepaths[0], nodepaths.Length > 1 ? nodepaths[1] : null);

                // 如果返回值不为空，说明已经找到指定节点，则结束当前循环
                if (result != null) break;
            }
            return result;
        }

        #endregion

    }
}
