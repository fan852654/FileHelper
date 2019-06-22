using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace FileHerlper
{
    public enum FileMode
    {
        Create, CreateNew, Open, OpenOrCreate
    }
    public class FileHerlper
    {
        public FileInfo _deffile { get; set; }
        public FileHerlper(string path)
        {
            FileInfo fi = new FileInfo(path);
            if (!fi.Exists)
            {
                throw new Exception("Can not find file " + path);
            }
            else
            {
                _deffile = fi;
            }
        }
        public FileHerlper(FileInfo fi)
        {
            if (!fi.Exists)
            {
                throw new Exception("Can not find file " + fi.Name);
            }
            else
            {
                _deffile = fi;
            }
        }
        public FileHerlper(string path,FileMode fm)
        {
            try
            {
                FileInfo fi = new FileInfo(path);
                switch (fm)
                {
                    case FileMode.Create:
                        if (fi.Exists)
                        {
                            throw new Exception("File Exists");
                        }
                        else
                        {
                            fi.Create().Close();
                            _deffile = new FileInfo(fi.FullName);
                        }
                        break;
                    case FileMode.CreateNew:
                        if (fi.Exists)
                        {
                            fi.Delete();
                            fi.Create().Close();
                            _deffile = new FileInfo(fi.FullName);
                        }
                        else
                        {
                            fi.Create().Close();
                            _deffile = new FileInfo(fi.FullName);
                        }
                        break;
                    case FileMode.Open:
                        if (fi.Exists)
                        {
                            _deffile = new FileInfo(fi.FullName);
                        }
                        else
                        {
                            throw new Exception("Can not find file "+ fi.Name);
                        }
                        break;
                    case FileMode.OpenOrCreate:
                        if (!fi.Exists)
                        {
                            fi.Create().Close();
                        }
                        _deffile = new FileInfo(fi.FullName);
                        break;
                    default:
                        throw new Exception("Please choose one to do");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public FileHerlper(FileInfo fi,FileMode fm)
        {
            try
            {
                switch (fm)
                {
                    case FileMode.Create:
                        if (fi.Exists)
                        {
                            throw new Exception("File Exists");
                        }
                        else
                        {
                            fi.Create().Close();
                            _deffile = new FileInfo(fi.FullName);
                        }
                        break;
                    case FileMode.CreateNew:
                        if (fi.Exists)
                        {
                            fi.Delete();
                            fi.Create().Close();
                            _deffile = new FileInfo(fi.FullName);
                        }
                        else
                        {
                            fi.Create().Close();
                            _deffile = new FileInfo(fi.FullName);
                        }
                        break;
                    case FileMode.Open:
                        if (fi.Exists)
                        {
                            _deffile = new FileInfo(fi.FullName);
                        }
                        else
                        {
                            throw new Exception("Can not find file " + fi.Name);
                        }
                        break;
                    case FileMode.OpenOrCreate:
                        if (!fi.Exists)
                        {
                            fi.Create().Close();
                        }
                        _deffile = new FileInfo(fi.FullName);
                        break;
                    default:
                        throw new Exception("Please choose one to do");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Aappendobject(object _data)
        {
            if(_deffile != null && _deffile.Exists && !_deffile.IsReadOnly)
            {
                using(StreamWriter fs = _deffile.AppendText())
                {
                    fs.Write(_data);
                    fs.Flush();
                }
            }else if (_deffile.IsReadOnly)
            {
                throw new Exception("This file is readonly");
            }
            else
            {
                throw new Exception("Objects are not referenced to instances");
            }
            return;
        }
        public void Aappendchar(char[] _data)
        {
            if(_deffile != null && _deffile.Exists && !_deffile.IsReadOnly)
            {
                using(StreamWriter fs = _deffile.AppendText())
                {
                    fs.Write(_data);
                    fs.Flush();
                }
            }else if (_deffile.IsReadOnly)
            {
                throw new Exception("This file is readonly");
            }
            else
            {
                throw new Exception("Objects are not referenced to instances");
            }
            return;
        }
        public async System.Threading.Tasks.Task AappendcharAsync(char[] _data)
        {
            if(_deffile != null && _deffile.Exists && !_deffile.IsReadOnly)
            {
                using(StreamWriter fs = _deffile.AppendText())
                {
                    await fs.WriteAsync(_data);
                    await fs.FlushAsync();
                }
            }else if (_deffile.IsReadOnly)
            {
                throw new Exception("This file is readonly");
            }
            else
            {
                throw new Exception("Objects are not referenced to instances");
            }
            return;
        }
        public void AappendText(string _data)
        {
            if(_deffile != null && _deffile.Exists && !_deffile.IsReadOnly)
            {
                using(StreamWriter fs = _deffile.AppendText())
                {
                    fs.Write(_data);
                    fs.Flush();
                }
            }else if (_deffile.IsReadOnly)
            {
                throw new Exception("This file is readonly");
            }
            else
            {
                throw new Exception("Objects are not referenced to instances");
            }
            return;
        }
        public async System.Threading.Tasks.Task AappendTextAsync(string _data)
        {
            if(_deffile != null && _deffile.Exists && !_deffile.IsReadOnly)
            {
                using(StreamWriter fs = _deffile.AppendText())
                {
                    await fs.WriteAsync(_data);
                    await fs.FlushAsync();
                }
            }else if (_deffile.IsReadOnly)
            {
                throw new Exception("This file is readonly");
            }
            else
            {
                throw new Exception("Objects are not referenced to instances");
            }
            return;
        }

        public void Write(byte[] _data)
        {
            if (_deffile != null && _deffile.Exists && !_deffile.IsReadOnly)
            {
                using (FileStream fs = _deffile.Open(System.IO.FileMode.OpenOrCreate))
                {
                    fs.Write(_data, 0, _data.Length - 1);
                    fs.Flush();
                }
            }
            else if (_deffile.IsReadOnly)
            {
                throw new Exception("This file is readonly");
            }
            else
            {
                throw new Exception("Objects are not referenced to instances");
            }
            return;
        }
        public async System.Threading.Tasks.Task WriteAsync(byte[] _data)
        {
            if (_deffile != null && _deffile.Exists && !_deffile.IsReadOnly)
            {
                using (FileStream fs = _deffile.Open(System.IO.FileMode.OpenOrCreate))
                {
                    await fs.WriteAsync(_data, 0, _data.Length - 1);
                    await fs.FlushAsync();
                }
            }
            else if (_deffile.IsReadOnly)
            {
                throw new Exception("This file is readonly");
            }
            else
            {
                throw new Exception("Objects are not referenced to instances");
            }
            return;
        }
        public void Write(string _data)
        {
            if (_deffile != null && _deffile.Exists && !_deffile.IsReadOnly)
            {
                using (FileStream fs = _deffile.Open(System.IO.FileMode.OpenOrCreate))
                {
                    byte[] data = System.Text.Encoding.UTF8.GetBytes(_data);
                    fs.Write(data, 0, data.Length - 1);
                    fs.Flush();
                }
            }
            else if (_deffile.IsReadOnly)
            {
                throw new Exception("This file is readonly");
            }
            else
            {
                throw new Exception("Objects are not referenced to instances");
            }
            return;
        }
        public async System.Threading.Tasks.Task WriteAsync(string _data)
        {
            if (_deffile != null && _deffile.Exists && !_deffile.IsReadOnly)
            {
                using (FileStream fs = _deffile.Open(System.IO.FileMode.OpenOrCreate))
                {
                    byte[] data = System.Text.Encoding.UTF8.GetBytes(_data);
                    await fs.WriteAsync(data, 0, data.Length - 1);
                    await fs.FlushAsync();
                }
            }
            else if (_deffile.IsReadOnly)
            {
                throw new Exception("This file is readonly");
            }
            else
            {
                throw new Exception("Objects are not referenced to instances");
            }
            return;
        }
        public void Delete()
        {
            if (_deffile != null && _deffile.Exists)
            {
                _deffile.Delete();
            }
        }
        public void Create()
        {
            if (_deffile != null && !_deffile.Exists)
            {
                _deffile.Create();
            }
        }
        public void CopyTo(string path)
        {
            if(_deffile != null && _deffile.Exists)
            {
                _deffile.CopyTo(path);
            }
            else
            {
                throw new Exception("Can not find file or Objects are not referenced to instances");
            }
        }
        public override string ToString()
        {
            JObject jobj = new JObject
            {
                { "DirectoryName", _deffile.DirectoryName },
                { "FullName", _deffile.FullName },
                { "Name", _deffile.Name },
                { "Length", _deffile.Length },
                { "Exists", _deffile.Exists },
                { "CreationTime", _deffile.CreationTime },
                { "CreationTimeUtc", _deffile.CreationTimeUtc },
                { "LastAccessTime", _deffile.LastAccessTime },
                { "LastAccessTimeUtc", _deffile.LastAccessTimeUtc },
                { "LastWriteTime", _deffile.LastWriteTime },
                { "LastWriteTimeUtc", _deffile.LastWriteTimeUtc },
                { "IsReadOnly", _deffile.IsReadOnly }
            };
            return JsonConvert.SerializeObject(jobj);
        }
    }
}
