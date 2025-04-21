using Microsoft.AspNetCore.Http;
using System.Text;

namespace TMom.Infrastructure.Helper
{
    public class FileHelper : IDisposable
    {
        private bool _alreadyDispose = false;

        #region 构造函数

        public FileHelper()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        ~FileHelper()
        {
            Dispose(); ;
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (_alreadyDispose) return;
            _alreadyDispose = true;
        }

        #endregion 构造函数

        #region IDisposable 成员

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable 成员

        #region 取得文件后缀名

        /****************************************
          * 函数名称：GetPostfixStr
          * 功能说明：取得文件后缀名
          * 参     数：filename:文件名称
          * 调用示列：
          *            string filename = "aaa.aspx";
          *            string s = EC.FileObj.GetPostfixStr(filename);
         *****************************************/

        /// <summary>
        /// 取后缀名
        /// </summary>
        /// <param name="filename">文件名</param>
        /// <returns>.gif|.html格式</returns>
        public static string GetPostfixStr(string filename)
        {
            int start = filename.LastIndexOf(".");
            if (start < 0) return "";
            int length = filename.Length;
            string postfix = filename.Substring(start, length - start);
            return postfix;
        }

        #endregion 取得文件后缀名

        #region 根据文件大小获取指定前缀的可用文件名

        /// <summary>
        /// 根据文件大小获取指定前缀的可用文件名
        /// </summary>
        /// <param name="folderPath">文件夹</param>
        /// <param name="prefix">文件前缀</param>
        /// <param name="size">文件大小(1m)</param>
        /// <param name="ext">文件后缀(.log)</param>
        /// <returns>可用文件名</returns>
        public static string GetAvailableFileWithPrefixOrderSize(string folderPath, string prefix, int size = 1 * 1024 * 1024, string ext = ".log")
        {
            var allFiles = new DirectoryInfo(folderPath);
            var selectFiles = allFiles.GetFiles().Where(fi => fi.Name.ToLower().Contains(prefix.ToLower()) && fi.Extension.ToLower() == ext.ToLower() && fi.Length < size).OrderByDescending(d => d.Name).ToList();

            if (selectFiles.Count > 0)
            {
                return selectFiles.FirstOrDefault().FullName;
            }

            return Path.Combine(folderPath, $@"{prefix}_{DateTime.Now.DateToTimeStamp()}.log");
        }

        public static string GetAvailableFileNameWithPrefixOrderSize(string _contentRoot, string prefix, int size = 1 * 1024 * 1024, string ext = ".log")
        {
            var folderPath = Path.Combine(_contentRoot, "Log");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var allFiles = new DirectoryInfo(folderPath);
            var selectFiles = allFiles.GetFiles().Where(fi => fi.Name.ToLower().Contains(prefix.ToLower()) && fi.Extension.ToLower() == ext.ToLower() && fi.Length < size).OrderByDescending(d => d.Name).ToList();

            if (selectFiles.Count > 0)
            {
                return selectFiles.FirstOrDefault().Name.Replace(".log", "");
            }

            return $@"{prefix}_{DateTime.Now.DateToTimeStamp()}";
        }

        #endregion 根据文件大小获取指定前缀的可用文件名

        #region 写文件

        /****************************************
          * 函数名称：WriteFile
          * 功能说明：写文件,会覆盖掉以前的内容
          * 参     数：Path:文件路径,Strings:文本内容
          * 调用示列：
          *            string Path = Server.MapPath("Default2.aspx");
          *            string Strings = "这是我写的内容啊";
          *            EC.FileObj.WriteFile(Path,Strings);
         *****************************************/

        /// <summary>
        /// 写文件
        /// </summary>
        /// <param name="Path">文件路径</param>
        /// <param name="Strings">文件内容</param>
        public static void WriteFile(string Path, string Strings)
        {
            if (!File.Exists(Path))
            {
                FileStream f = File.Create(Path);
                f.Close();
            }
            StreamWriter f2 = new StreamWriter(Path, false, System.Text.Encoding.GetEncoding("gb2312"));
            f2.Write(Strings);
            f2.Close();
            f2.Dispose();
        }

