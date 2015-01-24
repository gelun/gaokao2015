using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using Encoder = System.Drawing.Imaging.Encoder;
using System.Runtime.InteropServices;
using System.Web.Script.Serialization;

namespace Basic
{

    public struct JsosG
    {
        public string msg { get; set; }
        public string msbox { get; set; }
    }
	/// <summary>
	/// Thumbnail ��ժҪ˵����
	/// </summary>
	public class Upload
    {
        #region �����ļ�
        public static string SaveFile(string DestPath, string strExtension)
        {

            string filename = Path.GetFileName(HttpContext.Current.Request.Files[0].FileName);
            string fileextname = Path.GetExtension(filename);
            string filetype = HttpContext.Current.Request.Files[0].ContentType.ToLower();
            string newfilename;

            if (String.IsNullOrEmpty(strExtension))
                strExtension = fileextname;

            // �ж� �ļ���չ��/�ļ���С/�ļ����� �Ƿ����Ҫ��
            if (fileextname.ToLower().Equals(strExtension))
            {
                StringBuilder savedir = new StringBuilder();
                savedir.Append(DestPath);

                // ���ָ��Ŀ¼����������
                if (!Directory.Exists(GetMapPath(savedir.ToString())))
                {
                    CreateDir(GetMapPath(savedir.ToString()));
                }

                Random random = new Random();
                newfilename = DateTime.Now.ToString("yyyyMMddHHmmss") + random.Next(1000, 9999).ToString() + fileextname;

                string newfileurl = savedir.ToString() + newfilename;
                HttpContext.Current.Request.Files[0].SaveAs(GetMapPath(newfileurl));
                return newfilename;
            }
            return "";
        }
        
        /// <summary>
		/// �����ϴ�ͷ��
		/// </summary>
		/// <param name="MaxAllowFileSize">��������ͷ���ļ��ߴ�(��λ:KB)</param>
		/// <returns>�����ļ������·��</returns>
		public static string SaveRequestImageFile(string DestPath,int userid, int MaxAllowFileSize)
		{

			string filename = Path.GetFileName(HttpContext.Current.Request.Files[0].FileName);
			string fileextname = Path.GetExtension(filename);
			string filetype = HttpContext.Current.Request.Files[0].ContentType.ToLower();
            string newfilename;
			//int filesize = HttpContext.Current.Request.Files[0].ContentLength;
			// �ж� �ļ���չ��/�ļ���С/�ļ����� �Ƿ����Ҫ��
			if ((fileextname.ToLower().Equals(".jpg") || fileextname.ToLower().Equals(".gif") || fileextname.ToLower().Equals(".png")) && (filetype.StartsWith("image")))
			{
				StringBuilder savedir = new StringBuilder();
				savedir.Append(DestPath);

                savedir.Append(DateTime.Now.ToString("yyyy"));
				savedir.Append(Path.DirectorySeparatorChar);
				savedir.Append(DateTime.Now.ToString("MM"));
				savedir.Append(Path.DirectorySeparatorChar);
				savedir.Append(DateTime.Now.ToString("dd"));
				savedir.Append(Path.DirectorySeparatorChar);
			    
                // ���ָ��Ŀ¼����������
                if (!Directory.Exists(GetMapPath(savedir.ToString())))
				{
					CreateDir(GetMapPath(savedir.ToString()));
				}

                Random random = new Random();
                newfilename = savedir.ToString() + Environment.TickCount.ToString() +  random.Next(1000,9999).ToString() + "." + fileextname;

                if (System.IO.File.Exists(GetMapPath(newfilename)))
                    newfilename = savedir.ToString() + Environment.TickCount.ToString() + random.Next(1000, 9999).ToString() + "." + fileextname;
                //File.Delete(GetMapPath(savedir.ToString()) + userid.ToString() + ".jpg");
                //File.Delete(GetMapPath(savedir.ToString()) + userid.ToString() + ".gif");
                //File.Delete(GetMapPath(savedir.ToString()) + userid.ToString() + ".png");

                //int FileLength = fuFileUpload.FileBytes.Length;
                //double x;
                //x = FileLength / 1048576;
                //int EndLength = int.Parse(x.ToString());
                //if (EndLength > 30)
                //30M
                //if (HttpContext.Current.Request.Files[0].ContentLength <= MaxAllowFileSize)
                //{
					HttpContext.Current.Request.Files[0].SaveAs(GetMapPath(newfilename));
					return newfilename;
                //}
			}
			return "";
        }		
		
