using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMusicStore.Entities
{
    public abstract class Entity
    {
        //public virtual Guid Id { get; set; }
        public virtual int Id { get;  set; }
    }
}


namespace YourNameSpace.SubSpace
{
    //Class,Interface,Enum are in mixed with an initial upper letter
    enum EnumTypes
    {
        None = 0x0,
        Sunday = 0x1,
        Monday = 0x2,
        Tuesday = 0x4,
        Wednesday = 0x8,
        Thursday = 0x10,
        Friday = 0x20,
        Saturday = 0x40
    }

    public class SampleClassName
    {


        //If the variable is only access within a class is prefixed with an m_ .
        private string m_PrivateVariable = String.Empty;

        private EnumTypes m_LocaleEumTypes = EnumTypes.None;

        //Named constants are in ALL_CAPS
        public const int CONSTANT_VARIABLE = 5;

        //Properties
        public string Properties
        {
            get { return m_PrivateVariable; }
            set { m_PrivateVariable = value; }
        }

        //Constructor
        public SampleClassName()
        {
            ///to do
        }

        //Methods
        public void MethodA(String paramString)
        {
            //Local variables are with an initial lowercase letter.
            string localVariable = String.Empty;

            ///to do
        }
    }

    /// <summary>
    /// Contains global variables for project.
    /// </summary>
    public static class GlobalVariable
    {
        static int m_GlobalValue;

        /// <summary>
        /// Global variables are prefixed with a g_
        /// </summary>
        public static int g_GlobalValue
        {
            get
            {
                return m_GlobalValue;
            }
            set
            {
                m_GlobalValue = value;
            }
        }

        public static bool g_GlobalBoolean;
    }
}