        /// <summary>
        /// 写文件
        /// </summary>
        /// <param name="Path">文件路径</param>
        /// <param name="Strings">文件内容</param>
        /// <param name="encode">编码格式</param>
        public static void WriteFile(string Path, string Strings, Encoding encode)
        {
            if (!File.Exists(Path))
            {
                FileStream f = File.Create(Path);
                f.Close();
            }
            StreamWriter f2 = new StreamWriter(Path, false, encode);
            f2.Write(Strings);
            f2.Close();
            f2.Dispose();
        }

        #endregion 写文件

        #region 读文件

        /****************************************
          * 函数名称：ReadFile
          * 功能说明：读取文本内容
          * 参     数：Path:文件路径
          * 调用示列：
          *            string Path = Server.MapPath("Default2.aspx");
          *            string s = EC.FileObj.ReadFile(Path);
         *****************************************/

        /// <summary>
        /// 读取文件内容
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string ReadFile(IFormFile file)
        {
            string res = "";
            try
            {
                using (var reader = new StreamReader(file.OpenReadStream(), Encoding.UTF8))
                {
                    res = reader.ReadToEnd();
                }
            }
            catch (Exception)
            {
                return res;
            }
            return res;
        }

        /// <summary>
        /// 读文件
        /// </summary>
        /// <param name="Path">文件路径</param>
        /// <returns></returns>
        public static string ReadFile(string Path)
        {
            string s = "";
            if (!File.Exists(Path))
                s = "不存在相应的目录";
            else
            {
                StreamReader f2 = new StreamReader(Path, System.Text.Encoding.GetEncoding("gb2312"));
                s = f2.ReadToEnd();
                f2.Close();
                f2.Dispose();
            }

            return s;
        }

        /// <summary>
        /// 读文件
        /// </summary>
        /// <param name="Path">文件路径</param>
        /// <param name="encode">编码格式</param>
        /// <returns></returns>
        public static string ReadFile(string Path, Encoding encode)
        {
            string s = "";
            if (!File.Exists(Path))
                s = "不存在相应的目录";
            else
            {
                StreamReader f2 = new StreamReader(Path, encode);
                s = f2.ReadToEnd();
                f2.Close();
                f2.Dispose();
            }

            return s;
        }

        #endregion 读文件

        #region 追加文件

        /****************************************
          * 函数名称：FileAdd
          * 功能说明：追加文件内容
          * 参     数：Path:文件路径,strings:内容
          * 调用示列：
          *            string Path = Server.MapPath("Default2.aspx");
          *            string Strings = "新追加内容";
          *            EC.FileObj.FileAdd(Path, Strings);
         *****************************************/

        /// <summary>
        /// 追加文件
        /// </summary>
        /// <param name="Path">文件路径</param>
        /// <param name="strings">内容</param>
        public static void FileAdd(string Path, string strings)
        {
            StreamWriter sw = File.AppendText(Path);
            sw.Write(strings);
            sw.Flush();
            sw.Close();
        }

        #endregion 追加文件

        #region 拷贝文件

        /****************************************
          * 函数名称：FileCoppy
          * 功能说明：拷贝文件
          * 参     数：OrignFile:原始文件,NewFile:新文件路径
          * 调用示列：
          *            string orignFile = Server.MapPath("Default2.aspx");
          *            string NewFile = Server.MapPath("Default3.aspx");
          *            EC.FileObj.FileCoppy(OrignFile, NewFile);
         *****************************************/

        /// <summary>
        /// 拷贝文件
        /// </summary>
        /// <param name="OrignFile">原始文件</param>
        /// <param name="NewFile">新文件路径</param>
        public static void FileCoppy(string orignFile, string NewFile)
        {
            File.Copy(orignFile, NewFile, true);
        }