		/// <summary>
		/// �����ϴ����ļ�
		/// </summary>
		/// <param name="forumid">���id</param>
		/// <param name="MaxAllowFileCount">���������ϴ��ļ�����</param>
		/// <param name="MaxSizePerDay">ÿ������ĸ�����С����</param>
		/// <param name="MaxFileSize">�������������ļ��ֽ���</param>/// 
		/// <param name="TodayUploadedSize">�����Ѿ��ϴ��ĸ����ֽ�����</param>
		/// <param name="AllowFileType">������ļ�����, ��string[]��ʽ�ṩ</param>
		/// <param name="config">�������淽ʽ 0=����/��/�մ��벻ͬĿ¼ 1=����/��/��/��̳���벻ͬĿ¼ 2=����̳���벻ͬĿ¼ 3=���ļ����ʹ��벻ͬĿ¼</param>
		/// <param name="watermarkstatus">ͼƬˮӡλ��</param>
		/// <param name="filekey">File�ؼ���Key(��Name����)</param>
		/// <returns>�ļ���Ϣ�ṹ</returns>
        //public static AttachmentInfo[] SaveRequestFiles(int forumid, int MaxAllowFileCount, int MaxSizePerDay, int MaxFileSize, int TodayUploadedSize, string AllowFileType, int watermarkstatus, ConfigInfo config, string filekey)
        //{
        //    string[] tmp = Utils.SplitString(AllowFileType, "\r\n");
        //    string[] AllowFileExtName = new string[tmp.Length];
        //    int[] MaxSize = new int[tmp.Length];
			

        //    for (int i = 0; i < tmp.Length; i++)
        //    {
        //        AllowFileExtName[i] = Utils.CutString(tmp[i],0, tmp[i].LastIndexOf(","));
        //        MaxSize[i] = Utils.StrToInt(Utils.CutString(tmp[i], tmp[i].LastIndexOf(",") + 1), 0);
        //    }
				
        //    int saveFileCount = 0;
			
        //    int fCount = Math.Min(MaxAllowFileCount, HttpContext.Current.Request.Files.Count);

        //    for (int i = 0; i < fCount; i++)
        //    {
        //        if (!HttpContext.Current.Request.Files[i].FileName.Equals("") && HttpContext.Current.Request.Files.AllKeys[i].Equals(filekey))
        //        {
        //            saveFileCount++;
        //        }
        //    }

        //    AttachmentInfo[] attachmentinfo = new AttachmentInfo[saveFileCount];

        //    saveFileCount = 0;

        //    Random random = new Random(unchecked((int)DateTime.Now.Ticks)); 


        //    for (int i = 0; i < fCount; i++)
        //    {
        //        if (!HttpContext.Current.Request.Files[i].FileName.Equals("") && HttpContext.Current.Request.Files.AllKeys[i].Equals(filekey))
        //        {
        //            string filename = Path.GetFileName(HttpContext.Current.Request.Files[i].FileName);
        //            string fileextname = Utils.CutString(filename, filename.LastIndexOf(".") + 1).ToLower();
        //            string filetype = HttpContext.Current.Request.Files[i].ContentType.ToLower();
        //            int filesize = HttpContext.Current.Request.Files[i].ContentLength;
        //            string newfilename = "";
						
        //            attachmentinfo[saveFileCount] = new AttachmentInfo();

        //            attachmentinfo[saveFileCount].Sys_noupload = "";

        //            // �ж� �ļ���չ��/�ļ���С/�ļ����� �Ƿ����Ҫ��
        //            if (!(Utils.IsImgFilename(filename) && !filetype.StartsWith("image")))
        //            {
        //                int extnameid = Utils.GetInArrayID(fileextname, AllowFileExtName);

