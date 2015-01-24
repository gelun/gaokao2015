using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace Entity
{
    //Join_Project
    public class Join_Project
    {

        /// <summary>
        /// ProjectId
        /// </summary>		
        private int _projectid;
        public int ProjectId
        {
            get { return _projectid; }
            set { _projectid = value; }
        }
        /// <summary>
        /// ProjectName
        /// </summary>		
        private string _projectname;
        public string ProjectName
        {
            get { return _projectname; }
            set { _projectname = value; }
        }
        /// <summary>
        /// Content
        /// </summary>		
        private string _content;
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }
        /// <summary>
        /// TopPCid
        /// </summary>		
        private int _toppcid;
        public int TopPCid
        {
            get { return _toppcid; }
            set { _toppcid = value; }
        }
        /// <summary>
        /// PCidList
        /// </summary>		
        private string _pcidlist;
        public string PCidList
        {
            get { return _pcidlist; }
            set { _pcidlist = value; }
        }
        /// <summary>
        /// IsValid
        /// </summary>		
        private int _isvalid;
        public int IsValid
        {
            get { return _isvalid; }
            set { _isvalid = value; }
        }
        /// <summary>
        /// IsPause
        /// </summary>		
        private int _ispause;
        public int IsPause
        {
            get { return _ispause; }
            set { _ispause = value; }
        }
        /// <summary>
        /// AddTime
        /// </summary>		
        private DateTime _addtime;
        public DateTime AddTime
        {
            get { return _addtime; }
            set { _addtime = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private int _pcid;
        public int PCid
        {
            set { _pcid = value; }
            get { return _pcid; }
        }

        /// <summary>
        /// 
        /// </summary>
        private string _applicantfile;
        public string ApplicantFile
        {
            set { _applicantfile = value; }
            get { return _applicantfile; }
        }

        /// <summary>
        /// 
        /// </summary>
        private int _ischeck;
        public int IsCheck
        {
            get { return _ischeck; }
            set { _ischeck = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private int _ishot;
        public int IsHot
        {
            get { return _ishot; }
            set { _ishot = value; }
        }
    }
}