        #endregion 拷贝文件

        #region 删除文件

        /****************************************
          * 函数名称：FileDel
          * 功能说明：删除文件
          * 参     数：Path:文件路径
          * 调用示列：
          *            string Path = Server.MapPath("Default3.aspx");
          *            EC.FileObj.FileDel(Path);
         *****************************************/

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="Path">路径</param>
        public static void FileDel(string Path)
        {
            File.Delete(Path);
        }

        #endregion 删除文件

        #region 移动文件

        /****************************************
          * 函数名称：FileMove
          * 功能说明：移动文件
          * 参     数：OrignFile:原始路径,NewFile:新文件路径
          * 调用示列：
          *             string orignFile = Server.MapPath("../说明.txt");
          *             string NewFile = Server.MapPath("http://www.cnblogs.com/说明.txt");
          *             EC.FileObj.FileMove(OrignFile, NewFile);
         *****************************************/

        /// <summary>
        /// 移动文件
        /// </summary>
        /// <param name="OrignFile">原始路径</param>
        /// <param name="NewFile">新路径</param>
        public static void FileMove(string orignFile, string NewFile)
        {
            File.Move(orignFile, NewFile);
        }

        #endregion 移动文件

        #region 保存文件

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="file">file</param>
        /// <param name="relativeDir">保存的相对路径文件夹, eg: /Images/Avatar</param>
        /// <param name="filePath">返回保存文件的相对路径, eg: /Images/Avatar/xxx.png</param>
        /// <param name="_fileName">文件名称 eg: 123.png</param>
        public static void SaveFile(IFormFile file, string relativeDir, out string filePath, string _fileName = "")
        {
            string fileName = _fileName;
            string fileExt = GetPostfixStr(file.FileName);
            // 如果外部有传文件名称, 就用传过来的值
            if (string.IsNullOrEmpty(_fileName))
            {
                fileName = $"{DateTime.Now.DateToTimeStamp()}{fileExt}";
            }
            string dir = Path.Combine(MomFilePath.BaseFilesPath, relativeDir);
            string path = Path.Combine(dir, fileName);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            filePath = $"{relativeDir}/{fileName}";
        }

        #endregion 保存文件

        #region 在当前目录下创建目录

        /****************************************
          * 函数名称：FolderCreate
          * 功能说明：在当前目录下创建目录
          * 参     数：OrignFolder:当前目录,NewFloder:新目录
          * 调用示列：
          *            string orignFolder = Server.MapPath("test/");
          *            string NewFloder = "new";
          *            EC.FileObj.FolderCreate(OrignFolder, NewFloder);
         *****************************************/

        /// <summary>
        /// 在当前目录下创建目录
        /// </summary>
        /// <param name="orignFolder">当前目录</param>
        /// <param name="NewFloder">新目录</param>
        public static void FolderCreate(string orignFolder, string NewFloder)
        {
            Directory.SetCurrentDirectory(orignFolder);
            Directory.CreateDirectory(NewFloder);
        }

        #endregion 在当前目录下创建目录

        #region 递归删除文件夹目录及文件

        /****************************************
          * 函数名称：DeleteFolder
          * 功能说明：递归删除文件夹目录及文件
          * 参     数：dir:文件夹路径
          * 调用示列：
          *            string dir = Server.MapPath("test/");
          *            EC.FileObj.DeleteFolder(dir);
         *****************************************/

        /// <summary>
        /// 递归删除文件夹目录及文件
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        public static void DeleteFolder(string dir)
        {
            if (Directory.Exists(dir)) //如果存在这个文件夹删除之
            {
                foreach (string d in Directory.GetFileSystemEntries(dir))
                {
                    if (File.Exists(d))
                        File.Delete(d); //直接删除其中的文件
                    else
                        DeleteFolder(d); //递归删除子文件夹
                }
                Directory.Delete(dir); //删除已空文件夹
            }
        }

        #endregion 递归删除文件夹目录及文件

