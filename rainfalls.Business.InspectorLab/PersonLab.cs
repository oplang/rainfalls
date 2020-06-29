using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zyf.un.Xml;
using System.Xml;

namespace rainfalls.Business.InspectorLab
{
    public class PersonLab
    {
        private readonly string configPath = AppDomain.CurrentDomain.BaseDirectory + "person_x.xml";
        private List<Person> m_pPersonList = new List<Person>();
        private static PersonLab uniqueInstance;
        private static readonly object padlock = new object();
        private PersonLab()
        {
            
        }
        public static PersonLab getInstance()
        {
            if (uniqueInstance == null)
            {
                lock (padlock)
                {
                    if (uniqueInstance == null)
                    {
                        uniqueInstance = new PersonLab();
                    }
                }
            }
            return uniqueInstance;
        }
        public void InitializingPersonList()
        {
            try
            {
                System.Xml.XmlNodeList list = xmlHelper.GetXmlNodeList(configPath, "/Config/site/person");
                foreach (System.Xml.XmlNode nl in list)
                {
                    Person p = new Person();
                    p.PersonName = nl.Attributes["name"].Value;
                    p.PersonPhone = nl.Attributes["phone"].Value;
                    p.PersonType = nl.Attributes["type"].Value;
                    p.PersonState = nl.Attributes["state"].Value;
                    m_pPersonList.Add(p);
                }
            }
            catch { };
        }
    
        public void UpdatePersonState(string phone,string state)
        {
            XmlDocument xmldocument = new XmlDocument();
            xmldocument.Load(configPath);
            XmlNodeList childList = xmldocument.SelectNodes("/Config/site/person");
            foreach (System.Xml.XmlNode xnl in childList)
            {
                if (xnl.Attributes["phone"].Value.Equals(phone))
                    xnl.Attributes["state"].Value = state;
            }
            xmldocument.Save(configPath);
            foreach (Person p in m_pPersonList)
            {
                if (p.PersonPhone.Equals(phone))
                {
                    p.PersonState = state;
                }
            }
            
        }
        public Person GetPerson(string phone)
        {
            foreach (Person p in m_pPersonList)
            {
                if (p.PersonPhone.Equals(phone))
                {
                    if (p.PersonState.Equals("0"))
                    {
                        return p;
                    }
                }
            }
            return null;
        }
        public List<Person> PersonList
        {
            get { return m_pPersonList; }
            set { m_pPersonList = value; }
        }
    }
}
