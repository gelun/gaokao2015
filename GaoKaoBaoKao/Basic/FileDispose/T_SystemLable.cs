using System;

/// <summary>
/// T_SystemLable 的摘要说明
/// </summary>
namespace Basic.FileDispose
{
    public class TSystemLable
    {
        #region Model
        private int _id;
        private string _name;
        private int _typeid;
        private string _title;
        private string _info;
        private string _remarks;
        private string _head;
        private string _content;
        private string _footer;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 标签名称
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 标签分类
        /// </summary>
        public int TypeID
        {
            set { _typeid = value; }
            get { return _typeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 标签内容
        /// </summary>
        public string Info
        {
            set { _info = value; }
            get { return _info; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks
        {
            set { _remarks = value; }
            get { return _remarks; }
        }
        /// <summary>
        /// 开始标记
        /// </summary>
        public string Head
        {
            set { _head = value; }
            get { return _head; }
        }
        /// <summary>
        /// 主体循环标记
        /// </summary>
        public string Content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// 结束标记
        /// </summary>
        public string Footer
        {
            set { _footer = value; }
            get { return _footer; }
        }
        #endregion Model
    }
}
