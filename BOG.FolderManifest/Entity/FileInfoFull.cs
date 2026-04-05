namespace BOG.FolderManifest.Entity
{
    public class FileInfoFull
    {
        private string _Name = string.Empty;
        private DateTime _LastModDate = DateTime.MinValue;
        private long _Size = 0;
        private string _AssemblyVersionInfo = string.Empty;

        public FileInfoFull()
        {
        }

        public FileInfoFull(string p_Name, DateTime p_LastModDate, long p_Size, string p_AssemblyVersionInfo)
        {
            this._Name = p_Name;
            this._LastModDate = p_LastModDate;
            this._Size = p_Size;
            this._AssemblyVersionInfo = p_AssemblyVersionInfo;
        }

        public FileInfoFull(FileInfoFull p_obj)
        {
            Load(p_obj);
        }

        public FileInfoFull(object[] p_obj)
        {
            this._Name = (string)p_obj[0];
            this._LastModDate = (DateTime)p_obj[1];
            this._Size = (long)p_obj[2];
            this._AssemblyVersionInfo = (string)p_obj[3];
        }

        public void Load(FileInfoFull p_obj)
        {
            this._Name = p_obj.Name;
            this._LastModDate = p_obj.LastModDate;
            this._Size = p_obj.Size;
            this._AssemblyVersionInfo = p_obj.AssemblyVersionInfo;
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public DateTime LastModDate
        {
            get { return _LastModDate; }
            set { _LastModDate = value; }
        }

        public long Size
        {
            get { return _Size; }
            set { _Size = value; }
        }

        public string AssemblyVersionInfo
        {
            get { return _AssemblyVersionInfo; }
            set { _AssemblyVersionInfo = value; }
        }
    }
}


