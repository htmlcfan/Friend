using System;
using System.Data;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Model
{
    /// <summary>
    /// 实体类 UserInfo, 此类请勿动，以方便表字段更改时重新生成覆盖
    /// </summary>
    [DataContract]
    [Serializable]
    public class UserInfo : ICloneable
    {
        public UserInfo()
        { }

        #region 实体属性

        /// <summary>
        /// UID
        /// </summary>
        [DataMember]
        public int? UID { get; set; }

        /// <summary>
        /// NAME
        /// </summary>
        [DataMember]
        public string NAME { get; set; }

        /// <summary>
        /// SEX
        /// </summary>
        [DataMember]
        public string SEX { get; set; }

        /// <summary>
        /// DATA
        /// </summary>
        [DataMember]
        public string DATA { get; set; }

        /// <summary>
        /// PLACE
        /// </summary>
        [DataMember]
        public string PLACE { get; set; }

        /// <summary>
        /// NATION
        /// </summary>
        [DataMember]
        public string NATION { get; set; }

        /// <summary>
        /// HEIGHT
        /// </summary>
        [DataMember]
        public string HEIGHT { get; set; }

        /// <summary>
        /// IMG
        /// </summary>
        [DataMember]
        public string IMG { get; set; }

        /// <summary>
        /// HISTORY
        /// </summary>
        [DataMember]
        public string HISTORY { get; set; }

        /// <summary>
        /// EDUCATION
        /// </summary>
        [DataMember]
        public string EDUCATION { get; set; }

        /// <summary>
        /// SCHOOL
        /// </summary>
        [DataMember]
        public string SCHOOL { get; set; }

        /// <summary>
        /// ADDRESS
        /// </summary>
        [DataMember]
        public string ADDRESS { get; set; }

        /// <summary>
        /// WORKT
        /// </summary>
        [DataMember]
        public string WORKT { get; set; }

        /// <summary>
        /// WORKPLACE
        /// </summary>
        [DataMember]
        public string WORKPLACE { get; set; }

        /// <summary>
        /// PHONE
        /// </summary>
        [DataMember]
        public string PHONE { get; set; }

        /// <summary>
        /// INTEREST
        /// </summary>
        [DataMember]
        public string INTEREST { get; set; }

        /// <summary>
        /// OHEIGHT
        /// </summary>
        [DataMember]
        public string OHEIGHT { get; set; }

        /// <summary>
        /// OWORK
        /// </summary>
        [DataMember]
        public string OWORK { get; set; }

        /// <summary>
        /// OINTEREST
        /// </summary>
        [DataMember]
        public string OINTEREST { get; set; }

        /// <summary>
        /// OSTRENGTH
        /// </summary>
        [DataMember]
        public string OSTRENGTH { get; set; }

        /// <summary>
        /// MIN
        /// </summary>
        [DataMember]
        public string MIN { get; set; }

        /// <summary>
        /// MAX
        /// </summary>
        [DataMember]
        public string MAX { get; set; }

        /// <summary>
        /// OWORKPLACE
        /// </summary>
        [DataMember]
        public string OWORKPLACE { get; set; }

        /// <summary>
        /// FAMILY
        /// </summary>
        [DataMember]
        public string FAMILY { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [DataMember]
        public string Password { get; set; }

        /// <summary>
        /// UserType
        /// </summary>
        [DataMember]
        public int? UserType { get; set; }

        /// <summary>
        /// UserName
        /// </summary>
        [DataMember]
        public int? OpeID { get; set; }


        /// <summary>
        /// UserName
        /// </summary>
        [DataMember]
        public string ImageData { get; set; }


        #endregion

        #region ICloneable 成员

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        #endregion

        public override bool Equals(object obj)
        {
            Model.UserInfo model = obj as Model.UserInfo;
            if (model != null && model.UID == this.UID)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            return UID.GetHashCode();
        }
    }
}