        #region 将指定文件夹下面的所有内容copy到目标文件夹下面 如果目标文件夹为只读属性就会报错。

        /****************************************
          * 函数名称：CopyDir
          * 功能说明：将指定文件夹下面的所有内容copy到目标文件夹下面 如果目标文件夹为只读属性就会报错。
          * 参     数：srcPath:原始路径,aimPath:目标文件夹
          * 调用示列：
          *            string srcPath = Server.MapPath("test/");
          *            string aimPath = Server.MapPath("test1/");
          *            EC.FileObj.CopyDir(srcPath,aimPath);
         *****************************************/

        /// <summary>
        /// 指定文件夹下面的所有内容copy到目标文件夹下面
        /// </summary>
        /// <param name="srcPath">原始路径</param>
        /// <param name="aimPath">目标文件夹</param>
        public static void CopyDir(string srcPath, string aimPath)
        {
            try
            {
                // 检查目标目录是否以目录分割字符结束如果不是则添加之
                if (aimPath[aimPath.Length - 1] != Path.DirectorySeparatorChar)
                    aimPath += Path.DirectorySeparatorChar;
                // 判断目标目录是否存在如果不存在则新建之
                if (!Directory.Exists(aimPath))
                    Directory.CreateDirectory(aimPath);
                // 得到源目录的文件列表，该里面是包含文件以及目录路径的一个数组
                //如果你指向copy目标文件下面的文件而不包含目录请使用下面的方法
                //string[] fileList = Directory.GetFiles(srcPath);
                string[] fileList = Directory.GetFileSystemEntries(srcPath);
                //遍历所有的文件和目录
                foreach (string file in fileList)
                {
                    //先当作目录处理如果存在这个目录就递归Copy该目录下面的文件

                    if (Directory.Exists(file))
                        CopyDir(file, aimPath + Path.GetFileName(file));
                    //否则直接Copy文件
                    else
                        File.Copy(file, aimPath + Path.GetFileName(file), true);
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.ToString());
            }
        }

        #endregion 将指定文件夹下面的所有内容copy到目标文件夹下面 如果目标文件夹为只读属性就会报错。

        #region 文件流 保存文件

        /// <summary>
        /// 通过字节流保存文件
        /// </summary>
        /// <param name="savePath"></param>
        /// <param name="by"></param>
        public static void SaveByByte(string savePath, byte[] by)
        {
            try
            {
                var dir = savePath.Replace(Path.GetFileName(savePath), "");
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                File.WriteAllBytes(savePath, by);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="relativeDir">保存的相对路径文件夹, eg: /Images/Avatar</param>
        /// <param name="fileName">文件名称, 包含后缀</param>
        /// <param name="filePath">返回的保存文件的路径</param>
        public static void SaveByByte(byte[] bytes, string relativeDir, string fileName, out string filePath)
        {
            string dir = Path.Combine(MomFilePath.BaseFilesPath, relativeDir);
            string path = Path.Combine(dir, fileName);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                BinaryWriter bw = new BinaryWriter(fileStream);
                bw.Write(bytes, 0, bytes.Length);
                bw.Close();
                fileStream.Close();
            }
            filePath = $"{relativeDir}/{fileName}";
        }

        #endregion 文件流 保存文件
    }

    #region 文件路径

    public static class MomFilePath
    {
        /// <summary>
        /// 头像存放路径
        /// </summary>
        public const string Images_Avatar = "Images/Avatar";

        /// <summary>
        /// 二维码存放路径
        /// </summary>
        public const string Images_QRCode = "Images/QRCode";

        /// <summary>
        /// 文件
        /// </summary>
        public const string Files = "Files";

        /// <summary>
        /// 文件路径 C:/Mom/Static
        /// <para>开发环境: 存放在wwwroot下</para>
        /// </summary>
        public static string BaseFilesPath = Appsettings.app(["File", "Path"]);
    }

    #endregion 文件路径
}