        //                if (extnameid >= 0 && (filesize <= MaxSize[extnameid]) && (MaxFileSize >= filesize /*|| MaxAllSize == 0*/) && (MaxSizePerDay - TodayUploadedSize >= filesize))
        //                {
        //                    TodayUploadedSize = TodayUploadedSize + filesize;
        //                    string UploadDir = Utils.GetMapPath(BaseConfigFactory.GetForumPath + "upload/");
        //                    StringBuilder savedir = new StringBuilder("");
        //                    //�������淽ʽ 0=����/��/�մ��벻ͬĿ¼ 1=����/��/��/��̳���벻ͬĿ¼ 2=����̳���벻ͬĿ¼ 3=���ļ����ʹ��벻ͬĿ¼
        //                    if (config.Attachsave == 1)
        //                    {
        //                        savedir.Append(DateTime.Now.ToString("yyyy"));
        //                        savedir.Append(Path.DirectorySeparatorChar);
        //                        savedir.Append(DateTime.Now.ToString("MM"));
        //                        savedir.Append(Path.DirectorySeparatorChar);
        //                        savedir.Append(DateTime.Now.ToString("dd"));
        //                        savedir.Append(Path.DirectorySeparatorChar);
        //                        savedir.Append(forumid.ToString());
        //                        savedir.Append(Path.DirectorySeparatorChar);
        //                    }	
        //                    else if (config.Attachsave == 2)
        //                    {
        //                        savedir.Append(forumid);
        //                        savedir.Append(Path.DirectorySeparatorChar);
        //                    }
        //                    else if (config.Attachsave == 3)
        //                    {
        //                        savedir.Append(fileextname);
        //                        savedir.Append(Path.DirectorySeparatorChar);
        //                    }
        //                    else
        //                    {
        //                        savedir.Append(DateTime.Now.ToString("yyyy"));
        //                        savedir.Append(Path.DirectorySeparatorChar);
        //                        savedir.Append(DateTime.Now.ToString("MM"));
        //                        savedir.Append(Path.DirectorySeparatorChar);
        //                        savedir.Append(DateTime.Now.ToString("dd"));
        //                        savedir.Append(Path.DirectorySeparatorChar);
        //                    }
        //                    // ���ָ��Ŀ¼����������
        //                    if (!Directory.Exists(UploadDir + savedir.ToString()))
        //                    {
        //                        Utils.CreateDir(UploadDir + savedir.ToString());
        //                    }
						
        //                    newfilename = savedir.ToString() + Environment.TickCount.ToString() +  i.ToString() + random.Next(1000,9999).ToString() + "." + fileextname;
						
						
        //                    try
        //                    {
        //                        // �����bmp jpg pngͼƬ����
        //                        if ((fileextname == "bmp" || fileextname == "jpg" || fileextname == "jpeg" || fileextname == "png") && filetype.StartsWith("image"))
        //                        {
														
        //                            Image img = Image.FromStream(HttpContext.Current.Request.Files[i].InputStream);
        //                            if (config.Attachimgmaxwidth > 0 && img.Width > config.Attachimgmaxwidth)
        //                            {
        //                                attachmentinfo[saveFileCount].Sys_noupload = "ͼƬ���Ϊ" + img.Width.ToString() + ", ϵͳ����������Ϊ" + config.Attachimgmaxwidth.ToString();
	
