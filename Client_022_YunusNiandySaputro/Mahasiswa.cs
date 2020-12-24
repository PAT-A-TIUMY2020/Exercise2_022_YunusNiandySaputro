using System.Runtime.Serialization;

namespace Client_022_YunusNiandySaputro
{
    [DataContract]
    public class Mahasiswa
    {
        private string _nama, _nim, _prodi, _angkatan;
        [DataMember]
        public string nama
        {
            get { return _nama; }
            set { _nama = value; }
        }
        [DataMember]
        public string nim
        {
            get { return _nim; }
            set { _nim = value; }
        }
        [DataMember]
        public string prodi
        {
            get { return _prodi; }
            set { _prodi = value; }
        }
        [DataMember]
        public string angkatan
        {
            get { return _angkatan; }
            set { _angkatan = value; }
        }
    }
}
