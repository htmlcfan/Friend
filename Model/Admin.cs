using System;
using System.Data;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Model
{
    /// <summary>
    /// 实体类 Admin, 此类请勿动，以方便表字段更改时重新生成覆盖
    /// </summary>
    [DataContract]
    [Serializable]
    public class Admin : ICloneable
    {
        public Admin()
        { }

        #region 实体属性

        /// <summary>
        /// ID
        /// </summary>
        [DataMember]
        public int? ID { get; set; }

        /// <summary>
        /// UserName
        /// </summary>
        [DataMember]
        public string UserName { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [DataMember]
        public string Password { get; set; }

        #endregion

        #region ICloneable 成员

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        #endregion

        public override bool Equals(object obj)
        {
            Model.Admin model = obj as Model.Admin;
            if (model != null && model.ID == this.ID)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
    }
}