        //                            }
        //                            if (config.Attachimgmaxheight > 0 && img.Height > config.Attachimgmaxheight)
        //                            {
        //                                attachmentinfo[saveFileCount].Sys_noupload = "ͼƬ�߶�Ϊ" + img.Width.ToString() + ", ϵͳ��������߶�Ϊ" + config.Attachimgmaxheight.ToString();
        //                            }									
        //                            if (attachmentinfo[saveFileCount].Sys_noupload == "")
        //                            {
        //                                if (watermarkstatus == 0)
        //                                {
        //                                    HttpContext.Current.Request.Files[i].SaveAs(UploadDir + newfilename);
        //                                    attachmentinfo[saveFileCount].Filesize = filesize;
        //                                }
        //                                else
        //                                {
        //                                    if (config.Watermarktype == 1 && File.Exists(Utils.GetMapPath(BaseConfigFactory.GetForumPath + "watermark/" + config.Watermarkpic)))
        //                                    {
        //                                        AddImageSignPic(img, UploadDir + newfilename, Utils.GetMapPath(BaseConfigFactory.GetForumPath + "watermark/" + config.Watermarkpic), config.Watermarkstatus, config.Attachimgquality, config.Watermarktransparency);
        //                                    }
        //                                    else
        //                                    {
        //                                        string watermarkText;
        //                                        watermarkText = config.Watermarktext.Replace("{1}", config.Forumtitle);
        //                                        watermarkText = watermarkText.Replace("{2}", config.Forumurl);
        //                                        watermarkText = watermarkText.Replace("{3}", Utils.GetDate());
        //                                        watermarkText = watermarkText.Replace("{4}", Utils.GetTime());
        //                                        AddImageSignText(img, UploadDir + newfilename, watermarkText, config.Watermarkstatus, config.Attachimgquality, config.Watermarkfontname, config.Watermarkfontsize);
        //                                    }
        //                                    // ��ü�ˮӡ����ļ�����
        //                                    attachmentinfo[saveFileCount].Filesize = new FileInfo(UploadDir + newfilename).Length;
        //                                }
        //                            }
        //                        }
        //                        else
        //                        {
        //                            HttpContext.Current.Request.Files[i].SaveAs(UploadDir + newfilename);
        //                            attachmentinfo[saveFileCount].Filesize = filesize;
        //                        }
        //                    }
        //                    catch
        //                    {
        //                        if (!(Utils.FileExists(UploadDir + newfilename)))
        //                        {
        //                            HttpContext.Current.Request.Files[i].SaveAs(UploadDir + newfilename);
        //                            attachmentinfo[saveFileCount].Filesize = filesize;
        //                        }
        //                    }
						
        //                }
        //                else
        //                {
        //                    if (extnameid < 0)
        //                    {
        //                        attachmentinfo[saveFileCount].Sys_noupload = "�ļ���ʽ��Ч";
        //                    }
        //                    else if (MaxSizePerDay - TodayUploadedSize < filesize)
        //                    {
        //                        attachmentinfo[saveFileCount].Sys_noupload = "�ļ����ڽ��������ϴ����ֽ���";
        //                    }
        //                    else if (filesize > MaxSize[extnameid])
        //                    {
        //                        attachmentinfo[saveFileCount].Sys_noupload = "�ļ����ڸ����͸���������ֽ���";
        //                    }
        //                    else
        //                    {
        //                        attachmentinfo[saveFileCount].Sys_noupload = "�ļ����ڵ����ļ������ϴ����ֽ���";
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                attachmentinfo[saveFileCount].Sys_noupload = "�ļ���ʽ��Ч";
        //            }
        //            attachmentinfo[saveFileCount].Filename = newfilename;
        //            attachmentinfo[saveFileCount].Description = fileextname;
        //            attachmentinfo[saveFileCount].Filetype = filetype;
        //            attachmentinfo[saveFileCount].Attachment = filename;
        //            attachmentinfo[saveFileCount].Downloads = 0;
        //            attachmentinfo[saveFileCount].Postdatetime = DateTime.Now.ToString();
        //            attachmentinfo[saveFileCount].Sys_index = i;
        //            saveFileCount++;
        //        }
        //    }
        //    return attachmentinfo;

        //}
        #endregion


        /// <summary>
        /// �ж��Ƿ����ϴ����ļ�
        /// </summary>
        /// <returns>�Ƿ����ϴ����ļ�</returns>
        public static bool IsPostFile()
        {
            for (int i = 0; i < HttpContext.Current.Request.Files.Count; i++)
            {
                if (HttpContext.Current.Request.Files[i].FileName != "")
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// ��õ�ǰ����·��
        /// </summary>
        /// <param name="strPath">ָ����·��</param>
        /// <returns>����·��</returns>
        private static string GetMapPath(string strPath)
        {
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Server.MapPath(strPath);
            }
            else //��web��������
            {
                return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strPath);
            }
        }

        private static bool CreateDir(string name)
        {
            return MakeSureDirectoryPathExists(name);
        }

        [DllImport("dbgHelp", SetLastError = true)]
        private static extern bool MakeSureDirectoryPathExists(string name);



	}





    public class UpLoading
    {
      
         string basePath="/UpFile/";
      

        public UpLoading(string  file)
        {
           basePath=file;
        }

        #region  �ϴ�ͼƬ

        /// <summary>
        /// �ϴ�ͼƬ��httpͼƬ�ļ���дˮӡ��д����ͼ��дСͼ
        /// </summary>
        /// <param name="_postedFile">httpͼƬ�ļ�</param>
        /// <returns></returns>
        public string ImagUploading(HttpPostedFile _postedFile)
        {
            //�ж��Ƿ����������򷵻ش�����Ϣ
             JavaScriptSerializer js = new JavaScriptSerializer();

            try
            {


                String serverFileName = "";//��ͼ·��

                string _fileExt = _postedFile.FileName.Substring(_postedFile.FileName.LastIndexOf(".") + 1);  //��ȡ�ļ���ʽ


              

                #region  ���ͼƬ�Ƿ�ϸ�

                //���ͼƬ�Ƿ����Ҫ��
                string dfileJson = DetectionFiel(_fileExt);
                JsosG aa = js.Deserialize<JsosG>(dfileJson); //���ͼƬ�Ƿ����Ҫ��
                if (aa.msg != "0") return dfileJson;//���ش�����Ϣ


                #endregion


                #region  �����ļ��У��ļ�����·��
                string _fileName = DateTime.Now.ToString("yyyyMMddHHmmssff") + "." + _fileExt; //��������ļ���


                //���ϵͳ���õı����·�� �Ƿ���/��ͷ��β
                if (this.basePath.StartsWith("/") == false) this.basePath = "/" + this.basePath;
                if (this.basePath.EndsWith("/") == false) this.basePath = this.basePath + "/";


                //�����ڹ��ౣ�棺����
                string _datePath =basePath+DateTime.Now.ToString("yyyyMMdd")  + "/";

      

                //�����ļ���
                if (!Directory.Exists(HttpContext.Current.Server.MapPath(_datePath)))  //������ļ���
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(_datePath));
                }

                //�������浽���ݿ��·��
                serverFileName = _datePath + _fileName;

                #endregion        

          
                //�����ļ�
                 _postedFile.SaveAs(HttpContext.Current.Server.MapPath(_datePath) + _fileName);
                     
                #endregion 


                return "{\"msg\":\"1\", \"msbox\": \"" + serverFileName + "\"}";
            }
            catch(Exception ex)
            {
                return "{\"msg\":\"0\", \"msbox\": \"�ϴ������з����������\"}";
            }
        }

       



        #region   �����ļ���ʽ ��СҪ��

        /// <summary>
        /// ͨ���ļ���չ�����ļ����Ƿ�ΪͼƬ����Ƿ��������
        /// </summary>
        /// <param name="_fileExt">��չ����������</param>
        /// <param name="_postedFile">�ļ�</param>
        /// <param name="isImage">�Ƿ�ΪͼƬ</param>
        /// <returns></returns>
        private string DetectionFiel(string _fileExt)
        {
          
                if (!CheckFileExt("BMP|JPEG|JPG|GIF|PNG|TIFF", _fileExt))
                {
                    return "{msg: 1, msbox: \"�������ϴ�" + _fileExt + "���͵��ļ���\"}";
                }
                return "{msg: 0, msbox: \"�ļ������ϴ�\"}";
        }

        #endregion

        #region  �Ա��ļ���ʽ
        /// <summary>
        /// ����Ƿ�Ϊ�Ϸ����ϴ��ļ�
        /// </summary>
        /// <returns></returns>
        private bool CheckFileExt(string _fileType, string _fileExt)
        {
            string[] allowExt = _fileType.Split('|');
            for (int i = 0; i < allowExt.Length; i++)
            {
                if (allowExt[i].ToLower() == _fileExt.ToLower()) { return true; }
            }
            return false;
        }

        #endregion 
    }
}


